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
        protected InputInfo(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
        public T Value { get; set; }

        public abstract T ParseValue(string value);
        
        public void ParseStringValue(string value)
        {
            Value = ParseValue(value);
        }

        public Control GetControl()
        {
            return new TextBox()
            {
                Text = Text
            };
        }
    }

    public interface IInput
    {
        void ParseStringValue(string value);

        Control GetControl();

    }
}