namespace WindowsFormsApp1
{
    public class NormalPolygonFactory: DrawableFactory<NormalPolygon>
    {
        private readonly PointInput _locationInput = new PointInput("Центр");
        private readonly IntInput _angleCountInput = new IntInput("Количество углов");
        private readonly IntInput _radiusInput = new IntInput("Расстояние до углов");
        private readonly IntInput _widthInput = new IntInput("Ширина линии рисования");
        private readonly ColorInput _colorInput = new ColorInput("Цвет рисования");
        private readonly ColorInput _fillColorInput = new ColorInput("Цвет заполнения");

        protected override IInput[] Inputs => new IInput[]
            {_locationInput, _angleCountInput, _radiusInput, _widthInput, _colorInput, _fillColorInput};
        
        public override string Name => "Правильный многоугольник";
        
        protected override NormalPolygon CreateDrawable() =>
            new NormalPolygon(_locationInput.Value, _angleCountInput.Value, _radiusInput.Value, _widthInput.Value, _colorInput.Value, _fillColorInput.Value);
    }
}