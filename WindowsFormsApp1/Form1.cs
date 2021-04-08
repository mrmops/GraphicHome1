using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1._3DFigures;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IDrawableFactory _selectedDrawableFactory;

        private SquareSurface _squareSurface = new SquareSurface(1000, new Point3D(0, 0, 0), Color.Black, 1);

        private readonly IDrawableFactory[] _drawableFactories = {
            new SurfaceFactory(),
            new CubeFactory(),
            new SphereFactory(),
            new SpiralFactory(),
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
                ["|x|"] = f => 0.5f * Math.Abs(f),
            };

        private System.Timers.Timer _updateTimer = new System.Timers.Timer()
        {
            Interval = 2,
        };

        private Bitmap _image;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(_drawableFactories);
            comboBox1.SelectedValueChanged += OnSelectDrawableFactory;
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(animations.Keys.ToArray());
            comboBox2.SelectedValueChanged += OnAnimationSelected;
            
            _image = new Bitmap(panel.Width, panel.Height);
            panel.SizeChanged += (_, __) =>
            {
                _image = new Bitmap(panel.Width, panel.Height);
            };
            panel.Paint += OnPaint;
            panel.KeyDown += MoveCamera;
            panel.MouseWheel += ScaleCamera;

            _updateTimer.Elapsed += (_, __) =>
            {
                _updateTimer.Enabled = false;
                panel.Invalidate();
                _updateTimer.Enabled = true;
            };
            _updateTimer.Start();

            DoubleBuffered = true;
        }

        private void ScaleCamera(object sender, MouseEventArgs e)
        {
            var scale = e.Delta > 0 ? 1.1 : 0.9;
            Camera.Scale(scale);
        }

        private void MoveCamera(object sender, KeyEventArgs e)
        {
            var step = 15;
            switch (e.KeyCode)
            {
                case Keys.A:
                {
                    Camera.MoveX(step);
                    return;
                }
                case Keys.W:
                {
                    Camera.MoveY(step);
                    return;
                }
                case Keys.S:
                {
                    Camera.MoveY(-step);
                    return;
                }
                case Keys.D:
                {
                    Camera.MoveX(-step);
                    return;
                }
                case Keys.ShiftKey:
                {
                    Camera.MoveZ(step);
                    return;
                }
                case Keys.Space:
                {
                    Camera.MoveZ(-step);
                    return;
                }
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var fromImage = Graphics.FromImage(_image);
            fromImage.Clear(panel.BackColor);
            InvalidateDrawables(fromImage);
            panel.Image = _image;
        }


        private void OnAnimationSelected(object sender, EventArgs e)
        {
            var drawable = GetSelectedDrawable();
            drawable._animator = new Animator(animations[comboBox2.SelectedItem.ToString()], panel);
        }

        private void OnSelectDrawableFactory(object sender, EventArgs e)
        {
            _selectedDrawableFactory = _drawableFactories[comboBox1.SelectedIndex];
            UpdateFactoryControls();
        }

        private void OnInitGraphicsClick(object sender, EventArgs e)
        {
            //DrawSpiral(sender, e);
            //InitGraphicsButton.Enabled = false;
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
                figures.Items.Add(drawable);
                figures.SelectedItem = drawable;
                //UpdateFactoryControls();
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
            if (drawable != null)
            {
                drawable.Scale = scaleTrackBar.Value;
            }
        }

        private void rotateTrackBar_Scroll(object sender, EventArgs e)
        {
            var drawable = GetSelectedDrawable();
            if(drawable != null)
            {
                drawable.Rotation = new Rotation(rotateTrackBar.Value, ParseRotationPoint());
            }
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
        
        private void InvalidateDrawables(Graphics g)
        {
            //_squareSurface.Update(g);
            //g?.Clear(panel.BackColor);
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
            if (drawableAnimator == null || button == null) return;
            drawableAnimator.Enable = !drawableAnimator.Enable;
            button.Text = drawableAnimator.Enable ? "Выключить анимацию" : "Включить анимацию";
        }

        private void figures_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drawable = GetSelectedDrawable();
            var drawableRotation = drawable?.Rotation;
            rotateTrackBar.Value = drawableRotation?.Angle ?? rotateTrackBar.Minimum;
            var drawableRotationRotationCenter = drawableRotation?.RotationCenter ?? new Point();
            rotationInputX.Text = drawableRotationRotationCenter.X.ToString();
            rotationInputY.Text = drawableRotationRotationCenter.Y.ToString();
            var drawableScale = drawable?.Scale ?? scaleTrackBar.Minimum;
            scaleTrackBar.Value =
                drawableScale >= scaleTrackBar.Minimum && drawableScale <= scaleTrackBar.Maximum 
                ? drawableScale 
                : scaleTrackBar.Minimum;
        }
        
        
        //очистка области рисования
        private void button4_Click(object sender, EventArgs e)
        {
            var g = panel.CreateGraphics();
            g.Clear(panel.BackColor);
        }
        //рисуем спираль
        private void DrawSpiral(object sender, EventArgs e)
        {
            double rd = (float) 0.3535534;
            var Mx = panel.Width/2;
            var My = panel.Height/5;
            var color = Color.Blue;
            var drawWidth = 1;
            var pen = new Pen(color, drawWidth);
            var graphics = panel.CreateGraphics();
            var oldPoint = new Point(0, 0);
            for (var i = 0; i <= 620; i++)
            {
                var angleInRadians = i * Math.PI / 180.0;
                var a = 0.3 * angleInRadians;
                var newAngle = 10 * angleInRadians;
                // var cos = Math.Cos(newAngle);
                // var sin = Math.Sin(newAngle);
                var z1 = (float) Math.Sin(newAngle);
                var z2 = (float) Math.Cos(newAngle)*(float) Math.Cos(a);
                var z3 = (float) Math.Cos(newAngle)*(float) Math.Sin(a);
                var x = z2 - rd * z3;
                var y = z1 - rd * z3;
                var px = (int) Math.Round(Mx + 100 * x);
                var py = (int) Math.Round(My + 100 * y);
                if (i == 0)
                {
                    oldPoint = new Point(px, py);
                }

                graphics.DrawLine(pen, oldPoint.X, oldPoint.Y, px, py);
                
                oldPoint = new Point(px, py);
            }
        }//spiral

        private void panel_Click(object sender, EventArgs e)
        {
            panel.Focus();
        }
    }
}