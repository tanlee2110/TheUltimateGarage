using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGarage.DAO
{
    internal class CT_PNKVTPTDAO
    {
        DataConnection dc;
        SqlDataAdapter da;
        private static CT_PNKVTPTDAO instance;
        private CT_PNKVTPTDAO()
        {
            dc = new DataConnection();
        }
        public static CT_PNKVTPTDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CT_PNKVTPTDAO();
                return instance;

            }
            set { instance = value; }
        }
        public bool Them(string mank, string mavt, string tenvt, int sl, double gn)
        {
            string sql = "INSERT INTO CT_PNKVTPT (MaNKVTPT, MaVTPT, TenVTPT, SoLuong, GiaNhap)" +
                "VALUES (@mank, @mavt, @tenvt, @sl, @gn)";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                cmd.Parameters.AddWithValue("@mank", mank);
                cmd.Parameters.AddWithValue("@mavt", mavt);
                cmd.Parameters.AddWithValue("@tenvt", tenvt);
                cmd.Parameters.AddWithValue("@sl", sl);
                cmd.Parameters.AddWithValue("@gn", gn);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public void Xoa(string mank, string mavt)
        {
            SqlConnection con = dc.getConnect();
            con.Open();

            string sql = "DELETE FROM CT_PNKVTPT WHERE MaNKVTPT = @mank AND MaVTPT = @mavt";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mank", mank);
            cmd.Parameters.AddWithValue("@mavt", mavt);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable HienThi(string mank)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT TenVTPT, MaVTPT, SoLuong, GiaNhap FROM CT_PNKVTPT WHERE MaNKVTPT = @ma";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ma", mank);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
    }
}
