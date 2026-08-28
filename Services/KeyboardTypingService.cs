using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using WindowTextInjector.Models;
using WindowTextInjector.Native;

namespace WindowTextInjector.Services;

public enum MultiLineMode
{
    AutoRowClick,           // Zeilenweise aufteilen (Klickt in jede Zeile des markierten Bereichs)
    TabBetweenLines,        // Zeile tippen -> Tab drücken -> nächste Zeile
    DownArrowBetweenLines,  // Zeile tippen -> Pfeil-Runter drücken -> nächste Zeile
    SingleFieldWithEnter    // Alles in ein einzelnes Feld tippen (mit Enter)
}

public class TypingOptions
{
    public bool PerformFocusClick { get; set; } = true;
    public int PreClickDelayMs { get; set; } = 100;
    public int PostClickDelayMs { get; set; } = 250;
    public int CharDelayMs { get; set; } = 15;
    public int LineDelayMs { get; set; } = 150;
    public bool ClearTargetFirst { get; set; } = false;
    public bool PressEnterAtEnd { get; set; } = false;
    public bool PressTabAtEnd { get; set; } = false;
    public bool BringWindowToFront { get; set; } = true;
    public MultiLineMode MultiLineMode { get; set; } = MultiLineMode.AutoRowClick;
}

public class TypingProgress
{
    public int CurrentIndex { get; set; }
    public int TotalLength { get; set; }
    public string StatusMessage { get; set; } = string.Empty;
    public int Percent => TotalLength > 0 ? (int)((CurrentIndex / (double)TotalLength) * 100) : 0;
}

public class KeyboardTypingService
{
    public const ushort VK_BACK = 0x08;
    public const ushort VK_TAB = 0x09;
    public const ushort VK_RETURN = 0x0D;
    public const ushort VK_CONTROL = 0x11;
    public const ushort VK_DOWN = 0x28;
    public const ushort VK_A = 0x41;

    public async Task TypeTextIntoTargetAsync(
        TargetArea target,
        string text,
        TypingOptions options,
        IProgress<TypingProgress>? progress = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(text);

        progress?.Report(new TypingProgress
        {
            CurrentIndex = 0,
            TotalLength = text.Length,
            StatusMessage = "Aktiviere Zielfenster..."
        });

        // 1. Bring window to foreground
        if (options.BringWindowToFront && target.WindowHandle != IntPtr.Zero)
        {
            Win32Input.ForceForegroundWindow(target.WindowHandle);
        }

        if (options.PreClickDelayMs > 0)
        {
            await Task.Delay(options.PreClickDelayMs, cancellationToken);
        }

        // Split text into normalized lines
        string normalized = text.Replace("\r\n", "\n").Replace('\r', '\n');
        string[] lines = normalized.Split('\n');

        if (lines.Length > 1 && options.MultiLineMode == MultiLineMode.AutoRowClick)
        {
            await TypeMultiRowAsync(target, lines, options, progress, cancellationToken);
        }
        else if (lines.Length > 1 && options.MultiLineMode == MultiLineMode.TabBetweenLines)
        {
            await TypeWithKeySeparatorAsync(target, lines, VK_TAB, options, progress, cancellationToken);
        }
        else if (lines.Length > 1 && options.MultiLineMode == MultiLineMode.DownArrowBetweenLines)
        {
            await TypeWithKeySeparatorAsync(target, lines, VK_DOWN, options, progress, cancellationToken);
        }
        else
        {
            await TypeSingleFieldAsync(target, text, options, progress, cancellationToken);
        }

        // Post-typing global keys
        if (options.PressEnterAtEnd)
        {
            await Task.Delay(50, cancellationToken);
            Win32Input.SendVirtualKey(VK_RETURN);
        }

        if (options.PressTabAtEnd)
        {
            await Task.Delay(50, cancellationToken);
            Win32Input.SendVirtualKey(VK_TAB);
        }

        progress?.Report(new TypingProgress
        {
            CurrentIndex = text.Length,
            TotalLength = text.Length,
            StatusMessage = "Fertig! Text erfolgreich eingetippt."
        });
    }

