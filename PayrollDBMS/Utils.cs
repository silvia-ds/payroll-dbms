using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollDBMS.PayrollDBMS
{
    internal class Utils
    {
        // returns a string of table names
        public static string GetTableList(OracleConnection conn)
        {
            // double check a connection is open
            if (conn.State != ConnectionState.Open)
                conn.Open();
            string query = "SELECT table_name FROM user_tables ORDER BY table_name";
            string tableList = "Current tables:\n";
            using (OracleCommand cmd = new OracleCommand(query, conn))
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                    return "No tables in database";
                while (reader.Read())
                    tableList += "\n" + reader["table_name"].ToString();
            }
            conn.Close();
            return tableList;
        }

        // checks if a table exists
        public static bool TableExists(OracleConnection conn, string tableName)
        {
            string query = "SELECT COUNT(*) FROM user_tables WHERE table_name = :tableName";
            using (OracleCommand cmd = new OracleCommand(query, conn))
            {
                cmd.Parameters.Add(new OracleParameter("tableName", tableName));
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // checks incase user runs form without any input
        public static void CheckEmptyInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a valid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
