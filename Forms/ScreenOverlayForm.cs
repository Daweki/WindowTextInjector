using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using WindowTextInjector.Models;
using WindowTextInjector.Native;

namespace WindowTextInjector.Forms;

public class ScreenOverlayForm : Form
{
    private Bitmap? _screenSnapshot;
    private Point _startScreenPos;
    private Point _currentScreenPos;
    private bool _isSelecting = false;
    private readonly int _virtLeft;
    private readonly int _virtTop;
    private readonly int _virtWidth;
    private readonly int _virtHeight;
    private readonly int _expectedLineCount;
    private readonly bool _showRowDividers;

    public TargetArea? SelectedTarget { get; private set; }

    public ScreenOverlayForm(int expectedLineCount = 1, bool showRowDividers = false)
    {
        _expectedLineCount = Math.Max(1, expectedLineCount);
        _showRowDividers = showRowDividers && _expectedLineCount > 1;

        // Use exact Win32 virtual screen metrics for multi-monitor / high-DPI
        _virtLeft = Win32Input.GetSystemMetrics(Win32Input.SM_XVIRTUALSCREEN);
        _virtTop = Win32Input.GetSystemMetrics(Win32Input.SM_YVIRTUALSCREEN);
        _virtWidth = Win32Input.GetSystemMetrics(Win32Input.SM_CXVIRTUALSCREEN);
        _virtHeight = Win32Input.GetSystemMetrics(Win32Input.SM_CYVIRTUALSCREEN);

        FormBorderStyle = FormBorderStyle.None;
        StartPosition = FormStartPosition.Manual;
        Location = new Point(_virtLeft, _virtTop);
        Size = new Size(_virtWidth, _virtHeight);
        TopMost = true;
        ShowInTaskbar = false;
        DoubleBuffered = true;
        Cursor = Cursors.Cross;
        KeyPreview = true;

        CaptureScreenSnapshot();
    }

