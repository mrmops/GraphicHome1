using System.Drawing;

namespace WindowsFormsApp1._3DFigures
{
    public abstract class Figure3D: IDrawable
    {
        protected abstract Point3D[] GetPoints();
        
        public void Update(Graphics g)
        {
            throw new System.NotImplementedException();
        }

        public void Hide(Graphics g, Color backColor)
        {
            throw new System.NotImplementedException();
        }

        public int Scale { get; set; }
        public Rotation Rotation { get; set; }
        public Animator _animator { get; set; }
    }
}