using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsApp1
{
    public class CustomPolygon: Figure
    {
        protected override Point Center { get; set; }
        private Point[] _points;
        private Color _color;
        private Color _fillColor;
        private int _width;

        public CustomPolygon(List<Point> points, Color color, int width, Color fillColor)
        {
            Center = FindCenter(points);
            _points = TranslatePoints(points);
            _color = color;
            this._width = width;
            _fillColor = fillColor;
        }

        private Point[] TranslatePoints(List<Point> points)
        {
            return points.Select(point => new Point(point.X - Center.X, point.Y - Center.Y)).ToArray();
        }

        private Point FindCenter(List<Point> points)
        {
            var sumX = 0;
            var sumY = 0;
            foreach (var point in points)
            {
                sumX += point.X;
                sumY += point.Y;
            }

            return new Point(sumX / points.Count, sumY / points.Count);
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
            
            SolidBrush br=new SolidBrush(_fillColor);
            g.DrawPolygon(new Pen(color, _width), _points);
            g.FillPolygon(br, _points);
        }
    }
}