using System;
using WindowsFormsApp1._3DFigures;

namespace WindowsFormsApp1
{
    internal class SphereFactory : DrawableFactory<Sphere>
    {
        private readonly Point3DInput _center = new Point3DInput("Начальная точка");
        private readonly IntInput _radius = new IntInput("Радиус");
        private readonly IntInput _verCountSegments = new IntInput("Вертикальное количесвто сегментов");
        private readonly IntInput _horCountSegments = new IntInput("горизонтальное количесвто сегментов");
        private readonly ColorInput _colorInput = new ColorInput("Цвет линии");
        protected override IInput[] Inputs => new IInput[] {_center, _radius, _verCountSegments, _horCountSegments, _colorInput};
        public override string Name => "Сфера";
        protected override Sphere CreateDrawable()
        {
            return new Sphere(_center.Value, _radius.Value, _verCountSegments.Value, _horCountSegments.Value,
                _colorInput.Value, 1);
        }
    }
}