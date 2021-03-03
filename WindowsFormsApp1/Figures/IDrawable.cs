using System.Drawing;

namespace WindowsFormsApp1
{
    public interface IDrawable
    {
        void Draw(Graphics g);
        void Hide(Graphics g, Color backColor);

        void Scale(float scaleValue);

        void Rotate(int angle, Point? rotationCenter);
    }
}