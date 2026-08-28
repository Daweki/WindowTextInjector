using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowTextInjector.Native;

public static class Win32Input
{
    public const int INPUT_MOUSE = 0;
    public const int INPUT_KEYBOARD = 1;

    public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
    public const uint KEYEVENTF_KEYUP = 0x0002;
    public const uint KEYEVENTF_UNICODE = 0x0004;
    public const uint KEYEVENTF_SCANCODE = 0x0008;

    public const uint MOUSEEVENTF_MOVE = 0x0001;
    public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
    public const uint MOUSEEVENTF_LEFTUP = 0x0004;
    public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
    public const uint MOUSEEVENTF_RIGHTUP = 0x0010;
    public const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

    public const int SM_XVIRTUALSCREEN = 76;
    public const int SM_YVIRTUALSCREEN = 77;
    public const int SM_CXVIRTUALSCREEN = 78;
    public const int SM_CYVIRTUALSCREEN = 79;

    public const int MOD_ALT = 0x0001;
    public const int MOD_CONTROL = 0x0002;
    public const int MOD_SHIFT = 0x0004;
    public const int MOD_WIN = 0x0008;
    public const int MOD_NOREPEAT = 0x4000;

    public const int WM_HOTKEY = 0x0312;
    public const int SW_RESTORE = 9;
    public const int SW_SHOW = 5;

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct INPUT_UNION
    {
        [FieldOffset(0)]
        public MOUSEINPUT mi;

        [FieldOffset(0)]
        public KEYBDINPUT ki;

        [FieldOffset(0)]
        public HARDWAREINPUT hi;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        public int type;
        public INPUT_UNION u;
    }

    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll")]
    public static extern bool GetCursorPos(out POINT lpPoint);

    [DllImport("user32.dll")]
    public static extern int GetSystemMetrics(int nIndex);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    [DllImport("user32.dll")]
    public static extern IntPtr WindowFromPoint(POINT Point);

    [DllImport("user32.dll")]
    public static extern IntPtr GetAncestor(IntPtr hwnd, uint gaFlags);

