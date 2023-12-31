using System;
using System.Windows.Forms;

namespace Scheduler.Forms.Controls
{
    public class PhoneNumberTextBox : TextBox
    {
        public PhoneNumberTextBox()
        {
            this.MaxLength = 8;
            this.TextAlign = HorizontalAlignment.Center;
            this.KeyPress += PhoneNumberTextBox_KeyPress;
        }

        public bool IsTextValid
        {
            get { return IsValidPhoneNumber(); }
        }

        private bool IsValidPhoneNumber()
        {
            return this.Text.Length == 8 && this.Text[3] == '-';
        }

        private void PhoneNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                if (this.SelectionStart < 3 && this.Text.Length < 3)
                {
                    e.Handled = false;
                }
                else if (this.SelectionStart == 3 && this.Text.Length == 3 && e.KeyChar == '-')
                {
                    e.Handled = false;
                }
                else if (this.SelectionStart > 3 && this.Text.Length < 8)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            
            if (this.Text.Length == 3 && !this.Text.Contains("-"))
            {
                this.Text = this.Text.Insert(3, "-");
                this.SelectionStart = 4;
            }
        }
    }

}
