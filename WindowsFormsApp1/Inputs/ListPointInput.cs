using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ListPointInput: Input<List<Point>>
    {
        private readonly Stack<Point> _points = new Stack<Point>();
        private readonly Button _addPoint = new Button(){Text = "Добавить точку"};
        private readonly Button _removePoint = new Button(){Text = "Удалить точку"};
        private readonly TextBox _x = new TextBox();
        private readonly TextBox _y = new TextBox();
        private readonly Label _infoLabel = new Label();
        private string GetCountPointToString => $"Добавлено {_points.Count}";

        public ListPointInput(string name) : base(name)
        {
            UpdateLabel();
            _addPoint.Click += (sender, args) =>
            {
                try
                {
                    var x = int.Parse(_x.Text);
                    var y = int.Parse(_y.Text);
                    _points.Push(new Point(x, y));
                    UpdateLabel();
                }
                catch (Exception exception)
                {
                    
                }
            };
            _removePoint.Click += (sender, args) =>
            {
                if (_points.Count != 0)
                {
                    _points.Pop();
                    UpdateLabel();
                }
            };
        }

        private void UpdateLabel()
        {
            _infoLabel.Text = GetCountPointToString;
        }

        public override List<Point> ParseValue() => _points.ToList();

        public override Control[] GetControls() => new Control[] {_x, _y, _addPoint, _removePoint, _infoLabel};
    }
}