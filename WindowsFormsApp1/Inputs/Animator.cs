using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Animator
    {
        private Func<float, float> _displacementCurve;

        private float _step = 0.1f;
        private readonly Control _control;

        public bool Enable = true;

        private readonly float _scale;

        private float _dx;
        private PointF _oldShift;
        
        public Animator(Func<float, float> displacementCurve, Control control, float scale = 50f)
        {
            _displacementCurve = displacementCurve;
            _control = control;
            _scale = scale;
        }

        public PointF GetShift(PointF center)
        {
            var newDx = _dx;
            if(Enable) 
                newDx += _step;
            var dy = _displacementCurve(_dx);
            var shift = new PointF(newDx * _scale, dy * _scale);
            if (ValidPoint(center.X + shift.X, center.Y + shift.Y))
            {
                _dx = newDx;
                _oldShift = shift;
                return shift;
            }
            
            _step = -_step;
            return _oldShift;
        }

        private bool ValidPoint(float dx, float dy)
        {
            return dx >= 0 && dy >= 0 && dx < _control.Width && dy < _control.Height;
        }
        
        private bool ValidPoint(PointF pointF)
        {
            return ValidPoint(pointF.X, pointF.Y);
        }
    }
}