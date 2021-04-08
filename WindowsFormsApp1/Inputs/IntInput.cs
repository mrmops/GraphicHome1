using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class IntInput: Input<int>
    {
        private readonly TextBox _textBox = new TextBox();
        
        public override int ParseValue()
        {
            return int.Parse(_textBox.Text);
        }

        public override Control[] GetControls() => new Control[] {_textBox};

        public IntInput(string name) : base(name)
        {
        }
    }
}