using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class NormalPolygon: IDrawable
    {
        private Point _location;
        private readonly int _angleCount;
        private readonly int _radius;
        private readonly int _width;
        private readonly Color _color;

        public NormalPolygon(Point location, int angleCount, int radius, int width, Color color)
        {
            _angleCount = angleCount;
            _radius = radius;
            _color = color;
            _width = width;
            _location = location;
        }

        public void Draw(Graphics g)
        {
            DrawMe(g, _color);
        }

        private void DrawMe(Graphics g, Color color)
        {
            var points = new List<PointF>();
            var angle = 2 * Math.PI /  _angleCount;
            var startPoint = new Point(_radius, 0);
            for (var i = 1; i <= _angleCount; i++)
            {
                var point = RotatePoint(angle * i, startPoint);
                points.Add(point);
            }
            g.DrawPolygon(new Pen(color, _width), points.ToArray());
        }

        private PointF RotatePoint(double angle, Point startPoint)
        {
            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);
            var newX = startPoint.X * cos - startPoint.Y * sin;
            var newY = startPoint.X * sin + startPoint.Y * cos;
            var point = new PointF((float) (newX + _location.X), (float) (newY + _location.Y));
            return point;
        }

        public void Hide(Graphics g, Color backColor)
        {
            DrawMe(g, backColor);
        }
    }
}