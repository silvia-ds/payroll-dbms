using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client; // lets us get into school server

namespace PayrollDBMS
{
    internal class DBConnection
    {
        private static string username; // gets inputs from login form
        private static string password;

        // set credentials from form
        public static void SetCredentials(string user, string pass)
        {
            username = user;
            password = pass;
        }

        // builds connection string using user's username and password
        private static string GetConnectionString()
        {
            return $"User Id={username};" +
                   $"Password={password};" +
                   "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(Host=oracle12c.scs.ryerson.ca)(Port=1521))" +
                   "(CONNECT_DATA=(SID=orcl12c)))";
        }

        // gets a new connection
        public static OracleConnection GetConnection()
        {
            return new OracleConnection(GetConnectionString());
        }
    }
}
