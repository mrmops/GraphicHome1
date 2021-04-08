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

        public IEnumerable<Control> GetControls() => SetupControls();

        private IEnumerable<Control> SetupControls()
        {
            foreach (var input in Inputs)
            {
                var label = new Label()
                {
                    Text = input.Name,
                    AutoSize = true
                };
                yield return label;
                foreach (var control in input.GetControls())
                {
                    yield return control;
                }
            }
        }

        protected abstract T CreateDrawable();
        
        public IDrawable CreateNew()
        {
            foreach (var input in Inputs)
            {
                input.SubmitData();
            }
            
            return CreateDrawable();
        }

        public override string ToString()
        {
            return Name ?? throw new NotImplementedException("Name not implements!");
        }
    }
}