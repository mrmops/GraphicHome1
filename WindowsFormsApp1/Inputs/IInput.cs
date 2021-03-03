using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public interface IInput
    {
        void ParseInput();

        Control[] GetControls();
        
        string Name { get; }

    }
}