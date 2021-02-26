using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public interface IDrawableFactory
    {
        List<Control> GetControls();
        IDrawable CreateNew();
    }
}