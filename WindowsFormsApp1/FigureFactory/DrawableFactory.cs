using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public abstract class DrawableFactory<T>: IDrawableFactory
        where T : IDrawable
    {
        protected abstract IInput[] Inputs { get; }

        public abstract string Name { get; }

        public List<Control> GetControls()
        {
            var resultControls = SetupControls();

            return resultControls;
        }

        private List<Control> SetupControls()
        {
            var resultControls = new List<Control>();
            var dy = 20;
            foreach (var input in Inputs)
            {
                var label = new Label()
                {
                    Text = input.Name,
                    Location = new Point(0, dy),
                    AutoSize = true
                };
                dy += label.Height;
                foreach (var control in input.GetControls())
                {
                    control.Location = new Point(0, dy);
                    dy += control.Height;
                    resultControls.Add(control);
                }

                resultControls.Add(label);
            }

            return resultControls;
        }

        protected abstract T CreateDrawable();
        
        public IDrawable CreateNew()
        {
            foreach (var input in Inputs)
            {
                input.ParseInput();
            }
            
            return CreateDrawable();
        }

        public override string ToString()
        {
            return Name ?? throw new NotImplementedException("Name not implements!");
        }
    }
}