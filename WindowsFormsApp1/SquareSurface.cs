using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using WindowsFormsApp1._3DFigures;

namespace WindowsFormsApp1
{
    public class SquareSurface: LineFigure3D
    {
        private int _size;
        private Point3D _center;
        private readonly List<Line3D> _lines;

        public SquareSurface(int size, Point3D center, Color color, int width) : base(color, width)
        {
            _size = size;
            _center = center;
            _lines = GenerateLines(20).ToList();
        }

        private IEnumerable<Line3D> GenerateLines(int count)
        {
            var step = _size / count;
            for (int i = 0; i < _size; i += step)
            {
                yield return new Line3D(new Point3D(i, 0, _center.Z), new Point3D(i, _size, _center.Z));
                yield return new Line3D(new Point3D(0, i, _center.Z), new Point3D(_size, i, _center.Z));
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