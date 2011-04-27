using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Raspisanie
{
    public partial class Form3 : Form
    {
        // The path to the key where Windows looks for startup applications
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public Form3()
        {
            InitializeComponent();
            // Check to see the current state (running at startup or not)
            if (rkApp.GetValue("EasyTrain") == null)
            {
                // The value doesn't exist, the application is not set to run at startup
                chkRun.Checked = false;
                               
            }
            else
            {
                // The value exists, the application is set to run at startup
                chkRun.Checked = true;

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (chkRun.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue("EasyTrain", Application.ExecutablePath.ToString());
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue("EasyTrain", false);
            }
            Close(); 
        }

    }
}