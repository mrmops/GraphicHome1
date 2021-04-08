using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsApp1._3DFigures
{
    public class Sphere: LineFigure3D
    {
        public Point3D Center { get; private set; }
        public double Radius { get; private set; }
        public int CountVerticalSegments { get; private set; }
        public int CountHorizontalSegments { get; private set; }

        private List<Line3D> _lines;

        public Sphere(Point3D center, double radius, int countVerticalSegments, int countHorizontalSegments,
            Color color, int width) : base(color, width)
        {
            Center = center;
            Radius = radius;
            CountVerticalSegments = countVerticalSegments;
            CountHorizontalSegments = countHorizontalSegments;
            _lines = CreateLines().ToList();
        }

        private IEnumerable<Line3D> CreateLines()
        {
           
            for (int horStep = 0; horStep < CountHorizontalSegments; horStep++)
            {
                var horizontalRotation = Matrix.CreateRotationMatrixZ(Math.PI * 2d * horStep / (double)CountHorizontalSegments);
                var previousPoint = new Point3D(Center.X, Center.Y, Center.Z + Radius);
                for (int verStep = 1; verStep <= CountVerticalSegments; verStep++)
                {
                    var verticalRotation = Matrix.CreateRotationMatrixX(Math.PI * verStep / (double)CountVerticalSegments);
                    var newPoint = verticalRotation * new Point3D(0, 0, Radius);
                    newPoint = horizontalRotation * newPoint;
                    newPoint = new Point3D(Center.X + newPoint.X, Center.Y + newPoint.Y, Center.Z + newPoint.Z);
                    yield return new Line3D(previousPoint, newPoint);
                    previousPoint = newPoint;
                }
            }
        }

        protected override IEnumerable<Line3D> GetLines()
        {
            return _lines;
        }

        protected override Point3D GetCenter()
        {
            return Center;
        }
    }
}