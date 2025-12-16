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
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
            lblTables.Text = Utils.GetTableList(DBConnection.GetConnection());
        }

        // updates db based on user input
        private void BtnRun_Click(object sender, EventArgs e)
        {
            // gets textbox input, removes spaces, & converts to upper to make case insensitive
            string input = txtTableName.Text.Trim().ToUpper();

            // checks for null input
            Utils.CheckEmptyInput(input);

            // check for invalid characters in table name
            if (!IsValidTableName(input))
            {
                MessageBox.Show("Table name can only contain letters, numbers, and underscores, and must start with a letter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OracleConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // checks if table name already exists
                    if (Utils.TableExists(conn, input))
                        MessageBox.Show("Table already exists. Please enter a unique table name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        // creates table with a simple id column
                        string sql = $"CREATE TABLE {input} (id NUMBER)";
                        using (OracleCommand cmd = new OracleCommand(sql, conn))
                            cmd.ExecuteNonQuery();

                        // show success msg w updated table list
                        string updatedTables = Utils.GetTableList(conn);
                        MessageBox.Show($"Table '{input}' created successfully!\n\n{updatedTables}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // close form and return to main menu
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating table: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // helper method to check for valid table name
        private bool IsValidTableName(string tableName)
        {
            // table names must:
            // 1.   be 30 chars or less
            if (string.IsNullOrEmpty(tableName) || tableName.Length > 30)
                return false;

            // 2.   start with a letter
            if (!char.IsLetter(tableName[0]))
                return false;

            // 3.   contain only letters, numbers, underscores, $, #
            foreach (char c in tableName)
            {
                if (!char.IsLetterOrDigit(c) && c != '_' && c != '$' && c != '#')
                    return false;
            }

            return true;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
