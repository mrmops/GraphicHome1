using System.Drawing;

namespace WindowsFormsApp1
{
    public class Line: Figure
    {
        protected override Point Center { get; set; }
        private Point LocalBeginPoint { get; set; }
        private Point LocalEndPoint { get; set; }
        private Color Color { get; set; }
        private int Width { get; set; }

        public Line(Point beginPoint, Point endPoint, Color color, int width)
        {
            Center = new Point((beginPoint.X + endPoint.X) / 2, (beginPoint.Y + endPoint.Y) / 2);
            LocalBeginPoint = TranslatePointToLocal(beginPoint);
            LocalEndPoint = TranslatePointToLocal(endPoint);
            Color = color;
            Width = width;
        }

        private Point TranslatePointToLocal(Point point)
        {
            return new Point(point.X - Center.X, point.Y - Center.Y);
        }


        protected override void DrawFigure(Graphics g)
        {
            g.DrawLine(new Pen(Color, Width), LocalBeginPoint, LocalEndPoint);
        }


        protected override void HideFigure(Graphics g, Color backColor)
        {
            g.DrawLine(new Pen(backColor, Width), LocalBeginPoint, LocalEndPoint);
        }
    }
}