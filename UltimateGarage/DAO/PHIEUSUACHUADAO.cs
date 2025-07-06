using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGarage.DAO
{
    internal class PHIEUSUACHUADAO
    {
        DataConnection dc;
        SqlDataAdapter da;
        private static PHIEUSUACHUADAO instance;
        private PHIEUSUACHUADAO()
        {
            dc = new DataConnection();
        }
        public static PHIEUSUACHUADAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PHIEUSUACHUADAO();
                return instance;
            }
            set { instance = value; }
        }
        public DataTable TimKiemTheoNgay(int ngay, int thang, int nam)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM PHIEUSUACHUA WHERE DAY(NgaySuaChua) = @ngay AND MONTH(NgaySuaChua) = @thang AND YEAR(NgaySuaChua) = @nam";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ngay", ngay);
            cmd.Parameters.AddWithValue("@thang", thang);
            cmd.Parameters.AddWithValue("@nam", nam);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public bool Them(string masc, string bienso, double tongtien, DateTime ngaySuaChua)
        {
            string sql = "INSERT INTO PHIEUSUACHUA (MaPSC, BienSo, NgaySuaChua, TongTien) VALUES (@masc, @bienso, @ngaySuaChua, @tongtien)";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@masc", masc);
                cmd.Parameters.AddWithValue("@bienso", bienso);
                cmd.Parameters.AddWithValue("@ngaySuaChua", ngaySuaChua);
                cmd.Parameters.AddWithValue("@tongtien", tongtien);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public string LoadMPSC()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT COUNT(*) + 1 AS SO FROM PHIEUSUACHUA";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            string l = "";
            if (dr.Read())
                l = dr["SO"].ToString();
            return "SC" + l;
        }
        public DataTable HienThi()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM PHIEUSUACHUA";
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
            string sql = "SELECT * FROM PHIEUSUACHUA WHERE MaPSC LIKE CONCAT('%', @ten, '%')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", s);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public bool Xoa(string maPSC)
        {
            SqlConnection con = dc.getConnect();
            try
            {
                con.Open();

                // Xóa chi tiết phiếu sửa chữa trước
                string sql1 = "DELETE FROM CT_PSC WHERE MaPSC = @maPSC";
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                cmd1.Parameters.AddWithValue("@maPSC", maPSC);
                cmd1.ExecuteNonQuery();

                // Sau đó xóa phiếu sửa chữa
                string sql2 = "DELETE FROM PHIEUSUACHUA WHERE MaPSC = @maPSC";
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                cmd2.Parameters.AddWithValue("@maPSC", maPSC);
                cmd2.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu sửa chữa: " + ex.Message);
                return false;
            }
            return true;
        }

    }
}
