using System.Windows.Forms;

namespace Scheduler.Core.Utility
{
    public static class TextBoxExtension
    {
        public static string Trim(this TextBox textBox)
        {
            return textBox.Text.Trim();
        }
    }
}