    /// <summary>
    /// Slices the marked rectangle into N rows and types each line into its corresponding row.
    /// </summary>
    private async Task TypeMultiRowAsync(
        TargetArea target,
        string[] lines,
        TypingOptions options,
        IProgress<TypingProgress>? progress,
        CancellationToken cancellationToken)
    {
        List<Point> rowPoints = target.GetRowCenterPoints(lines.Length);
        int totalChars = 0;
        foreach (var l in lines) totalChars += l.Length;
        int typedChars = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Point rowPoint = rowPoints[i];
            progress?.Report(new TypingProgress
            {
                CurrentIndex = typedChars,
                TotalLength = totalChars,
                StatusMessage = $"Zeile {i + 1}/{lines.Length}: Klicke auf Koordinate ({rowPoint.X}, {rowPoint.Y})..."
            });

            if (options.PerformFocusClick)
            {
                Win32Input.ClickAt(rowPoint.X, rowPoint.Y);
                if (options.PostClickDelayMs > 0)
                {
                    await Task.Delay(options.PostClickDelayMs, cancellationToken);
                }
            }

            if (options.ClearTargetFirst)
            {
                Win32Input.SendVirtualKey(VK_CONTROL);
                Win32Input.SendVirtualKey(VK_A);
                await Task.Delay(40, cancellationToken);
                Win32Input.SendVirtualKey(VK_BACK);
                await Task.Delay(40, cancellationToken);
            }

            // Type line text without trailing newline
            string lineText = lines[i];
            for (int c = 0; c < lineText.Length; c++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Win32Input.SendUnicodeChar(lineText[c]);
                typedChars++;

                progress?.Report(new TypingProgress
                {
                    CurrentIndex = typedChars,
                    TotalLength = totalChars,
                    StatusMessage = $"Tippe Zeile {i + 1}/{lines.Length} (Zeichen {typedChars}/{totalChars})..."
                });

                if (options.CharDelayMs > 0)
                {
                    await Task.Delay(options.CharDelayMs, cancellationToken);
                }
            }

            if (i < lines.Length - 1 && options.LineDelayMs > 0)
            {
                await Task.Delay(options.LineDelayMs, cancellationToken);
            }
        }
    }

    /// <summary>
    /// Types line by line, pressing a navigation key (Tab or Down Arrow) between each line.
    /// </summary>
    private async Task TypeWithKeySeparatorAsync(
        TargetArea target,
        string[] lines,
        ushort separatorVk,
        TypingOptions options,
        IProgress<TypingProgress>? progress,
        CancellationToken cancellationToken)
    {
        Point center = target.CenterPoint;

        if (options.PerformFocusClick)
        {
            progress?.Report(new TypingProgress
            {
                CurrentIndex = 0,
                TotalLength = 100,
                StatusMessage = $"Klicke auf erstes Feld ({center.X}, {center.Y})..."
            });

            Win32Input.ClickAt(center.X, center.Y);
            if (options.PostClickDelayMs > 0)
            {
                await Task.Delay(options.PostClickDelayMs, cancellationToken);
            }
        }

        int totalChars = 0;
        foreach (var l in lines) totalChars += l.Length;
        int typedChars = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (options.ClearTargetFirst)
            {
                Win32Input.SendVirtualKey(VK_CONTROL);
                Win32Input.SendVirtualKey(VK_A);
                await Task.Delay(40, cancellationToken);
                Win32Input.SendVirtualKey(VK_BACK);
                await Task.Delay(40, cancellationToken);
            }

            string lineText = lines[i];
            for (int c = 0; c < lineText.Length; c++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Win32Input.SendUnicodeChar(lineText[c]);
                typedChars++;

                progress?.Report(new TypingProgress
                {
                    CurrentIndex = typedChars,
                    TotalLength = totalChars,
                    StatusMessage = $"Tippe Zeile {i + 1}/{lines.Length}..."
                });

                if (options.CharDelayMs > 0)
                {
                    await Task.Delay(options.CharDelayMs, cancellationToken);
                }
            }

            if (i < lines.Length - 1)
            {
                await Task.Delay(50, cancellationToken);
                Win32Input.SendVirtualKey(separatorVk);
                if (options.LineDelayMs > 0)
                {
                    await Task.Delay(options.LineDelayMs, cancellationToken);
                }
            }
        }
    }

    /// <summary>
    /// Types standard multi-line text into a single input field.
    /// </summary>
    private async Task TypeSingleFieldAsync(
        TargetArea target,
        string text,
        TypingOptions options,
        IProgress<TypingProgress>? progress,
        CancellationToken cancellationToken)
    {
        if (options.PerformFocusClick)
        {
            Point center = target.CenterPoint;
            progress?.Report(new TypingProgress
            {
                CurrentIndex = 0,
                TotalLength = text.Length,
                StatusMessage = $"Klicke auf Zielkoordinate ({center.X}, {center.Y})..."
            });

            Win32Input.ClickAt(center.X, center.Y);
            if (options.PostClickDelayMs > 0)
            {
                await Task.Delay(options.PostClickDelayMs, cancellationToken);
            }
        }

        if (options.ClearTargetFirst)
        {
            Win32Input.SendVirtualKey(VK_CONTROL);
            Win32Input.SendVirtualKey(VK_A);
            await Task.Delay(50, cancellationToken);
            Win32Input.SendVirtualKey(VK_BACK);
            await Task.Delay(50, cancellationToken);
        }

        int total = text.Length;
        for (int i = 0; i < total; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            char c = text[i];
            if (c == '\r')
            {
                if (i + 1 < total && text[i + 1] == '\n') continue;
                Win32Input.SendVirtualKey(VK_RETURN);
            }
            else if (c == '\n')
            {
                Win32Input.SendVirtualKey(VK_RETURN);
            }
            else if (c == '\t')
            {
                Win32Input.SendVirtualKey(VK_TAB);
            }
            else
            {
                Win32Input.SendUnicodeChar(c);
            }

            progress?.Report(new TypingProgress
            {
                CurrentIndex = i + 1,
                TotalLength = total,
                StatusMessage = $"Tippe Zeichen {i + 1} von {total} ({(int)(((i + 1) / (double)total) * 100)}%)..."
            });

            if (options.CharDelayMs > 0)
            {
                await Task.Delay(options.CharDelayMs, cancellationToken);
            }
        }
    }
}
