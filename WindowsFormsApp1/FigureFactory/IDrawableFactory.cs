using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public interface IDrawableFactory
    {
        IEnumerable<Control> GetControls();
        IDrawable CreateNew();
    }
}