using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ListPointInput: InputInfo<List<Point>>
    {
        private readonly List<Point> _points = new List<Point>();
        private readonly Button _addPoint = new Button(){Text = "Add point"};
        private readonly TextBox _x = new TextBox();
        private readonly TextBox _y = new TextBox();
        private readonly Label _infoLabel = new Label(); 
        public string GetCountPointToString => $"Добавленно {_points.Count}";

        public ListPointInput(string name) : base(name)
        {
            _infoLabel.Text = GetCountPointToString;
            _addPoint.Click += (sender, args) =>
            {
                try
                {
                    var x = int.Parse(_x.Text);
                    var y = int.Parse(_y.Text);
                    _points.Add(new Point(x, y));
                    _infoLabel.Text = GetCountPointToString;
                }
                catch (Exception exception)
                {
                    
                }
            };
        }

        public override List<Point> ParseValue()
        {
            return _points;
        }

        public override Control[] GetControls() => new Control[] {_x, _y, _addPoint, _infoLabel};
    }
}