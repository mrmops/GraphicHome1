using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsApp1._3DFigures
{
    public class Spiral: LineFigure3D
    {
        private double _angleYx;
        private int _stepPerTurn;
        private int _radius;
        private int _turnsCount;
        private Point3D _center;

        private List<Line3D> _lines;

        public Spiral(double angleYx, int stepPerTurn, int radius, int turnsCount, Point3D center, Color color, int width) : base(color, width)
        {
            _angleYx = angleYx;
            _stepPerTurn = stepPerTurn;
            _radius = radius;
            _turnsCount = turnsCount;
            _center = center;
            _lines = CreateLines().ToList();
        }

        private IEnumerable<Line3D> CreateLines()
        {
            var countStepsPerTurn =  Math.PI * 2 / _angleYx;
            var turnsCount = _turnsCount * countStepsPerTurn;
            var countSteps = turnsCount;
            var stepZ = _stepPerTurn / countStepsPerTurn;
            var startPoint = new PointF(_radius, 0);
            var previousPoint = new Point3D(startPoint.X + _center.X, startPoint.Y + _center.Y, _center.Z);
            for (var step = 0; step < countSteps; step++)
            {
                var totalAngle = step * _angleYx;
                var rotatedPoint = startPoint.Rotate(totalAngle);
                var newPoint = new Point3D(rotatedPoint.X + _center.X, rotatedPoint.Y + _center.Y, _center.Z + stepZ * step);
                yield return new Line3D(previousPoint, newPoint);
                previousPoint = newPoint;
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