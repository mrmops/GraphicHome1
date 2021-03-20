using WindowsFormsApp1._3DFigures;

namespace WindowsFormsApp1
{
    public class SpiralFactory: DrawableFactory<Spiral>
    {
        private readonly Point3DInput _center = new Point3DInput("Начальная точка");
        private readonly RadAngleInput angleXY = new RadAngleInput("Угол поворота");
        private readonly IntInput stepZ = new IntInput("Высота шага");
        private readonly IntInput radius = new IntInput("Радиус");
        private readonly IntInput turnsCount = new IntInput("Количество витков");
        private readonly ColorInput _colorInput = new ColorInput("Цвет линии");
        protected override IInput[] Inputs => new IInput[] {_center, angleXY, stepZ, radius, turnsCount, _colorInput};
        public override string Name => "Спираль";
        protected override Spiral CreateDrawable()
        {
            return new(angleXY.Value, stepZ.Value, radius.Value, turnsCount.Value, _center.Value, _colorInput.Value, 1);
        }
    }
}