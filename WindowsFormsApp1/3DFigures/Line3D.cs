using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace WindowsFormsApp1._3DFigures
{
    public class Line3D
    {
        public Point3D Start;
        public Point3D End;
        public Line3D(Point3D start, Point3D end)
        {
            Start = start;
            End = end;
        }
    }
}