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
        
        public static PointF Rotate(this PointF startPoint, double angle)
        {
            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);
            var newX = startPoint.X * cos - startPoint.Y * sin;
            var newY = startPoint.X * sin + startPoint.Y * cos;
            var point = new PointF((float) newX, (float) newY);
            return point;
        }
        
        public static Point ToPoint(this PointF startPoint)
        {
            return new Point((int) startPoint.X, (int) startPoint.Y);
        }
        
        public static Point ToPoint3D(this Point startPoint, int z)
        {
            return new Point((int) startPoint.X, (int) startPoint.Y);
        }
    }
}