﻿using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class Figure: IDrawable
    {
        private float _scale = 1f;
        private double _rotationAngle = 0;
        private Point _rotationCenter;

        public override string ToString()
        {
            return GetType().Name;
        }

        public void Update(Graphics g)
        {
            TransformDrawAndResetTransform(g, DrawFigure);
        }

        public void Hide(Graphics g, Color backColor)
        {
            TransformDrawAndResetTransform(g, graphics => HideFigure(graphics, backColor));
        }

        public void Scale(float scaleValue)
        {
            _scale = scaleValue;
        }

        public void Rotate(int angle, Point? rotationCenter)
        {
            _rotationAngle = angle;
            _rotationCenter = rotationCenter ?? Center;
        }

        public Animator? _animator { get; set; }

        private void TransformDrawAndResetTransform(Graphics g, Action<Graphics> draw)
        {
            var rotatedCenter = FindNewCenter();
            ShiftAnimation(g, rotatedCenter);
            g.TranslateTransform(rotatedCenter.X, rotatedCenter.Y);
            g.ScaleTransform(_scale, _scale);
            g.RotateTransform((float)_rotationAngle);
            draw(g);
            g.ResetTransform();
        }

        private PointF FindNewCenter()
        {
            var localLocationForRotationPoint = new Point(Center.X - _rotationCenter.X, Center.Y - _rotationCenter.Y);
            var rotationAngleRad = Math.PI * _rotationAngle / 180;
            var localRotatedCenter = localLocationForRotationPoint.Rotate(rotationAngleRad);
            var rotatedCenter = new PointF(localRotatedCenter.X + _rotationCenter.X, localRotatedCenter.Y + _rotationCenter.Y);
            return rotatedCenter;
        }

        private void ShiftAnimation(Graphics g, PointF center)
        {
            var pointF = _animator?.GetShift(center) ?? new PointF();
            g.TranslateTransform(pointF.X, pointF.Y);
        }

        protected abstract Point Center { get; set; }

        protected abstract void DrawFigure(Graphics g);
        protected abstract void HideFigure(Graphics g, Color backColor);
    }
}