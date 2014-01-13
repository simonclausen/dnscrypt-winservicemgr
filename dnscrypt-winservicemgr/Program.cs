using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace dnscrypt_winservicemgr
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (AdminCheck.testAdmin())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ApplicationWindow());
            }
            else
            {
                MessageBox.Show("This program needs access to system settings.\nPlease restart the program as Administrator.", "Permission Error");
                Application.Exit();
            }
        }
    }
}
