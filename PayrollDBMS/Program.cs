using Oracle.ManagedDataAccess.Client;
using PayrollDBMS.UIForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollDBMS
{
    public static class Program
    {
        /// <summary>
        /// the main entry point for the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // show login form first
            LoginForm loginForm = new LoginForm();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // login successful, now show the main menu
                Application.Run(new UIForms.MainMenu());
            }
            // else: login failed or canceled; app exits

        }
    }
}
