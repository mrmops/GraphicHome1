using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ColorInput : Input<Color>
    {
        private readonly ColorDialog _colorDialog = new ColorDialog();
        private readonly Button _button = new Button(){Text = "Цвет", ForeColor = Color.Black};
        public ColorInput(string name) : base(name)
        {
            _button.Click += OnColorPickerButtonClick;
        }

        private void OnColorPickerButtonClick(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                if (_colorDialog.ShowDialog() == DialogResult.OK)
                    _button.ForeColor = _colorDialog.Color;
            });
            t.Start();
        }

        public override Color ParseValue() => _colorDialog.Color;

        public override Control[] GetControls() => new Control[] {_button};
    }
}