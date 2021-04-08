using WindowsFormsApp1._3DFigures;

namespace WindowsFormsApp1
{
    public class CubeFactory: DrawableFactory<Cube>
    {
        
        private readonly Point3DInput _center = new Point3DInput("Начальная точка");
        private readonly IntInput _height = new IntInput("Высота");
        private readonly ColorInput _colorInput = new ColorInput("Цвет линии");
        
        protected override IInput[] Inputs => new IInput[] {_center, _height, _colorInput};
        public override string Name => "Куб";
        protected override Cube CreateDrawable()
        {
            return new Cube(_colorInput.Value, 1, _center.Value, _height.Value);
        }
    }
}