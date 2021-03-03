using System.Drawing;

namespace WindowsFormsApp1
{
    public class CircleFactory : DrawableFactory<Circle>
    {
        private readonly PointInput _center = new PointInput("Центр x, y");
        private readonly IntInput _radius = new IntInput("Радиус");
        private readonly StringInput _name = new StringInput("Подпись в центре");
        private readonly IntInput _width = new IntInput("Ширина обводки");
        private readonly ColorInput _fillColor = new ColorInput("Цвет заполнения");
        private readonly ColorInput _strokeColor = new ColorInput("Цвет обводки");

        protected override IInput[] Inputs => new IInput[]
        {
            _center, _radius, _width, _name, _fillColor, _strokeColor
        };

        public override string Name => "Круг";

        protected override Circle CreateDrawable()
        {

            return new Circle(_center.Value, _radius.Value, _fillColor.Value, _strokeColor.Value, _width.Value, _name.Value);
        }
    }
}