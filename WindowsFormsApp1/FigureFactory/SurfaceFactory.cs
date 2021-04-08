using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1._3DFigures;

namespace WindowsFormsApp1
{
    public class SurfaceFactory: DrawableFactory<Surface>
    {
        private readonly Point3DInput _center = new Point3DInput("Начальная точка");
        private readonly IntInput _step = new IntInput("Шаг");
        private readonly ColorInput _colorInput = new ColorInput("Цвет линии");
        private readonly Func3DPicker _func3DPicker = new Func3DPicker("Функция поверхности");
        
        protected override IInput[] Inputs => new IInput[] {_center, _step, _func3DPicker,  _colorInput};
        public override string Name => "Поверхность";
        protected override Surface CreateDrawable()
        {
            return new Surface(_center.Value, _step.Value, _func3DPicker.Value, _colorInput.Value, 1);
        }
    }

    public class Func3DPicker: Input<Func<double, double, double>>
    {
        private ComboBox _comboBox = new ComboBox();
        
        public Func3DPicker(string name) : base(name)
        {
            var funcs = new List<Func<double, double, double>>()
            {
                (x, y) => Math.Sin(x) * Math.Cos(y) * 100,
                (x, y) => Math.Cos(x * y) * 100,
            };
            _comboBox.Items.AddRange(funcs.ToArray());
        }

        public override Func<double, double, double> ParseValue()
        {
            return _comboBox.SelectedItem as Func<double, double, double>;
        }

        public override Control[] GetControls() => new Control[] {_comboBox};
    }
}