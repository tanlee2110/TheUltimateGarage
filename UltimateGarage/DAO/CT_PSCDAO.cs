using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGarage.DAO
{
    internal class CT_PSCDAO
    {
        DataConnection dc;
        SqlDataAdapter da;
        private static CT_PSCDAO instance;  
        private CT_PSCDAO()
        {
            dc = new DataConnection();
        }
        public static CT_PSCDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CT_PSCDAO();
                return instance;
            }
            set { instance = value; }

        }
        public DataTable HienThi(string masc)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT NoiDung, MaVTPT, TenVTPT, SoLuong, DonGia, TienCong, ThanhTien FROM CT_PSC WHERE MaPSC = @ma";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ma", masc);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public bool Them(string mapsc, string noidung, string mavt, string tenvt, int sl, string dg, string mtc, double tc, string tt)
        {
            string sql = "INSERT INTO CT_PSC (MaPSC, NoiDung, MaVTPT, TenVTPT, SoLuong, DonGia, MaTienCong, TienCong, ThanhTien)" +
                "VALUES (@masc, @noidung, @mavt, @tenvt, @sl, @dg, @matc, @tc, @tt)";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                cmd.Parameters.AddWithValue("@masc", mapsc);
                cmd.Parameters.AddWithValue("@noidung", noidung);
                cmd.Parameters.AddWithValue("@mavt", mavt);
                cmd.Parameters.AddWithValue("@tenvt", tenvt);
                cmd.Parameters.AddWithValue("@sl", sl);
                cmd.Parameters.AddWithValue("@dg", dg);
                cmd.Parameters.AddWithValue("@matc", mtc);
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@tt", tt);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
