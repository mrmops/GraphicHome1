using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class IntInput: InputInfo<int>
    {
        public override int ParseValue(string value)
        {
            return int.Parse(value);
        }

        public IntInput(string text) : base(text)
        {
        }
    }

    public abstract class DrawableFactory<T>: IDrawableFactory
        where T : IDrawable
    {
        protected DrawableFactory(string name)
        {
            Name = name;
        }
        
        protected abstract IInput[] Inputs { get; }
        
        protected Dictionary<IInput, Control> Controls = new Dictionary<IInput, Control>();

        public string Name { get; private set; }

        public Control[] GetControls()
        {
            Controls = Inputs.ToDictionary(x => x, y =>
            {
                var control = y.GetControl();
                return control;
            });
            var controls = Controls.Values.ToList();
            var dy = 10;
            foreach (var control in controls)
            {
                control.Location = new Point(control.Location.X, dy);
                dy += control.Height + 5;
            }
            return controls.ToArray();
        }
        
        public abstract T CreateDrawable();


        public IDrawable CreateNew()
        {
            foreach (var control in Controls)
            {
                control.Key.ParseStringValue(control.Value.Text);
            }

            return CreateDrawable();
        }
    }

    public interface IDrawableFactory
    {
        Control[] GetControls();
        IDrawable CreateNew();
    }

    public class LineFactory : DrawableFactory<Line>
    {
        
        private readonly IntInput _x1 = new IntInput("x1");
        private readonly IntInput _y1 = new IntInput("y1");
        private readonly IntInput _x2 = new IntInput("x2");
        private readonly IntInput _y2 = new IntInput("y2");
        private readonly IntInput _fontSize = new IntInput("fontSize");

        public LineFactory(string name) : base(name)
        {
        }

        protected override IInput[] Inputs =>
            new IInput[]
            {
                _x1, _y1, _x2, _y2, _fontSize
            };

        public override Line CreateDrawable()
        {
            var begin = new Point(_x1.Value, _y1.Value);
            var end = new Point(_x2.Value, _y2.Value);
            return new Line(begin, end, Color.DarkBlue, _fontSize.Value);
        }
    }
}