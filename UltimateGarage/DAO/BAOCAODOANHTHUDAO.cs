using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGarage.DAO
{
    internal class BAOCAODOANHTHUDAO
    {
        DataConnection dc;
        SqlDataAdapter da;
        private static BAOCAODOANHTHUDAO instance;  
        private BAOCAODOANHTHUDAO()
        {
            dc = new DataConnection();
        }
        public static BAOCAODOANHTHUDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BAOCAODOANHTHUDAO();
                return instance;
            }
            set { instance = value; }
        }
        public DataTable BaoCao(int thang, int nam)
        {
            SqlConnection con = dc.getConnect();
            
            
                con.Open();
                string sql = "SELECT HieuXe, SUM(TongTien) AS ThanhTien, COUNT(X.BienSo) AS SoLuot FROM PHIEUSUACHUA P, XE X WHERE P.BienSo = X.BienSo AND MONTH(NgaySuaChua) = @thang AND YEAR(NgaySuaChua) = @nam GROUP BY HieuXe";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nam", nam);
                cmd.Parameters.AddWithValue("@thang", thang);
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
        }

        public SqlDataReader TongThanhTien(int thang, int nam)
        {

            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT SUM(TongTien) AS TONGTHANHTIEN FROM PHIEUSUACHUA P, XE X WHERE MONTH(NgaySuaChua) = @thang AND YEAR(NgaySuaChua) = @nam AND P.BienSo = X.BienSo";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@thang", thang);
            cmd.Parameters.AddWithValue("@nam", nam);
            SqlDataReader dt = cmd.ExecuteReader();
            return dt;

        }
    }
}
