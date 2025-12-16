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
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
            InitializeTableDropdown();
        }

        // set so user can't enter table names + defaults to first table so input != null
        private void InitializeTableDropdown()
        {
            cboTable.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTable.SelectedIndex = 0;
        }

        // updates 'field' dropdown when table selection changes
        private void CboTable_SelectedValueChanged(object sender, EventArgs e)
        {
            // clear previous fields
            cboField.Items.Clear();
            // set so user can't enter custom field names
            cboField.DropDownStyle = ComboBoxStyle.DropDownList;
            string selectedTable = cboTable.SelectedItem.ToString().ToUpper();
            switch (selectedTable)
            {
                case "DEPARTMENTS":
                    cboField.Items.Add("dept_id");
                    cboField.Items.Add("manager_num");
                    cboField.Items.Add("dept_name");
                    cboField.Items.Add("location");
                    cboField.Items.Add("budget");
                    cboField.Items.Add("phone_num");
                    break;

                case "EMPLOYEES":
                    cboField.Items.Add("emp_id");
                    cboField.Items.Add("first_name");
                    cboField.Items.Add("last_name");
                    cboField.Items.Add("phone_num");
                    cboField.Items.Add("title");
                    cboField.Items.Add("email");
                    cboField.Items.Add("dept_id");
                    break;

                case "SALARY":
                    cboField.Items.Add("salary_id");
                    cboField.Items.Add("emp_id");
                    cboField.Items.Add("pay_frequency");
                    cboField.Items.Add("base_salary");
                    cboField.Items.Add("allowance");
                    cboField.Items.Add("deductions");
                    cboField.Items.Add("effective_date");
                    break;

                case "PAYROLL":
                    cboField.Items.Add("payroll_id");
                    cboField.Items.Add("salary_id");
                    cboField.Items.Add("emp_id");
                    cboField.Items.Add("pay_date");
                    cboField.Items.Add("gross_pay");
                    cboField.Items.Add("net_pay");
                    break;

                case "ATTENDANCE":
                    cboField.Items.Add("attendance_id");
                    cboField.Items.Add("emp_id");
                    cboField.Items.Add("attendance_date");
                    cboField.Items.Add("status");
                    cboField.Items.Add("hours_worked");
                    cboField.Items.Add("overtime");
                    break;
            }
            // selects first field by default
            if (cboField.Items.Count > 0)
                cboField.SelectedIndex = 0;
        }

        // tries running query once user clicks 'run'
        private void BtnRun_Click(object sender, EventArgs e)
        {
            // checks for empty string input
            Utils.CheckEmptyInput(txtSearch.Text);

            string table = cboTable.SelectedItem.ToString();
            string field = cboField.SelectedItem.ToString();
            string searchTerm = txtSearch.Text.Trim(); // trims spaces, etc
            try
            {
                using (OracleConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // first check if the search term exists
                    if (!SearchTermExists(conn, table, field, searchTerm))
                    {
                        MessageBox.Show($"No results found for '{searchTerm}' in {table}.{field}.\n\nPlease check the valid values list and try again.",
                            "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // runs the search query
                    string query = $"SELECT * FROM {table} WHERE UPPER({field}) LIKE UPPER(:searchTerm)";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("searchTerm", "%" + searchTerm + "%"));
                        string results = FormatSearchResults(cmd, table, field, searchTerm);
                        ShowResultsDialog(results, "Search Results");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // helper method to check if search term exists
        private bool SearchTermExists(OracleConnection conn, string table, string field, string searchTerm)
        {
            string query = $"SELECT COUNT(*) FROM {table} WHERE UPPER({field}) LIKE UPPER(:searchTerm)";
            using (OracleCommand cmd = new OracleCommand(query, conn))
            {
                cmd.Parameters.Add(new OracleParameter("searchTerm", "%" + searchTerm + "%"));
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // helper method to format search results
        private string FormatSearchResults(OracleCommand cmd, string table, string field, string searchTerm)
        {
            StringBuilder results = new StringBuilder();
            // header
            results.AppendLine($"Search Results");
            results.AppendLine($"Table: {table}");
            results.AppendLine($"Field: {field}");
            results.AppendLine($"Search Term: {searchTerm}");
            results.AppendLine(new string('=', 50));
            results.AppendLine();

            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                int columnCount = reader.FieldCount;
                for (int i = 0; i < columnCount; i++)
                    results.Append(reader.GetName(i).PadRight(15));
                results.AppendLine();
                results.AppendLine(new string('-', columnCount * 15));
                int rowCount = 0;
                while (reader.Read())
                {
                    for (int i = 0; i < columnCount; i++)
                    {
                        string value = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i).ToString();
                        if (value.Length > 14) // truncates long values for display
                            value = value.Substring(0, 11) + "...";
                        results.Append(value.PadRight(15));
                    }
                    results.AppendLine();
                    rowCount++;
                }
                results.AppendLine();
                results.AppendLine(new string('=', 50));
                results.AppendLine($"Total rows found: {rowCount}");
            }

            return results.ToString();
        }

        // method to display query
        private void ShowResultsDialog(string results, string title)
        {
            Form resultsForm = new Form();
            resultsForm.Text = title;
            resultsForm.Width = 800;
            resultsForm.Height = 500;
            resultsForm.StartPosition = FormStartPosition.CenterScreen;

            TextBox txtResults = new TextBox();
            txtResults.Multiline = true;
            txtResults.ReadOnly = true;
            txtResults.ScrollBars = ScrollBars.Both;
            txtResults.Dock = DockStyle.Fill;
            txtResults.Font = new Font("Consolas", 10); // Monospace font for alignment
            txtResults.Text = results;
            txtResults.WordWrap = false;

            Button btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Dock = DockStyle.Bottom;
            btnClose.Height = 40;
            btnClose.Click += (s, e) => resultsForm.Close();

            resultsForm.Controls.Add(txtResults);
            resultsForm.Controls.Add(btnClose);

            resultsForm.ShowDialog();
        }

        // closes form and returns to main menu
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // shows users their search options
        private void CboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboField.SelectedItem == null || cboTable.SelectedItem == null)
                return;
            string table = cboTable.SelectedItem.ToString();
            string field = cboField.SelectedItem.ToString();
            // clears previous values
            lstHint.Items.Clear();
            try
            {
                using (OracleConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // get distinct values from the selected field
                    string query = $"SELECT DISTINCT {field} FROM {table} ORDER BY {field}";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            lstHint.Items.Add("(No data in this field to query)");
                            return;
                        }

                        while (reader.Read())
                        {
                            string value = reader.IsDBNull(0) ? "NULL" : reader.GetValue(0).ToString();
                            lstHint.Items.Add(value);
                        }
                    }
                }
            }
            catch
            {
                lstHint.Items.Add("(Error: could not load values)");
            }
        }
    }
}
