namespace WindowsFormsApp1
{
    public class NormalPolygonFactory: DrawableFactory<NormalPolygon>
    {
        private readonly PointInput locationInput = new PointInput("Центр");
        private readonly IntInput angleCountInput = new IntInput("Количество углов");
        private readonly IntInput radiusInput = new IntInput("Расстояние до углов");
        private readonly IntInput widthInput = new IntInput("Ширина линии рисования");
        private readonly ColorInput colorInput = new ColorInput("Цвет рисования");
        private readonly ColorInput fillColorInput = new ColorInput("Цвет заполнения");

        protected override IInput[] Inputs => new IInput[]
            {locationInput, angleCountInput, radiusInput, widthInput, colorInput};
        
        public override string Name => "Правильный многоугольник";
        
        protected override NormalPolygon CreateDrawable() =>
            new NormalPolygon(locationInput.Value, angleCountInput.Value, radiusInput.Value, widthInput.Value, colorInput.Value, fillColorInput.Value);
    }
}