using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UltimateGarage.DAO
{
    internal class DataConnection
    {
        // string constr = "Data Source=vmwin11;Initial Catalog=QUANLIGARA;Integrated Security=True";
        static string machineName = Environment.MachineName;
        string constr = String.Concat("Data Source=", machineName, "\\SQLEXPRESS", ";Initial Catalog=QUANLIGARA;Integrated Security=True");

        public SqlConnection getConnect()
        {
            Debug.WriteLine(machineName);
            return new SqlConnection(constr);

        }
    }
    
}
