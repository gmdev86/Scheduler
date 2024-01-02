using Scheduler.Core.Services;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Scheduler.Forms
{
    public partial class Language : Form
    {
        private UserSession _userSession;

        public Language()
        {
            InitializeComponent();
            _userSession = UserSession.Instance;
            InitializeLanguages();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeLanguages()
        {
            comboBoxLanguages.Items.Add("English");
            comboBoxLanguages.Items.Add("Spanish");
            comboBoxLanguages.Items.Add("French");
            comboBoxLanguages.SelectedIndex = 0; 
        }

        private void ApplyLanguage()
        {
            string selectedLanguage = comboBoxLanguages.SelectedItem.ToString();
            
            CultureInfo newCulture;
            switch (selectedLanguage)
            {
                case "English":
                    newCulture = new CultureInfo("en-US");
                    break;
                case "Spanish":
                    newCulture = new CultureInfo("es-ES");
                    break;
                case "French":
                    newCulture = new CultureInfo("fr-FR");
                    break;
                default:
                    newCulture = CultureInfo.CurrentCulture; 
                    break;
            }
            
            _userSession.CurrentCultureInfo = newCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = newCulture;
            
            this.Close();
        }
    }
}
