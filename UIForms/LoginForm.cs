using Oracle.ManagedDataAccess.Client;
using PayrollDBMS.PayrollDBMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollDBMS.UIForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            // checks user inputs
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                MessageBox.Show("Please enter a username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // sets credentials in DBConnection
            DBConnection.SetCredentials(txtUser.Text.Trim(), txtPassword.Text);

            // test connection
            if (TestDatabaseConnection())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {   // lets user try again
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // attempts to connect to school server
        private bool TestDatabaseConnection()
        {
            try
            {
                using (OracleConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    return true; // connection was successful, can proceed to main menu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }
    }
}
