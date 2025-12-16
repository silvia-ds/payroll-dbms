using Oracle.ManagedDataAccess.Client;
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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        // opens new form depending on which option user selects
        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (rbDrop.Checked)
            {
                this.Hide(); // hides MainMenu
                DropForm dropForm = new DropForm();
                dropForm.ShowDialog(); // blocks until the sub form closes
                this.Show(); // returns to MainMenu
            }
            else if (rbCreate.Checked)
            {
                this.Hide();
                CreateForm createForm = new CreateForm();
                createForm.ShowDialog();
                this.Show();
            }
            else if (rbPopulate.Checked)
            {
                this.Hide();
                PopulateForm populateForm = new PopulateForm();
                populateForm.ShowDialog();
                this.Show();
            }
            else if (rbQuery.Checked)
            {
                this.Hide();
                QueryForm queryForm = new QueryForm();
                queryForm.ShowDialog();
                this.Show();
            }
            else // check in case user makes no selection
            {
                MessageBox.Show("Must make a selection. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // closes form
            Application.Exit(); // exits application
        }

    }
}
