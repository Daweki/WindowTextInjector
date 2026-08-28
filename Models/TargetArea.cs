using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowTextInjector.Models;

public class TargetArea : IDisposable
{
    public Rectangle Bounds { get; set; }
    public Point CenterPoint => new(Bounds.Left + Bounds.Width / 2, Bounds.Top + Bounds.Height / 2);
    public IntPtr WindowHandle { get; set; }
    public string WindowTitle { get; set; } = string.Empty;
    public string ProcessName { get; set; } = string.Empty;
    public Bitmap? ThumbnailPreview { get; set; }
    public DateTime CapturedAt { get; set; } = DateTime.Now;

    /// <summary>
    /// Divides the target rectangle vertically into N equal row slots and returns the center point for each row.
    /// </summary>
    public List<Point> GetRowCenterPoints(int rowCount)
    {
        List<Point> points = new();
        if (rowCount <= 1 || Bounds.Height <= 0)
        {
            points.Add(CenterPoint);
            return points;
        }

        int centerX = Bounds.Left + Bounds.Width / 2;
        double rowHeight = (double)Bounds.Height / rowCount;

        for (int i = 0; i < rowCount; i++)
        {
            int centerY = Bounds.Top + (int)((i + 0.5) * rowHeight);
            points.Add(new Point(centerX, centerY));
        }

        return points;
    }

    public void Dispose()
    {
        ThumbnailPreview?.Dispose();
        ThumbnailPreview = null;
        GC.SuppressFinalize(this);
    }
}
