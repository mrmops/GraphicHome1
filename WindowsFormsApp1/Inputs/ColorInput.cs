using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ColorInput : InputInfo<Color>
    {
        private readonly ColorDialog _colorDialog = new ColorDialog();
        private readonly Button colorOn = new Button(){Text = "Цвет", ForeColor = Color.Blue};
        public ColorInput(string name) : base(name)
        {
            colorOn.Click += onColorPickerButtonClick;
        }

        private void onColorPickerButtonClick(object sender, EventArgs e)
        {
            if (_colorDialog.ShowDialog() == DialogResult.OK)
                colorOn.ForeColor = _colorDialog.Color;
        }

        public override Color ParseValue() => _colorDialog.Color;

        public override Control[] GetControls() => new Control[] {colorOn};
    }
}