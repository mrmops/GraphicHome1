using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsApp1
{
    public class CustomPolygon: IDrawable
    {
        private List<Point> _points;
        private Color _color;
        private int _width;

        public CustomPolygon(List<Point> points, Color color, int width)
        {
            _points = points;
            _color = color;
            this._width = width;
        }

        public void Draw(Graphics g)
        {
            DrawMe(g, _color);
        }

        public void Hide(Graphics g, Color backColor)
        {
            DrawMe(g, backColor);
        }

        private void DrawMe(Graphics g, Color color)
        {
            g.DrawPolygon(new Pen(color, _width), _points.ToArray());
        }
    }
}