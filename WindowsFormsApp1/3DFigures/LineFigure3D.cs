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
        private Rotation _rotation = new Rotation(0, new Point());
        
        public Color Color { get; private set; }
        
        public int Width{ get; private set; }

        protected LineFigure3D(Color color, int width)
        {
            Color = color;
            Width = width;
        }

        protected abstract IEnumerable<Line3D> GetLines();

        public void Update(Graphics g)
        {
            var lines = TransformPoints();
            DrawMe(g, lines);
            DrawCenter(g, GetCenter());
        }
        
        private IEnumerable<Line> TransformPoints()
        {
            return GetLines().Select(x =>
            {
                var beginPoint = ToScreenPoints(x.Start).ToPoint();
                var endPoint = ToScreenPoints(x.End).ToPoint();
                return new Line(beginPoint, endPoint, Color, Width);
            });
        }

        private PointF ToScreenPoints(Point3D point)
        {
            var newPoint = TransformPoint(point);
            var transform = Camera.GetTransform();
            var cameraCenter = transform.GetPoint();
            var len = Math.Sqrt(Math.Pow(cameraCenter.X - newPoint.X, 2)
                                + Math.Pow(cameraCenter.Y - newPoint.Y, 2)
                                + Math.Pow(cameraCenter.Z - newPoint.Z, 2));
            newPoint = transform * newPoint;
            newPoint = Matrix.CreateTransformMatrixFromView(len * 5) * newPoint; 
            return new PointF((float) newPoint.X, (float) newPoint.Y);
        }

        private Point3D TransformPoint(Point3D point)
        {
            var center = GetCenter();
            var newPoint = point;
            newPoint = Matrix.CreateTranslateMatrix(
                -_rotation.RotationCenter?.X ?? 0,
                -_rotation.RotationCenter?.Y ?? 0,
                -center.Z) * newPoint;
            newPoint = Matrix.CreateRotationMatrixZ(_rotation.Angle * Math.PI / 180) * newPoint;
            newPoint = Matrix.CreateScaleMatrix(_scale * 0.1) * newPoint;
            newPoint = Matrix.CreateTranslateMatrix(
                _rotation.RotationCenter?.X ?? 0,
                _rotation.RotationCenter?.Y ?? 0,
                center.Z) * newPoint;
            return newPoint;
        }
                
        protected void DrawMe(Graphics g, IEnumerable<Line> lines)
        {
            foreach (var line in lines)
            {
                line.Update(g);
            }
        }

        private void DrawCenter(Graphics graphics, Point3D center)
        {
            var endPointX = ToScreenPoints(new Point3D(center.X + 50, center.Y, center.Z)).ToPoint();
            var start = new Point3D(center.X, center.Y, center.Z);
            new Line(
                ToScreenPoints(start).ToPoint(),
                endPointX, 
                Color.Gold, 2).Update(graphics);
            graphics.DrawString("X", SystemFonts.DefaultFont, Brushes.Gold, endPointX);

            var endPointY = ToScreenPoints(new Point3D(center.X, center.Y + 50, center.Z)).ToPoint();
            new Line(
                ToScreenPoints(start).ToPoint(),
                endPointY, 
                Color.Blue, 2).Update(graphics);
            graphics.DrawString("Y", SystemFonts.DefaultFont, Brushes.Blue, endPointY);

            var endPointZ = ToScreenPoints(new Point3D(center.X, center.Y, center.Z + 50)).ToPoint();
            new Line(
                ToScreenPoints(start).ToPoint(),
                endPointZ, 
                Color.LawnGreen, 2).Update(graphics);
            graphics.DrawString("Z", SystemFonts.DefaultFont, Brushes.LawnGreen, endPointZ);
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