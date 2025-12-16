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
using Microsoft.VisualBasic;

namespace PayrollDBMS.UIForms
{
    public partial class PopulateForm : Form
    {
        public PopulateForm()
        {
            InitializeComponent();
            lblTables.Text = CheckAvailableTables();
        }

        private string CheckAvailableTables()
        {
            string output = "Available tables:\n";
            try
            {
                using (OracleConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // only checks for tables that were in the original schema
                    if (Utils.TableExists(conn, "SALARY"))
                        output += "Salary\n";
                    if (Utils.TableExists(conn, "PAYROLL"))
                        output += "Payroll\n";
                    if (Utils.TableExists(conn, "ATTENDANCE"))
                        output += "Attendance\n";
                    if (Utils.TableExists(conn, "EMPLOYEES"))
                        output += "Employees\n";
                    if (Utils.TableExists(conn, "DEPARTMENTS"))
                        output += "Departments\n";
                    return output;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // shouldnt reach this but just in case
            return "No available tables. Click 'Back' to return to Main Menu.";
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {

            // gets textbox input, removes spaces, & converts to upper to make case insensitive
            string input = txtTableName.Text.Trim().ToUpper();

            // checks for null input
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a table name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (OracleConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    // checks if table exists and is in original schema
                    if (!Utils.TableExists(conn, input))
                    {
                        MessageBox.Show($"Table '{input}' does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // calls populate method based on input
                    bool success = false;
                    switch (input)
                    {
                        case "DEPARTMENTS":
                            success = PopulateDepartments(conn);
                            break;
                        case "EMPLOYEES":
                            success = PopulateEmployees(conn);
                            break;
                        case "SALARY":
                            success = PopulateSalary(conn);
                            break;
                        case "PAYROLL":
                            success = PopulatePayroll(conn);
                            break;
                        case "ATTENDANCE":
                            success = PopulateAttendance(conn);
                            break;
                        default:
                            MessageBox.Show("Can only populate tables from original schema:\nDepartments, Employees, Salary, Payroll, Attendance",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }
                    if (success)
                    {
                        MessageBox.Show($"Successfully inserted data into {input}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error populating table: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // helper method to get user input
        private string GetUserInput(string prompt, bool allowEmpty = false)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(prompt, "Enter Value", "");
            if (!allowEmpty && string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Input cannot be empty.");
            }

            return input.Trim();
        }

        // populates 'Departments' table
        private bool PopulateDepartments(OracleConnection conn)
        {
            try
            {
                string deptId = GetUserInput("Enter Department ID:");
                string managerNum = GetUserInput("Enter Manager Number (leave empty for NULL):", true);
                string deptName = GetUserInput("Enter Department Name:");
                string location = GetUserInput("Enter Location:");
                string budget = GetUserInput("Enter Budget:");
                string phoneNum = GetUserInput("Enter Phone Number:");

                string sql = "INSERT INTO Departments (dept_id, manager_num, dept_name, location, budget, phone_num) " +
                            "VALUES (:dept_id, :manager_num, :dept_name, :location, :budget, :phone_num)";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("dept_id", int.Parse(deptId)));
                    cmd.Parameters.Add(new OracleParameter("manager_num",
                        string.IsNullOrEmpty(managerNum) ? (object)DBNull.Value : int.Parse(managerNum)));
                    cmd.Parameters.Add(new OracleParameter("dept_name", deptName));
                    cmd.Parameters.Add(new OracleParameter("location", location));
                    cmd.Parameters.Add(new OracleParameter("budget", decimal.Parse(budget)));
                    cmd.Parameters.Add(new OracleParameter("phone_num", phoneNum));

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // populates 'Employees' table
        private bool PopulateEmployees(OracleConnection conn)
        {
            try
            {
                string empId = GetUserInput("Enter Employee ID:");
                string firstName = GetUserInput("Enter First Name:");
                string lastName = GetUserInput("Enter Last Name:");
                string phoneNum = GetUserInput("Enter Phone Number:");
                string title = GetUserInput("Enter Title:");
                string email = GetUserInput("Enter Email:");
                string deptId = GetUserInput("Enter Department ID:");

                string sql = "INSERT INTO Employees (emp_id, first_name, last_name, phone_num, title, email, dept_id) " +
                            "VALUES (:emp_id, :first_name, :last_name, :phone_num, :title, :email, :dept_id)";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("emp_id", int.Parse(empId)));
                    cmd.Parameters.Add(new OracleParameter("first_name", firstName));
                    cmd.Parameters.Add(new OracleParameter("last_name", lastName));
                    cmd.Parameters.Add(new OracleParameter("phone_num", phoneNum));
                    cmd.Parameters.Add(new OracleParameter("title", title));
                    cmd.Parameters.Add(new OracleParameter("email", email));
                    cmd.Parameters.Add(new OracleParameter("dept_id", int.Parse(deptId)));

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // populates 'Salary' table
        private bool PopulateSalary(OracleConnection conn)
        {
            try
            {
                string salaryId = GetUserInput("Enter Salary ID:");
                string empId = GetUserInput("Enter Employee ID:");
                string payFrequency = GetUserInput("Enter Pay Frequency:");
                string baseSalary = GetUserInput("Enter Base Salary:");
                string allowance = GetUserInput("Enter Allowance:");
                string deductions = GetUserInput("Enter Deductions:");
                string effectiveDate = GetUserInput("Enter Effective Date (YYYY-MM-DD):");

                string sql = "INSERT INTO Salary (salary_id, emp_id, pay_frequency, base_salary, allowance, deductions, effective_date) " +
                            "VALUES (:salary_id, :emp_id, :pay_frequency, :base_salary, :allowance, :deductions, TO_DATE(:effective_date, 'YYYY-MM-DD'))";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("salary_id", int.Parse(salaryId)));
                    cmd.Parameters.Add(new OracleParameter("emp_id", int.Parse(empId)));
                    cmd.Parameters.Add(new OracleParameter("pay_frequency", payFrequency));
                    cmd.Parameters.Add(new OracleParameter("base_salary", decimal.Parse(baseSalary)));
                    cmd.Parameters.Add(new OracleParameter("allowance", decimal.Parse(allowance)));
                    cmd.Parameters.Add(new OracleParameter("deductions", decimal.Parse(deductions)));
                    cmd.Parameters.Add(new OracleParameter("effective_date", effectiveDate));

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // populates 'Payroll' table
        private bool PopulatePayroll(OracleConnection conn)
        {
            try
            {
                string payrollId = GetUserInput("Enter Payroll ID:");
                string salaryId = GetUserInput("Enter Salary ID:");
                string empId = GetUserInput("Enter Employee ID:");
                string payDate = GetUserInput("Enter Pay Date (YYYY-MM-DD):");
                string grossPay = GetUserInput("Enter Gross Pay:");
                string netPay = GetUserInput("Enter Net Pay:");

                string sql = "INSERT INTO Payroll (payroll_id, salary_id, emp_id, pay_date, gross_pay, net_pay) " +
                            "VALUES (:payroll_id, :salary_id, :emp_id, TO_DATE(:pay_date, 'YYYY-MM-DD'), :gross_pay, :net_pay)";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("payroll_id", int.Parse(payrollId)));
                    cmd.Parameters.Add(new OracleParameter("salary_id", int.Parse(salaryId)));
                    cmd.Parameters.Add(new OracleParameter("emp_id", int.Parse(empId)));
                    cmd.Parameters.Add(new OracleParameter("pay_date", payDate));
                    cmd.Parameters.Add(new OracleParameter("gross_pay", decimal.Parse(grossPay)));
                    cmd.Parameters.Add(new OracleParameter("net_pay", decimal.Parse(netPay)));

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // populates 'Attendance' table
        private bool PopulateAttendance(OracleConnection conn)
        {
            try
            {
                string attendanceId = GetUserInput("Enter Attendance ID:");
                string empId = GetUserInput("Enter Employee ID:");
                string attendanceDate = GetUserInput("Enter Attendance Date (YYYY-MM-DD):");
                string status = GetUserInput("Enter Status:");
                string hoursWorked = GetUserInput("Enter Hours Worked:");
                string overtime = GetUserInput("Enter Overtime:");

                string sql = "INSERT INTO Attendance (attendance_id, emp_id, attendance_date, status, hours_worked, overtime) " +
                            "VALUES (:attendance_id, :emp_id, TO_DATE(:attendance_date, 'YYYY-MM-DD'), :status, :hours_worked, :overtime)";

                using (OracleCommand cmd = new OracleCommand(sql, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("attendance_id", int.Parse(attendanceId)));
                    cmd.Parameters.Add(new OracleParameter("emp_id", int.Parse(empId)));
                    cmd.Parameters.Add(new OracleParameter("attendance_date", attendanceDate));
                    cmd.Parameters.Add(new OracleParameter("status", status));
                    cmd.Parameters.Add(new OracleParameter("hours_worked", decimal.Parse(hoursWorked)));
                    cmd.Parameters.Add(new OracleParameter("overtime", decimal.Parse(overtime)));

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // returns to main menu
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
