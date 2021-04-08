using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsApp1._3DFigures
{
    public class Surface : LineFigure3D
    {
        private Point3D _center;
        private List<Line3D> _lines;
        private readonly int _step;
        private readonly Func<double, double, double> _func;

        public Surface(Point3D center, int step, Func<double, double, double> func, Color color, int width) : base(
            color, width)
        {
            _center = center;
            _step = step;
            this._func = func;
            _lines = CreateLines().ToList();
        }

        private IEnumerable<Line3D> CreateLines()
        {
            int countSteps = (int) (1000.0 / _step + 1);
            var values = new double[countSteps, countSteps];
            for (var x = 0; x < countSteps; x++)
            {
                for (var y = 0; y < countSteps; y++)
                {
                    values[x, y] = _func(x * _step , y * _step);
                }
            }

            for (var x = 0; x < values.GetLength(0); x++)
            {
                for (var y = 0; y < values.GetLength(1); y++)
                {
                    if (x != 0)
                    {
                        var prevX = (x - 1);
                        yield return new Line3D(
                            new Point3D(x * _step, y * _step, values[x, y]),
                            new Point3D(prevX * _step, y * _step, values[prevX, y])
                        );
                    }

                    if (y != 0)
                    {
                        var prevY = (y - 1);
                        yield return new Line3D(
                            new Point3D(x * _step, y * _step, values[x, y]),
                            new Point3D(x * _step, prevY * _step, values[x, prevY])
                        );
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
            return _center;
        }
    }
}