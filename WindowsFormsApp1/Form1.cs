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
            new Dictionary<string, Func<float, float>>()
            {
                ["cos"] = f => (float) Math.Cos(f),
                ["sin"] = f => (float) Math.Sin(f),
                ["simple"] = f => 0,
                ["x^3 * cos(x)"] = f => f*f*f * (float)Math.Cos(f),
            };

        private System.Timers.Timer _updateTimer = new System.Timers.Timer()
        {
            Interval = 2,
        };

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(_drawableFactories);
            comboBox1.SelectedValueChanged += OnSelectDrawableFactory;
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(animations.Keys.ToArray());
            comboBox2.SelectedValueChanged += OnAnimationSelected;
            
            _pictureBoxGraphics = pictureBox.CreateGraphics();
            pictureBox.Paint += (_, __) => OnPaint();
            pictureBox.SizeChanged += (sender, args) => _pictureBoxGraphics = pictureBox.CreateGraphics();

            _updateTimer.Elapsed += (_, __) =>
            {
                _updateTimer.Enabled = false;
                pictureBox.Invalidate();
                _updateTimer.Enabled = true;
            };
            _updateTimer.Start();

            DoubleBuffered = true;
        }

        private void OnPaint()
        {
            var image = new Bitmap(pictureBox.Width, pictureBox.Height);
            InvalidateDrawables(Graphics.FromImage(image));
            pictureBox.Image = image;
        }


        private void OnAnimationSelected(object sender, EventArgs e)
        {
            var drawable = GetSelectedDrawable();
            drawable._animator = new Animator(animations[comboBox2.SelectedItem.ToString()], pictureBox);
        }

        private void OnSelectDrawableFactory(object sender, EventArgs e)
        {
            _selectedDrawableFactory = _drawableFactories[comboBox1.SelectedIndex];
            UpdateFactoryControls();
        }

        private void OnInitGraphicsClick(object sender, EventArgs e)
        {
            _pictureBoxGraphics = pictureBox.CreateGraphics();
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
        }

        private void scaleTrackBar_Scroll(object sender, EventArgs e)
        {
            var drawable = GetSelectedDrawable();
            drawable?.Scale(scaleTrackBar.Value / 10f);
        }

        private void rotateTrackBar_Scroll(object sender, EventArgs e)
        {
            var drawable = GetSelectedDrawable();
            drawable?.Rotate(rotateTrackBar.Value, ParseRotationPoint());
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
        


/*
 
        void move(int dx, int dy)
        {
            x += dx;
            y += dy;
        }
        risovat
        bool flag=true;
        while(flag)
        {
            Thread.Sleep(200);
            Hide();
            move(10,10);   
            risovat
        }   


button10_click() { timer1.Start=false;    } 


*/




        private void InvalidateDrawables(Graphics g)
        {
            //g?.Clear(driwerPanel.BackColor);
            foreach (var figure in figures.Items)
            {
                var drawable = (figure as IDrawable);
                drawable?.Update(g);
            }
        }

        private Point? ParseRotationPoint()
        {
            var strX = rotationInputX.Text;
            var strY = rotationInputY.Text;
            try
            {
                if (string.IsNullOrEmpty(strX) || string.IsNullOrEmpty(strY))
                    return null;
                return new Point(int.Parse(strX), int.Parse(strY));
            }
            catch
            {
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var drawable = GetSelectedDrawable();
            var button = sender as Button;
            var drawableAnimator = drawable._animator;
            if (drawableAnimator != null)
            {
                drawableAnimator.Enable = !drawableAnimator.Enable;
                button.Text = drawableAnimator.Enable ? "Выключить анимацию" : "Включить анимацию";
            }
        }
    }
}