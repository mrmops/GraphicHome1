using System.Drawing;

namespace WindowsFormsApp1
{
    public class LineFactory : DrawableFactory<Line>
    {
        private readonly PointInput _beginPoint = new PointInput("Begin point");
        private readonly PointInput _endPoint = new PointInput("End point");
        private readonly IntInput _fontSize = new IntInput("fontSize");
        private readonly ColorInput _colorInput = new ColorInput("line color");

        protected override IInput[] Inputs =>
            new IInput[]
            {
                _beginPoint, _endPoint, _fontSize, _colorInput
            };

        public override string Name => "Линия";

        protected override Line CreateDrawable()
        {
            return new Line(_beginPoint.Value, _endPoint.Value, _colorInput.Value, _fontSize.Value);
        }
    }
}