using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGarage.DAO
{
    internal class PHIEUTHUTIENDAO
    {
        DataConnection dc;
        SqlDataAdapter da;
        private static PHIEUTHUTIENDAO instance;
        private PHIEUTHUTIENDAO()
        {
            dc = new DataConnection();
        }
        public static PHIEUTHUTIENDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new PHIEUTHUTIENDAO();
                return instance;
            }
            set { instance = value; }
        }
        public DataTable TimKiemTheoMa(string s)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM PHIEUTHUTIEN WHERE MaPTT LIKE CONCAT('%', @ten, '%')";
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
            string sql = "SELECT * FROM PHIEUTHUTIEN WHERE DAY(NgayThuTien) = @ngay AND MONTH(NgayThuTien) = @thang AND YEAR(NgayThuTien) = @nam";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ngay", ngay);
            cmd.Parameters.AddWithValue("@thang", thang);
            cmd.Parameters.AddWithValue("@nam", nam);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public string LoadMaPTT()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT COUNT(*) + 1 AS SO FROM PHIEUTHUTIEN";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            string l = "";
            if (dr.Read())
                l = dr["SO"].ToString();
            return "TT" + l;
        }
        public DataTable HienThi()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM PHIEUTHUTIEN";
            SqlCommand cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool Them(string maptt, string bienso, double sotienthu)
        {
            string sql = "INSERT INTO PHIEUTHUTIEN (MaPTT, BienSo, NgayThuTien, SoTienThu) VALUES (@maptt, @bienso, GETDATE(), @sotienthu)";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                cmd.Parameters.AddWithValue("@maptt", maptt);
                cmd.Parameters.AddWithValue("@bienso", bienso);
                cmd.Parameters.AddWithValue("@sotienthu", sotienthu);
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
