using System.Windows;

namespace aDevLibStandard.Extensions
{
    public static class RectangleExtensions
    {
        public static Point Center(this Rect rect) => new Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
    }
}