    public const uint GA_ROOT = 2;
    public const uint GA_ROOTOWNER = 3;

    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool BringWindowToTop(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    [DllImport("kernel32.dll")]
    public static extern uint GetCurrentThreadId();

    [DllImport("user32.dll")]
    public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

    [DllImport("user32.dll")]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [DllImport("user32.dll")]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll")]
    public static extern bool IsWindowVisible(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool IsIconic(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern int GetWindowTextLength(IntPtr hWnd);

    public class DetectedWindowInfo
    {
        public IntPtr Handle { get; set; } = IntPtr.Zero;
        public string Title { get; set; } = string.Empty;
        public string ProcessName { get; set; } = string.Empty;
        public uint ProcessId { get; set; }
    }

    /// <summary>
    /// Enumerates visible windows in Z-order to find the actual target window beneath the given screen point,
    /// automatically excluding our own application windows (like the overlay).
    /// </summary>
    public static DetectedWindowInfo GetWindowAtScreenPoint(Point pt, IntPtr[]? excludeWindows = null)
    {
        uint currentPid = (uint)Environment.ProcessId;
        IntPtr foundHwnd = IntPtr.Zero;
        string foundTitle = string.Empty;
        string foundProcess = string.Empty;
        uint foundPid = 0;

        EnumWindows((hWnd, lParam) =>
        {
            if (excludeWindows != null && Array.IndexOf(excludeWindows, hWnd) >= 0)
            {
                return true; // continue enumeration
            }

            GetWindowThreadProcessId(hWnd, out uint pid);
            if (pid == currentPid)
            {
                return true; // ignore our own app windows
            }

            if (!IsWindowVisible(hWnd) || IsIconic(hWnd))
            {
                return true;
            }

            if (GetWindowRect(hWnd, out RECT rect))
            {
                if (pt.X >= rect.Left && pt.X < rect.Right && pt.Y >= rect.Top && pt.Y < rect.Bottom)
                {
                    int width = rect.Right - rect.Left;
                    int height = rect.Bottom - rect.Top;
                    if (width <= 0 || height <= 0) return true;

                    StringBuilder sbClass = new(256);
                    GetClassName(hWnd, sbClass, sbClass.Capacity);
                    string className = sbClass.ToString();

                    // Skip common invisible overlay classes if any
                    if (className is "Shell_TrayWnd" or "Progman" or "WorkerW")
                    {
                        // Save as fallback if no real app window is found
                        if (foundHwnd == IntPtr.Zero)
                        {
                            foundHwnd = hWnd;
                            foundTitle = "Windows Desktop";
                            foundProcess = "explorer";
                            foundPid = pid;
                        }
                        return true;
                    }

                    StringBuilder sbTitle = new(512);
                    GetWindowText(hWnd, sbTitle, sbTitle.Capacity);
                    string title = sbTitle.ToString();

                    string procName = string.Empty;
                    try
                    {
                        using System.Diagnostics.Process proc = System.Diagnostics.Process.GetProcessById((int)pid);
                        procName = proc.ProcessName;
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            title = proc.MainWindowTitle;
                        }
                    }
                    catch
                    {
                        procName = $"PID {pid}";
                    }

                    foundHwnd = hWnd;
                    foundTitle = string.IsNullOrWhiteSpace(title) ? className : title;
                    foundProcess = procName;
                    foundPid = pid;

                    return false; // Found topmost target window, stop enumeration
                }
            }

            return true;
        }, IntPtr.Zero);

        return new DetectedWindowInfo
        {
            Handle = foundHwnd,
            Title = string.IsNullOrWhiteSpace(foundTitle) ? "Unbekanntes Fenster" : foundTitle,
            ProcessName = string.IsNullOrWhiteSpace(foundProcess) ? "Unbekannter Prozess" : foundProcess,
            ProcessId = foundPid
        };
    }

    /// <summary>
    /// Sends a low-level hardware mouse click at the given absolute screen coordinates.
    /// </summary>
    public static void ClickAt(int x, int y)
    {
        SetCursorPos(x, y);
        System.Threading.Thread.Sleep(30);

        int virtLeft = GetSystemMetrics(SM_XVIRTUALSCREEN);
        int virtTop = GetSystemMetrics(SM_YVIRTUALSCREEN);
        int virtWidth = Math.Max(1, GetSystemMetrics(SM_CXVIRTUALSCREEN));
        int virtHeight = Math.Max(1, GetSystemMetrics(SM_CYVIRTUALSCREEN));

        int normX = (int)((x - virtLeft) * 65535.0 / (virtWidth - 1));
        int normY = (int)((y - virtTop) * 65535.0 / (virtHeight - 1));

        INPUT[] inputs = new INPUT[2];

        inputs[0] = new INPUT
        {
            type = INPUT_MOUSE,
            u = new INPUT_UNION
            {
                mi = new MOUSEINPUT
                {
                    dx = normX,
                    dy = normY,
                    dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            }
        };

        inputs[1] = new INPUT
        {
            type = INPUT_MOUSE,
            u = new INPUT_UNION
            {
                mi = new MOUSEINPUT
                {
                    dx = normX,
                    dy = normY,
                    dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTUP,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
    }

    /// <summary>
    /// Sends a single character as a simulated keyboard event via KEYEVENTF_UNICODE.
    /// Works with any unicode character across RDP, consoles, VMs and GUI controls.
    /// </summary>
    public static void SendUnicodeChar(char c)
    {
        INPUT[] inputs = new INPUT[2];

        // Key Down
        inputs[0] = new INPUT
        {
            type = INPUT_KEYBOARD,
            u = new INPUT_UNION
            {
                ki = new KEYBDINPUT
                {
                    wVk = 0,
                    wScan = c,
                    dwFlags = KEYEVENTF_UNICODE,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            }
        };

        // Key Up
        inputs[1] = new INPUT
        {
            type = INPUT_KEYBOARD,
            u = new INPUT_UNION
            {
                ki = new KEYBDINPUT
                {
                    wVk = 0,
                    wScan = c,
                    dwFlags = KEYEVENTF_UNICODE | KEYEVENTF_KEYUP,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
    }

    /// <summary>
    /// Sends a virtual key event (e.g. Return, Tab, Backspace).
    /// </summary>
    public static void SendVirtualKey(ushort vk)
    {
        INPUT[] inputs = new INPUT[2];

        // Key Down
        inputs[0] = new INPUT
        {
            type = INPUT_KEYBOARD,
            u = new INPUT_UNION
            {
                ki = new KEYBDINPUT
                {
                    wVk = vk,
                    wScan = 0,
                    dwFlags = 0,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            }
        };

        // Key Up
        inputs[1] = new INPUT
        {
            type = INPUT_KEYBOARD,
            u = new INPUT_UNION
            {
                ki = new KEYBDINPUT
                {
                    wVk = vk,
                    wScan = 0,
                    dwFlags = KEYEVENTF_KEYUP,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
    }

    /// <summary>
    /// Attempts to bring a window to foreground using AttachThreadInput technique to bypass Windows focus restrictions.
    /// </summary>
    public static void ForceForegroundWindow(IntPtr hWnd)
    {
        if (hWnd == IntPtr.Zero) return;

        IntPtr rootHwnd = GetAncestor(hWnd, GA_ROOT);
        if (rootHwnd == IntPtr.Zero) rootHwnd = hWnd;

        ShowWindowAsync(rootHwnd, SW_RESTORE);

        uint targetThread = GetWindowThreadProcessId(rootHwnd, out _);
        uint currentThread = GetCurrentThreadId();

        if (targetThread != currentThread)
        {
            AttachThreadInput(currentThread, targetThread, true);
            SetForegroundWindow(rootHwnd);
            BringWindowToTop(rootHwnd);
            AttachThreadInput(currentThread, targetThread, false);
        }
        else
        {
            SetForegroundWindow(rootHwnd);
            BringWindowToTop(rootHwnd);
        }
    }
}
