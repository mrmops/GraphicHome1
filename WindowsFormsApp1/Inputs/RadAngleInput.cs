﻿using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class RadAngleInput: Input<double>
    {
        private readonly TextBox _textBox = new TextBox();
        
        public override double ParseValue()
        {
            return int.Parse(_textBox.Text) * Math.PI / 180;
        }

        public override Control[] GetControls() => new Control[] {_textBox};

        public RadAngleInput(string name) : base(name)
        {
        }
    }
}