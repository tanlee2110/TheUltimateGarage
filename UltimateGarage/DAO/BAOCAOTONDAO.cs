using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGarage.DAO
{
    internal class BAOCAOTONDAO
    {
        DataConnection dc;
        SqlDataAdapter da;
        private static BAOCAOTONDAO instance;
        private BAOCAOTONDAO()
        {
            dc = new DataConnection();
        }
        public static BAOCAOTONDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BAOCAOTONDAO();
                return instance;
            }
            set { instance = value; }
        }
        public DataTable PhatSinhVaSuDung(int thang, int nam)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "BAOCAOTON @thang, @nam";
            SqlCommand cmd = new SqlCommand(sql, con); 
            cmd.Parameters.AddWithValue("@nam", nam);
            cmd.Parameters.AddWithValue("@thang", thang);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        
    }
}
