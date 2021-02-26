using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Graphics _pictureBoxGraphics;
        private IDrawableFactory _selectedDrawableFactory;

        private readonly IDrawableFactory[] _drawableFactories = {
            new LineFactory(),
            new CircleFactory(),
            new CustomPolygonFactory(),
            new NormalPolygonFactory()
        };
        private Stack<IDrawable> _figures = new Stack<IDrawable>();

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(_drawableFactories);
            comboBox1.SelectedValueChanged += OnSelectDrawableFactory;
            comboBox1.SelectedIndex = 0;
        }

        private void OnSelectDrawableFactory(object sender, EventArgs e)
        {
            _selectedDrawableFactory = _drawableFactories[comboBox1.SelectedIndex];
            InitGraphicsButton.Enabled = true;
            DrawButton.Enabled = false;
            UpdateFactoryControls();
        }

        private void OnInitGraphicsClick(object sender, EventArgs e)
        {
            _pictureBoxGraphics = pictureBox1.CreateGraphics();
            InitGraphicsButton.Enabled = false;
            DrawButton.Enabled = true;
            UpdateFactoryControls();
        }

        private void UpdateFactoryControls()
        {
            groupBox4.Controls.Clear();
            groupBox4.Controls.AddRange(_selectedDrawableFactory.GetControls().ToArray());
        }

        private void OnDrawButtonClick(object sender, EventArgs e)
        {
            try
            {
                var drawable = _selectedDrawableFactory.CreateNew();
                drawable.Draw(_pictureBoxGraphics);
                _figures.Push(drawable);
                UpdateFactoryControls();
            }
            catch (Exception exception)
            {
                groupBox3.Controls.Clear();
                groupBox3.Controls.Add(new Label()
                {
                    Text = exception.Message,
                    AutoSize = true,
                    ForeColor = Color.Red
                });
            }
        }

        private void OnHideGraphicsClick(object sender, EventArgs e)
        {
            if(_figures.Count != 0)
            {
                var drawable = _figures.Pop();
                drawable.Hide(_pictureBoxGraphics, BackColor);
                foreach (var figure in _figures)
                {
                    figure.Draw(_pictureBoxGraphics);
                }
            }
        }
    }
}