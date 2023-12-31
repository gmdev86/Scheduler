using System.Windows.Forms;
using Scheduler.Core.Localization;

namespace Scheduler.Core.Utility
{
    public class Dialog
    {
        public static DialogResult ShowDeleteConfirmation()
        {
            string message = Resources.AreYouSureDelete;
            string caption = Resources.DeleteConfirmation;
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult result = MessageBox.Show(message, caption, buttons, icon);

            return result;
        }
    }
}
