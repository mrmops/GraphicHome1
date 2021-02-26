using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Circle: IDrawable
    {
        public Point Center { get; set; }
        public int Radius { get; set; }

        public Color FillColor { get; set; }
        public Color StrokeColor { get; set; }
        public int Width { get; set; }
        
        public string Name { get; set; }

        public Circle(Point center, int radius, Color fillColor, Color strokeColor, int width, string name)
        {
            Center = center;
            Radius = radius;
            FillColor = fillColor;
            StrokeColor = strokeColor;
            Width = width;
            Name = name;
        }

        public IInput[] GetInputs()
        {
            throw new System.NotImplementedException();
        }

        public void Draw(Graphics g)
        {
            DrawFillCircle(g, FillColor, StrokeColor);
        }

        private void DrawFillCircle(Graphics g, Color fillColor, Color strokeColor)
        {
            
            var size = new Rectangle(Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            g.FillEllipse(new SolidBrush(fillColor), size);
            g.DrawEllipse(new Pen(strokeColor, Width), size);
            
            g.DrawString(Name, SystemFonts.DefaultFont, new SolidBrush(strokeColor), Center);
        }

        public void Hide(Graphics g, Color backColor)
        {
            DrawFillCircle(g, backColor, backColor);
        }
    }
}