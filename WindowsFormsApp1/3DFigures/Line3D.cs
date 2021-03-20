using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1._3DFigures
{
    public class Line3D: LineFigure3D
    {
        public Point3D Start;
        public Point3D End;
        public Color Color;
        public int Width;

        public Line3D(Point3D start, Point3D end, Color color, int width)
        {
            Start = start;
            End = end;
            Color = color;
            Width = width;
        }

        protected override IEnumerable<Line3D> GetLines()
        {
            yield return this;
        }

        protected override Point3D GetCenter()
        {
            return new Point3D((Start.X + End.X) / 2, (Start.Y + Start.Y) / 2, (Start.Z + Start.Z) / 2);
        }
    }
}