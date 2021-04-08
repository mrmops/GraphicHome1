using WindowsFormsApp1._3DFigures;

namespace WindowsFormsApp1
{
    public class SpiralFactory: DrawableFactory<Spiral>
    {
        private readonly Point3DInput _center = new Point3DInput("Начальная точка");
        private readonly RadAngleInput _angleXy = new RadAngleInput("Угол поворота");
        private readonly IntInput _stepZ = new IntInput("Высота шага");
        private readonly IntInput _radius = new IntInput("Радиус");
        private readonly IntInput _turnsCount = new IntInput("Количество витков");
        private readonly ColorInput _colorInput = new ColorInput("Цвет линии");
        protected override IInput[] Inputs => new IInput[] {_center, _angleXy, _stepZ, _radius, _turnsCount, _colorInput};
        public override string Name => "Спираль";
        protected override Spiral CreateDrawable()
        {
            return new(_angleXy.Value, _stepZ.Value, _radius.Value, _turnsCount.Value, _center.Value, _colorInput.Value, 1);
        }
    }
}