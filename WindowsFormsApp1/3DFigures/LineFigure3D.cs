using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsApp1._3DFigures
{
    public abstract class LineFigure3D: IDrawable
    {
        private int _scale = 10;
        private static Matrix defaultTransform = Matrix.CreateStartMatrix() * Matrix.CreateRotationMatrixX(Math.PI / 3);
        private Rotation _rotation = new Rotation(0, new Point());
        protected abstract IEnumerable<Line3D> GetLines();

        protected void DrawMe(Graphics g, IEnumerable<Line> lines)
        {
            foreach (var line in lines)
            {
                line.Update(g);
            }
        }
        
        public void Update(Graphics g)
        {
            var points2D = TransformPoints();
            DrawMe(g, points2D);
            DrawCenter(g, GetCenter());
        }

        private void DrawCenter(Graphics graphics, Point3D center)
        {
            var endPointX = ToScreenPoints(new Point3D(center.X + 50, center.Y, center.Z), Transform).ToPoint();
            new Line(
                ToScreenPoints(new Point3D(center.X, center.Y, center.Z), Transform).ToPoint(),
                endPointX, 
                Color.Gold, 2).Update(graphics);
            graphics.DrawString("X", SystemFonts.DefaultFont, Brushes.Gold, endPointX);

            var endPointY = ToScreenPoints(new Point3D(center.X, center.Y + 50, center.Z), Transform).ToPoint();
            new Line(
                ToScreenPoints(new Point3D(center.X, center.Y, center.Z), Transform).ToPoint(),
                endPointY, 
                Color.Blue, 2).Update(graphics);
            graphics.DrawString("Y", SystemFonts.DefaultFont, Brushes.Blue, endPointY);

            var endPointZ = ToScreenPoints(new Point3D(center.X, center.Y, center.Z + 50), Transform).ToPoint();
            new Line(
                ToScreenPoints(new Point3D(center.X, center.Y, center.Z), Transform).ToPoint(),
                endPointZ, 
                Color.LawnGreen, 2).Update(graphics);
            graphics.DrawString("Z", SystemFonts.DefaultFont, Brushes.LawnGreen, endPointZ);
        }

        private IEnumerable<Line> TransformPoints()
        {
            foreach (var line in GetLines().Select(x => new Line(
                ToScreenPoints(x.Start, Transform).ToPoint(),
                ToScreenPoints(x.End, Transform).ToPoint(),
                x.Color,
                x.Width)))
            {
                yield return line;
            }
        }

        public Matrix Transform { get; set; } = defaultTransform;

        private PointF ToScreenPoints(Point3D point, Matrix transform)
        {
            var center = GetCenter();
            var newPoint = point;
            newPoint = Matrix.CreateTranslateMatrix(
                -_rotation.RotationCenter?.X ?? 0,
                -_rotation.RotationCenter?.Y ?? 0, 
                -center.Z) * newPoint;
            newPoint =  Matrix.CreateRotationMatrixZ(_rotation.Angle * Math.PI / 180) * newPoint;
            newPoint =  Matrix.CreateScaleMatrix(_scale * 0.1) * newPoint;
            newPoint = Matrix.CreateTranslateMatrix(
                _rotation.RotationCenter?.X ?? 0,
                _rotation.RotationCenter?.Y ?? 0, 
                center.Z) * newPoint;
            newPoint = defaultTransform * newPoint;
            newPoint = Matrix.CreateTransformMatrixFromView() * newPoint; 
            return new PointF((float) newPoint.X, (float) newPoint.Y);
        }

        public void Hide(Graphics g, Color backColor)
        {
            throw new System.NotImplementedException();
        }

        public int Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                UpdateTransform();
            }
        }

        private void UpdateTransform()
        {
            // var center = GetCenter();
            // Transform = Matrix.CreateStartMatrix();
            // Transform = Transform * Matrix.CreateTranslateMatrix(
            //     -_rotation.RotationCenter?.X ?? 0,
            //     -_rotation.RotationCenter?.Y ?? 0, 
            //     -center.Z);
            // Transform = Transform * Matrix.CreateRotationMatrixZ(_rotation.Angle * Math.PI / 180);
            // Transform = Transform * Matrix.CreateScaleMatrix(_scale * 0.1);
            // Transform = Transform * Matrix.CreateTranslateMatrix(
            //     _rotation.RotationCenter?.X ?? 0,
            //     _rotation.RotationCenter?.Y ?? 0, 
            //     center.Z);
            // Transform = Transform * defaultTransform;
            // Transform = Transform * Matrix.CreateTransformMatrixFromView();
        }

        public Rotation Rotation
        {
            get => _rotation;
            set
            {
                var point3D = GetCenter();
                _rotation = new Rotation(value.Angle, value.RotationCenter ?? new Point((int) point3D.X, (int) point3D.Y));
                UpdateTransform();
            }
        }

        protected abstract Point3D GetCenter();

        public Animator _animator { get; set; }
    }
}