    private void CaptureScreenSnapshot()
    {
        try
        {
            _screenSnapshot = new Bitmap(_virtWidth, _virtHeight, PixelFormat.Format32bppArgb);
            using Graphics g = Graphics.FromImage(_screenSnapshot);
            g.CopyFromScreen(_virtLeft, _virtTop, 0, 0, new Size(_virtWidth, _virtHeight), CopyPixelOperation.SourceCopy);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to capture screen snapshot: {ex.Message}");
        }
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (e.KeyCode == Keys.Escape)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left)
        {
            _isSelecting = true;
            _startScreenPos = Cursor.Position;
            _currentScreenPos = Cursor.Position;
            Invalidate();
        }
        else if (e.Button == MouseButtons.Right)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (_isSelecting)
        {
            _currentScreenPos = Cursor.Position;
            Invalidate();
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        if (_isSelecting)
        {
            _isSelecting = false;
            _currentScreenPos = Cursor.Position;

            // Compute absolute physical screen rectangle directly from Cursor.Position
            Rectangle absoluteScreenRect = GetNormalizedRectangle(_startScreenPos, _currentScreenPos);

            // If user just clicked without dragging, make a 32x24 rectangle around the click
            if (absoluteScreenRect.Width < 6 || absoluteScreenRect.Height < 6)
            {
                absoluteScreenRect = new Rectangle(
                    _currentScreenPos.X - 16,
                    _currentScreenPos.Y - 12,
                    32,
                    24
                );
            }

            // Crop thumbnail from the snapshot (offset by virtual screen top-left)
            Bitmap? thumbnail = null;
            if (_screenSnapshot != null)
            {
                Rectangle snapshotCropRect = new(
                    absoluteScreenRect.Left - _virtLeft,
                    absoluteScreenRect.Top - _virtTop,
                    absoluteScreenRect.Width,
                    absoluteScreenRect.Height
                );

                snapshotCropRect = Rectangle.Intersect(
                    new Rectangle(0, 0, _screenSnapshot.Width, _screenSnapshot.Height),
                    snapshotCropRect
                );

                if (snapshotCropRect.Width > 0 && snapshotCropRect.Height > 0)
                {
                    thumbnail = new Bitmap(snapshotCropRect.Width, snapshotCropRect.Height);
                    using Graphics g = Graphics.FromImage(thumbnail);
                    g.DrawImage(_screenSnapshot, new Rectangle(0, 0, snapshotCropRect.Width, snapshotCropRect.Height), snapshotCropRect, GraphicsUnit.Pixel);

                    if (_showRowDividers)
                    {
                        using Pen rowPen = new(Color.FromArgb(180, 0, 210, 255), 1f) { DashStyle = DashStyle.Dash };
                        double rowH = (double)snapshotCropRect.Height / _expectedLineCount;
                        for (int i = 1; i < _expectedLineCount; i++)
                        {
                            int y = (int)(i * rowH);
                            g.DrawLine(rowPen, 0, y, snapshotCropRect.Width, y);
                        }
                    }
                }
            }

            // Detect window and process at the exact center of the selection
            Point centerScreenPoint = new(
                absoluteScreenRect.Left + absoluteScreenRect.Width / 2,
                absoluteScreenRect.Top + absoluteScreenRect.Height / 2
            );

            var winInfo = Win32Input.GetWindowAtScreenPoint(centerScreenPoint, new[] { Handle });

            SelectedTarget = new TargetArea
            {
                Bounds = absoluteScreenRect,
                WindowHandle = winInfo.Handle,
                WindowTitle = winInfo.Title,
                ProcessName = winInfo.ProcessName,
                ThumbnailPreview = thumbnail,
                CapturedAt = DateTime.Now
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }

    private static Rectangle GetNormalizedRectangle(Point p1, Point p2)
    {
        int x = Math.Min(p1.X, p2.X);
        int y = Math.Min(p1.Y, p2.Y);
        int width = Math.Max(1, Math.Abs(p1.X - p2.X));
        int height = Math.Max(1, Math.Abs(p1.Y - p2.Y));
        return new Rectangle(x, y, width, height);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        // 1. Draw base screen snapshot
        if (_screenSnapshot != null)
        {
            g.DrawImageUnscaled(_screenSnapshot, 0, 0);
        }
        else
        {
            g.Clear(Color.Black);
        }

        // Convert current screen selection coordinates to local form client coordinates
        Point localStart = PointToClient(_startScreenPos);
        Point localCurrent = PointToClient(_currentScreenPos);
        Rectangle localRect = GetNormalizedRectangle(localStart, localCurrent);

        // 2. Draw darkened overlay mask
        using (SolidBrush darkBrush = new(Color.FromArgb(130, 15, 23, 42)))
        {
            if (_isSelecting)
            {
                using Region region = new(new Rectangle(0, 0, Width, Height));
                region.Exclude(localRect);
                g.FillRegion(darkBrush, region);
            }
            else
            {
                g.FillRectangle(darkBrush, 0, 0, Width, Height);
            }
        }

        // 3. Top instruction banner
        string topText = _showRowDividers
            ? $"🎯 Ziehe ein Rechteck über die {_expectedLineCount} Zeilen / Textfelder  |  [Esc] zum Abbrechen"
            : "🎯 Ziehe mit der Maus ein Rechteck über die gewünschte Textbox  |  [Esc] zum Abbrechen";

        using (Font bannerFont = new("Segoe UI", 11.5f, FontStyle.Bold))
        {
            SizeF bannerSize = g.MeasureString(topText, bannerFont);
            int bannerWidth = (int)bannerSize.Width + 40;
            int bannerHeight = (int)bannerSize.Height + 16;
            int bannerX = (Width - bannerWidth) / 2;
            int bannerY = 30;

            Rectangle bannerRect = new(bannerX, bannerY, bannerWidth, bannerHeight);
            using GraphicsPath bannerPath = GetRoundedRectangle(bannerRect, 10);
            using SolidBrush bannerBg = new(Color.FromArgb(230, 20, 30, 50));
            using Pen bannerBorder = new(Color.FromArgb(0, 180, 255), 1.5f);
            using SolidBrush bannerTextBrush = new(Color.White);

            g.FillPath(bannerBg, bannerPath);
            g.DrawPath(bannerBorder, bannerPath);

            StringFormat sf = new()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(topText, bannerFont, bannerTextBrush, bannerRect, sf);
        }

        // 4. Selection rectangle & markers
        if (_isSelecting)
        {
            // Outer neon border
            using (Pen borderPen = new(Color.FromArgb(0, 210, 255), 2f))
            {
                g.DrawRectangle(borderPen, localRect);
            }

            // Inner subtle dashed border
            using (Pen dashPen = new(Color.White, 1f))
            {
                dashPen.DashStyle = DashStyle.Dot;
                Rectangle innerRect = new(localRect.X + 1, localRect.Y + 1, Math.Max(1, localRect.Width - 2), Math.Max(1, localRect.Height - 2));
                g.DrawRectangle(dashPen, innerRect);
            }

            // Multi-row guides if enabled
            if (_showRowDividers && localRect.Height > 10)
            {
                double rowHeight = (double)localRect.Height / _expectedLineCount;
                using Pen rowDividerPen = new(Color.FromArgb(220, 56, 189, 248), 1.5f) { DashStyle = DashStyle.Dash };
                using Font rowFont = new("Segoe UI", 8.5f, FontStyle.Bold);
                using SolidBrush rowBadgeBg = new(Color.FromArgb(200, 15, 23, 42));
                using SolidBrush rowBadgeText = new(Color.FromArgb(56, 189, 248));
                using Pen rowBadgeBorder = new(Color.FromArgb(56, 189, 248), 1f);

                for (int i = 0; i < _expectedLineCount; i++)
                {
                    int rowY = localRect.Top + (int)(i * rowHeight);
                    int rowCenterY = localRect.Top + (int)((i + 0.5) * rowHeight);

                    if (i > 0)
                    {
                        g.DrawLine(rowDividerPen, localRect.Left, rowY, localRect.Right, rowY);
                    }

                    Rectangle badge = new(localRect.Left + 4, rowCenterY - 9, 22, 18);
                    g.FillRectangle(rowBadgeBg, badge);
                    g.DrawRectangle(rowBadgeBorder, badge);
                    StringFormat bsf = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString($"{i + 1}", rowFont, rowBadgeText, badge, bsf);

                    using Pen ptPen = new(Color.FromArgb(255, 60, 90), 2f);
                    int rowCenterX = localRect.Left + localRect.Width / 2;
                    g.DrawLine(ptPen, rowCenterX - 4, rowCenterY, rowCenterX + 4, rowCenterY);
                    g.DrawLine(ptPen, rowCenterX, rowCenterY - 4, rowCenterX, rowCenterY + 4);
                }
            }
            else
            {
                // Single center crosshair
                Point center = new(localRect.X + localRect.Width / 2, localRect.Y + localRect.Height / 2);
                using (Pen crossPen = new(Color.FromArgb(255, 60, 90), 2f))
                {
                    g.DrawLine(crossPen, center.X - 8, center.Y, center.X + 8, center.Y);
                    g.DrawLine(crossPen, center.X, center.Y - 8, center.X, center.Y + 8);
                    g.DrawEllipse(crossPen, center.X - 4, center.Y - 4, 8, 8);
                }
            }

            // Info badge near cursor
            Rectangle absRect = GetNormalizedRectangle(_startScreenPos, _currentScreenPos);
            Point absCenter = new(absRect.Left + absRect.Width / 2, absRect.Top + absRect.Height / 2);
            string badgeText = _showRowDividers
                ? $"Ziel: {absRect.Width} × {absRect.Height} px  ({_expectedLineCount} Zeilen-Slots)"
                : $"Ziel: {absRect.Width} × {absRect.Height} px  |  Mitte: ({absCenter.X}, {absCenter.Y})";

            using Font badgeFont = new("Segoe UI", 9.5f, FontStyle.Bold);
            SizeF badgeSize = g.MeasureString(badgeText, badgeFont);
            int badgeW = (int)badgeSize.Width + 18;
            int badgeH = (int)badgeSize.Height + 10;

            int badgeX = localRect.Right + 12;
            int badgeY = localRect.Bottom + 12;

            if (badgeX + badgeW > Width - 10) badgeX = localRect.Left - badgeW - 12;
            if (badgeY + badgeH > Height - 10) badgeY = localRect.Top - badgeH - 12;
            if (badgeX < 10) badgeX = 10;
            if (badgeY < 10) badgeY = 10;

            Rectangle badgeRect = new(badgeX, badgeY, badgeW, badgeH);
            using GraphicsPath badgePath = GetRoundedRectangle(badgeRect, 6);
            using SolidBrush badgeBg = new(Color.FromArgb(230, 15, 23, 42));
            using Pen badgeBorder = new(Color.FromArgb(0, 210, 255), 1.2f);
            using SolidBrush badgeTextBrush = new(Color.FromArgb(240, 246, 252));

            g.FillPath(badgeBg, badgePath);
            g.DrawPath(badgeBorder, badgePath);

            StringFormat bsf2 = new()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(badgeText, badgeFont, badgeTextBrush, badgeRect, bsf2);
        }
    }

    private static GraphicsPath GetRoundedRectangle(Rectangle bounds, int radius)
    {
        GraphicsPath path = new();
        int diameter = radius * 2;
        Rectangle arc = new(bounds.Location, new Size(diameter, diameter));

        path.AddArc(arc, 180, 90);
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);

        path.CloseFigure();
        return path;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _screenSnapshot?.Dispose();
            _screenSnapshot = null;
        }
        base.Dispose(disposing);
    }
}
