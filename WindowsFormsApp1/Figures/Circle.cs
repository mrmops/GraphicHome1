using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Circle: Figure
    {
        protected override Point Center { get; set; }
        private int Radius { get; set; }
        private Color FillColor { get; set; }
        private Color StrokeColor { get; set; }
        private int Width { get; set; }
        private string Name { get; set; }

        public Circle(Point center, int radius, Color fillColor, Color strokeColor, int width, string name)
        {
            Center = center;
            Radius = radius;
            FillColor = fillColor;
            StrokeColor = strokeColor;
            Width = width;
            Name = name;
        }

        protected override void DrawFigure(Graphics g)
        {
            DrawFillCircle(g, FillColor, StrokeColor);
        }

        protected override void HideFigure(Graphics g, Color backColor)
        {
            DrawFillCircle(g, backColor, backColor);
        }

        private void DrawFillCircle(Graphics g, Color fillColor, Color strokeColor)
        {
            var size = new Rectangle(-Radius, -Radius, Radius * 2, Radius * 2);
            g.FillEllipse(new SolidBrush(fillColor), size);
            g.DrawEllipse(new Pen(strokeColor, Width), size);
            
            g.DrawString(Name, SystemFonts.DefaultFont, new SolidBrush(strokeColor), Center);
        }

    }
}