using System;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class NormalPolygon : Figure
    {
        protected override Point Center { get; set; }
        private readonly int _angleCount;
        private readonly int _radius;
        private readonly int _width;
        private readonly Color _color;

        public NormalPolygon(Point location, int angleCount, int radius, int width, Color color)
        {
            Center = location;
            _angleCount = angleCount;
            _radius = radius;
            _color = color;
            _width = width;
        }

        protected override void DrawFigure(Graphics g)
        {
            DrawMe(g, _color);
        }

        protected override void HideFigure(Graphics g, Color backColor)
        {
            DrawMe(g, backColor);
        }

        private void DrawMe(Graphics g, Color color)
        {
            var points = new List<PointF>();
            var angle = 2 * Math.PI / _angleCount;
            var startPoint = new Point(_radius, 0);
            for (var i = 1; i <= _angleCount; i++)
            {
                var point = startPoint.Rotate(angle * i);
                points.Add(point);
            }

            g.DrawPolygon(new Pen(color, _width), points.ToArray());
        }
    }
}