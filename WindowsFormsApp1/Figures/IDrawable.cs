using System.Drawing;

namespace WindowsFormsApp1
{
    public interface IDrawable
    {
        void Update(Graphics g);
        void Hide(Graphics g, Color backColor);

        int Scale { get; set; }

        Rotation Rotation { get; set; }
        
        Animator _animator { get; set; }
    }

    public class Rotation
    {
        public int Angle;
        public Point? RotationCenter;

        public Rotation(int angle, Point? rotationCenter)
        {
            Angle = angle;
            RotationCenter = rotationCenter;
        }
    }
}