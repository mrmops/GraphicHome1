using System.Drawing;

namespace WindowsFormsApp1
{
    public class CircleFactory : DrawableFactory<Circle>
    {
        private readonly PointInput _center = new PointInput("Center x, y");
        private readonly IntInput _radius = new IntInput("radius");
        private readonly StringInput _name = new StringInput("name");
        private readonly IntInput _width = new IntInput("width");
        private readonly ColorInput _fillColor = new ColorInput("fill color");
        private readonly ColorInput _strokeColor = new ColorInput("stroke color");

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