namespace WindowsFormsApp1
{
    public class CustomPolygonFactory: DrawableFactory<CustomPolygon>
    {
        private ListPointInput _listPointInput = new ListPointInput("Вводите точки");
        private readonly ColorInput _colorInput = new ColorInput("Выбор цвета");
        private readonly ColorInput _fillColorInput = new ColorInput("Выбор заливки");
        private readonly IntInput _widthInput = new IntInput("Толщина линии");
        protected override IInput[] Inputs => new IInput[] {_listPointInput, _widthInput, _colorInput};
        public override string Name => "Кастомный многоугольник";
        protected override CustomPolygon CreateDrawable()
        {
            var customPolygon = new CustomPolygon(_listPointInput.Value, _colorInput.Value, _widthInput.Value, _fillColorInput.Value);
            _listPointInput = new ListPointInput(_listPointInput.Name);
            return customPolygon;
        }
    }
}