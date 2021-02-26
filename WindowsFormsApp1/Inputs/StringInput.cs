using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class StringInput: InputInfo<string>
    {
        private TextBox _textBox = new TextBox();
        public StringInput(string name) : base(name)
        {
            
        }

        public override string ParseValue()
        {
            return _textBox.Text;
        }

        public override Control[] GetControls() => new[] {_textBox};
    }
}