using System.Windows.Forms;
using WindowsFormsApp1._3DFigures;

namespace WindowsFormsApp1
{
    public class Point3DInput : Input<Point3D>
    {
        private readonly TextBox _xInput = new TextBox();
        private readonly TextBox _yInput = new TextBox();
        private readonly TextBox _zInput = new TextBox();
        
        public Point3DInput(string name) : base(name)
        {
        }
        
        public override Point3D ParseValue()
        {
            var x = int.Parse(_xInput.Text);
            var y = int.Parse(_yInput.Text);
            var z = int.Parse(_zInput.Text);
            return new Point3D(x, y, z);
        }
        
        public override Control[] GetControls() => new Control[] {_xInput, _yInput, _zInput};
    }
}