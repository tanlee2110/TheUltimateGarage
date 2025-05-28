using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGarage.DAO
{
    internal class DataConnection
    {
        // string constr = "Data Source=vmwin11;Initial Catalog=QUANLIGARA;Integrated Security=True";
        static string machineName = Environment.MachineName;
        string constr = String.Concat("Data Source=", machineName,";Initial Catalog=QUANLIGARA;Integrated Security=True");

        public SqlConnection getConnect()
        {
            return new SqlConnection(constr);
        }
    }
    
}
