using System.Drawing;

namespace WindowsFormsApp1
{
    public class Line: IDrawable
    {
        public Point BeginPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        public int FontSize { get; set; }

        public Line(Point beginPoint, Point endPoint, Color color, int fontSize)
        {
            BeginPoint = beginPoint;
            EndPoint = endPoint;
            Color = color;
            FontSize = fontSize;
        }

        public void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Color, FontSize), BeginPoint, EndPoint);
        }
        

        public void Hide(Graphics g, Color bachColor)
        {
            g.DrawLine(new Pen(bachColor, FontSize), BeginPoint, EndPoint);
        }
    }
}