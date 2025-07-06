using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGarage.DAO
{
    internal class PNKVTPTDAO
    {
        DataConnection dc;
        SqlDataAdapter da;
        private static PNKVTPTDAO instance;
        private PNKVTPTDAO()
        {
            dc = new DataConnection();
        }
        public static PNKVTPTDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PNKVTPTDAO();
                return instance;
            }
            set { instance = value; }
        }
        public DataTable HienThi()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM PHIEUNHAPKHOVTPT";
            SqlCommand cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable TimKiemTheoMa(string s)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM PHIEUNHAPKHOVTPT WHERE MaNKVTPT LIKE CONCAT('%', @ten, '%')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", s);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable TimKiemTheoNgay(int ngay, int thang, int nam)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM PHIEUNHAPKHOVTPT WHERE DAY(NgayNhap) = @ngay AND MONTH(NgayNhap) = @thang AND YEAR(NgayNhap) = @nam";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ngay", ngay);
            cmd.Parameters.AddWithValue("@thang", thang);
            cmd.Parameters.AddWithValue("@nam", nam);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public bool Them(string mnk)
        {
            string sql = "INSERT INTO PHIEUNHAPKHOVTPT (MaNKVTPT, NgayNhap) VALUES (@mank, GETDATE())";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                
                con.Open();
                cmd.Parameters.AddWithValue("@mank", mnk);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public string LoadMPN()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT COUNT(*) + 1 AS SO FROM PHIEUNHAPKHOVTPT";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            string l = "";
            if (dr.Read())
                l = dr["SO"].ToString();
            return "NK" + l;
        }
        public bool Xoa(string maNKVTPT)
        {
            SqlConnection con = dc.getConnect();
            try
            {
                con.Open();
                // Xóa chi tiết phiếu nhập trước
                string sql1 = "DELETE FROM CT_PNKVTPT WHERE MaNKVTPT = @maNKVTPT";
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                cmd1.Parameters.AddWithValue("@maNKVTPT", maNKVTPT);
                cmd1.ExecuteNonQuery();

                // Sau đó xóa phiếu nhập
                string sql2 = "DELETE FROM PHIEUNHAPKHOVTPT WHERE MaNKVTPT = @maNKVTPT";
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                cmd2.Parameters.AddWithValue("@maNKVTPT", maNKVTPT);
                cmd2.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi xóa phiếu nhập kho: " + ex.Message);
                return false;
            }
            return true;
        }
    }
}
