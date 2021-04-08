using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public interface IInput
    {
        void SubmitData();

        Control[] GetControls();
        
        string Name { get; }

    }
}