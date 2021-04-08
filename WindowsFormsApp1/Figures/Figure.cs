using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    public abstract class Figure: IDrawable
    {
        private float _scale = 1f;
        private int _rotationAngle = 0;
        private Point? _rotationCenter = null;

        public override string ToString()
        {
            return GetType().Name;
        }

        public void Update(Graphics g)
        {
            lock(g)
            {
                TransformDrawAndResetTransform(g, DrawFigure);
            }
        }

        public void Hide(Graphics g, Color backColor)
        {
            TransformDrawAndResetTransform(g, graphics => HideFigure(graphics, backColor));
        }

        public int Scale 
        { 
            get => (int) (_scale * 10f);
            set => _scale = value / 10f;
        }
        public Rotation Rotation 
        { 
            get => new Rotation(_rotationAngle, _rotationCenter);
            set
            {
                _rotationAngle = value.Angle;
                _rotationCenter = value.RotationCenter ?? Center;
            } 
        }

        public Animator? _animator { get; set; }

        private void TransformDrawAndResetTransform(Graphics g, Action<Graphics> draw)
        {
            var rotatedCenter = FindNewCenter();
            ShiftAnimation(g, rotatedCenter);
            g.TranslateTransform(rotatedCenter.X, rotatedCenter.Y);
            g.ScaleTransform(_scale, _scale);
            g.RotateTransform(_rotationAngle);
            draw(g);
            g.ResetTransform();
        }

        private PointF FindNewCenter()
        {
            var rotationCenter = _rotationCenter ?? Center;
            var localCenterForRotationPoint = new Point(Center.X - rotationCenter.X, Center.Y - rotationCenter.Y);
            var rotationAngleRad = Math.PI * _rotationAngle / 180;
            var localRotatedCenter = localCenterForRotationPoint.Rotate(rotationAngleRad);
            var rotatedCenter = new PointF(localRotatedCenter.X + rotationCenter.X, localRotatedCenter.Y + rotationCenter.Y);
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