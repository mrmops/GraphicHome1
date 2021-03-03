using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class PointInput : Input<Point>
    {
        private readonly TextBox _xInput = new TextBox();
        private readonly TextBox _yInput = new TextBox();
        public PointInput(string name) : base(name)
        {
        }

        public override Point ParseValue()
        {
            var x = int.Parse(_xInput.Text);
            var y = int.Parse(_yInput.Text);
            return new Point(x, y);
        }

        public override Control[] GetControls() => new[] {_xInput, _yInput};
    }
}