using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Graphics _pictureBoxGraphics;
        private IDrawableFactory drawableFactory;

        public Form1()
        {
            InitializeComponent();
            drawableFactory = new LineFactory("Line");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // var x1 = int.Parse(textBox1.Text);
            // var y1 = int.Parse(textBox2.Text);
            // var radius = int.Parse(textBox3.Text);
            // //var y2 = int.Parse(textBox4.Text);
            // int width = 0;
            // if (!string.IsNullOrEmpty(textBox4.Text))
            //     width = int.Parse(textBox4.Text);
            //
            // var beginPoint = new Point(x1, y1);
            // //var endPoint = new Point(radius, y2);
            // // _line = new Line(beginPoint, endPoint, Color.Crimson, width);
            // // _line.Draw(_pictureBoxGraphics);

            var drawable = drawableFactory.CreateNew();
            drawable.Draw(_pictureBoxGraphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _pictureBoxGraphics = pictureBox1.CreateGraphics();
            button1.Enabled = false;
            groupBox4.Controls.AddRange(drawableFactory.GetControls());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var drawable = drawableFactory.CreateNew();
            drawable.Hide(_pictureBoxGraphics, BackColor);
        }
    }
}