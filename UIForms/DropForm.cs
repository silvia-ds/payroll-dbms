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
    public partial class DropForm : Form
    {
        public DropForm()
        {
            InitializeComponent();
            lblTables.Text = Utils.GetTableList(DBConnection.GetConnection());
        }

        // updates db based on user input
        private void BtnRun_Click(object sender, EventArgs e)
        {
            // gets textbox input, removes spaces, & converts to upper to make case insensitive
            string input = txtTableName.Text.Trim().ToUpper();
            
            // checks incase user ran without any input
            Utils.CheckEmptyInput(input);

            try
            {
                using (OracleConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    if (input == "ALL")
                    {
                        // get all tables
                        List<string> allTables = Utils.GetTableList(conn)
                            .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1) // skips the "Current tables:" header
                            .Select(t => t.Trim()) // remove any whitespace
                            .Where(t => !string.IsNullOrEmpty(t)) // remove empty strings
                            .ToList();

                        if (allTables.Count == 0)
                        {
                            MessageBox.Show("No tables to drop.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Drop all tables
                        foreach (string table in allTables)
                        {
                            try
                            {
                                DropTable(conn, table);
                            }
                            catch (Exception ex)
                            {
                                // og but continue - some tables might have dependencies
                                Console.WriteLine($"Failed to drop {table}: {ex.Message}");
                            }
                        }
                        MessageBox.Show($"Successfully dropped {allTables.Count} table(s)!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // checks if table exists
                        if (!Utils.TableExists(conn, input))
                        {
                            MessageBox.Show($"Table '{input}' does not exist. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        // drops the specific table
                        DropTable(conn, input);

                        // show remaining tables
                        string remainingTables = Utils.GetTableList(conn);
                        MessageBox.Show($"Table '{input}' dropped successfully!\n\n{remainingTables}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                // closes form and returns to main menu
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error dropping table: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // helper method to drop a table
        private void DropTable(OracleConnection conn, string tableName)
        {
            string sql = $"DROP TABLE {tableName} CASCADE CONSTRAINTS";
            using (OracleCommand cmd = new OracleCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // returns to main menu
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
