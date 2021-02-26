using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public interface IDrawable
    {
        void Draw(Graphics g);
        void Hide(Graphics g, Color backColor);
    }

    public abstract class InputInfo<T>: IInput
    {
        protected InputInfo(string name)
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

    public interface IInput
    {
        void ParseInput();

        Control[] GetControls();
        
        string Name { get; }

    }
}