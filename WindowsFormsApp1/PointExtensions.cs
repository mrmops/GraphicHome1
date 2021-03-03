using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public static class PointExtensions
    {
        public static PointF Rotate(this Point startPoint, double angle)
        {
            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);
            var newX = startPoint.X * cos - startPoint.Y * sin;
            var newY = startPoint.X * sin + startPoint.Y * cos;
            var point = new PointF((float) newX, (float) newY);
            return point;
        }
    }
}