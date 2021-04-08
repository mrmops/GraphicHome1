using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsApp1._3DFigures
{
    public class Cube: LineFigure3D
    {
        public Point3D Center { get; set; }
        public int Height { get; set; }

        private List<Line3D> _lines;

        public Cube(Color color, int width, Point3D center, int height) : base(color, width)
        {
            Center = center;
            Height = height;
            _lines = CreateLines().ToList();
        }

        private IEnumerable<Line3D> CreateLines()
        {
            var diagonal = Math.Sqrt(2 * Height * Height);
            var shift = diagonal / 2;
            var rotationXPositive = Matrix.CreateRotationMatrixX(Math.PI / 2);
            var rotationYPositive = Matrix.CreateRotationMatrixY(Math.PI / 2);
            var rotationXNegative = Matrix.CreateRotationMatrixX(-Math.PI / 2);
            var rotationYNegative = Matrix.CreateRotationMatrixY(-Math.PI / 2);
            for (int side = -2; side < 2; side++)
            {
                var prevPointXYLocation = new PointF((float) shift, 0).Rotate(side * Math.PI / 2 + Math.PI / 4);
                var previousPoint = new Point3D(prevPointXYLocation.X, prevPointXYLocation.Y, Height / 2.0);
                for (int point = 0; point < 3; point++)
                {
                    if (side % 2 == 0)
                    {
                        
                        var newPoint =  (side >= 0 
                            ? rotationXPositive
                            : rotationXNegative) * previousPoint;
                        yield return new Line3D(previousPoint + Center, newPoint + Center);
                        previousPoint = newPoint;
                    }
                    else
                    {
                        var newPoint =  (side >= 0 
                            ? rotationYPositive
                            : rotationYNegative) * previousPoint;
                        yield return new Line3D(previousPoint + Center, newPoint + Center);
                        previousPoint = newPoint;
                    }
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