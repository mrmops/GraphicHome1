using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public abstract class Input<T>: IInput
    {
        protected Input(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public T Value { get; set; }

        public abstract T ParseValue();
        
        public void ParseInput()
        {
            Value = ParseValue();
        }

        public abstract Control[] GetControls();
    }
}