using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private readonly Dictionary<string, Func<float, float>> animations =
            new()
            {
                ["cos"] = f => (float) Math.Cos(f),
                ["sin"] = f => (float) Math.Sin(f),
                ["simple"] = f => 0
            };

        private Timer _updateTimer = new Timer()
        {
            Interval = 3,
        };

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(_drawableFactories);
            comboBox1.SelectedValueChanged += OnSelectDrawableFactory;
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(animations.Keys.ToArray());
            comboBox2.SelectedValueChanged += OnAnimationSelected;
            
            _pictureBoxGraphics = driwerPanel.CreateGraphics();
            driwerPanel.SizeChanged += (sender, args) => _pictureBoxGraphics = driwerPanel.CreateGraphics();

            _updateTimer.Tick += (_, _) => InvalidateDrawables();
            _updateTimer.Start();

            DoubleBuffered = true;
        }


        private void OnAnimationSelected(object sender, EventArgs e)
        {
            var drawable = GetSelectedDrawable();
            drawable._animator = new Animator(animations[comboBox2.SelectedItem.ToString()], driwerPanel);
        }

        private void OnSelectDrawableFactory(object sender, EventArgs e)
        {
            _selectedDrawableFactory = _drawableFactories[comboBox1.SelectedIndex];
            UpdateFactoryControls();
        }

        private void OnInitGraphicsClick(object sender, EventArgs e)
        {
            _pictureBoxGraphics = driwerPanel.CreateGraphics();
            InitGraphicsButton.Enabled = false;
            DrawButton.Enabled = true;
        }

        private void UpdateFactoryControls()
        {
            groupBox4.Controls.Clear();
            var y = 20;
            foreach (var control in _selectedDrawableFactory.GetControls())
            {
                control.Location = new Point(0, y);
                y += control.Height;
                groupBox4.Controls.Add(control);
            }
        }

        private void OnDrawButtonClick(object sender, EventArgs e)
        {
            try
            {
                var drawable = _selectedDrawableFactory.CreateNew();
                drawable.Update(_pictureBoxGraphics);
                figures.Items.Add(drawable);
                UpdateFactoryControls();
            }
            catch (Exception exception)
            {
                groupBox3.Controls.Clear();
                var control = new Label()
                {
                    Text = exception.Message,
                    AutoSize = true,
                    ForeColor = Color.Red,
                };
                control.Location = new Point((groupBox3.Width - control.Width) / 2, (groupBox3.Height - control.Height) / 2);
                groupBox3.Controls.Add(control);
            }
        }

        private void OnHideGraphicsClick(object sender, EventArgs e)
        {
            var drawable = GetSelectedDrawable();
            if (drawable != null)
            {
                figures.Items.Remove(drawable);
                //drawable.Hide(_pictureBoxGraphics, BackColor);
            }

            InvalidateDrawables();
        }

        private void scaleTrackBar_Scroll(object sender, EventArgs e)
        {
            var drawable = GetSelectedDrawable();
            drawable?.Scale(scaleTrackBar.Value / 10f);
            InvalidateDrawables();
        }

        private void rotateTrackBar_Scroll(object sender, EventArgs e)
        {
            var drawable = GetSelectedDrawable();
            drawable?.Rotate(rotateTrackBar.Value, ParseRotationPoint());
            InvalidateDrawables();
        }
        
        private IDrawable GetSelectedDrawable()
        {
            if (!(figures.SelectedItem is IDrawable drawable))
            {
                figures.SelectedIndex = figures.Items.Count - 1;
                drawable = figures.SelectedItem as IDrawable;
            }

            return drawable;
        }
        
        private void InvalidateDrawables()
        {
            _pictureBoxGraphics?.Clear(driwerPanel.BackColor);
            foreach (var figure in figures.Items)
            {
                (figure as IDrawable)?.Update(_pictureBoxGraphics);
            }
        }

        private Point? ParseRotationPoint()
        {
            var strX = rotationInputX.Text;
            var strY = rotationInputY.Text;
            try
            {
                return new Point(int.Parse(strX), int.Parse(strY));
            }
            catch
            {
                return null;
            }
        }
    }
}