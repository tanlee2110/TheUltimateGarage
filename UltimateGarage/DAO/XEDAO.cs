using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGarage.DAO
{
    internal class XEDAO
    {
        DataConnection dc;
        SqlDataAdapter da;
        private static XEDAO instance;
        private SqlDbType sqlDbType;

        private XEDAO()
        {
            dc = new DataConnection();
        }
        public DataTable HienThi()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM XE";
            SqlCommand cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable HienThiXeNhapTrongNgay()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM Xe WHERE" +
                " convert(date,NgayTiepNhan) = convert(date,getdate())";
            SqlCommand cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public SqlDataReader LoadBienSo()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM XE";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dt = cmd.ExecuteReader();
            return dt;
        }
        public SqlDataReader LoadThongTinTheoBienSo(string bienso)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM XE WHERE BienSo = @bienso";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@bienso", bienso);
            SqlDataReader dt = cmd.ExecuteReader();
            return dt;
        }
        public static XEDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new XEDAO();
                return instance;

            }
            set { instance = value; }
        }
        public bool XoaXe(string bienso)
        {
            SqlConnection con = dc.getConnect();
            try
            {
                con.Open();

                string sql = "DELETE FROM XE WHERE BienSo = @bienso";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@bienso", bienso);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public DataTable TimKiemTheoTen(string s)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM XE WHERE dbo.fuConvertToUnsign1(TenChuXe) LIKE N'%' +dbo.fuConvertToUnsign1(@ten) + '%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", s);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;


        }
        public DataTable TimKiemTheoBienSo(string s)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM XE WHERE BienSo LIKE CONCAT('%', @ten, '%')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", s);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;


        }
        public DataTable TimKiemTheoSDT(string s)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM XE WHERE DienThoai LIKE CONCAT('%', @ten, '%')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", s);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable TimKiemTheoNgay(string s)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM XE WHERE NgayTiepNhan LIKE convert(smalldatetime,@s)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@s", s);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public bool TiepNhanXe(string bienso, string ten, string hieuxe, string dchi, string dth, string email)
        {
            string sql = "INSERT INTO XE (BienSo, TenChuXe, HieuXe, DiaChi, DienThoai, Email, TienNo, NgayTiepNhan)" +
                "VALUES (@bienso, @ten, @hieuxe, @diachi, @dth, @email, 0, GETDATE())";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                cmd.Parameters.AddWithValue("@bienso", bienso);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@hieuxe", hieuxe);
                cmd.Parameters.AddWithValue("@diachi", dchi);
                cmd.Parameters.AddWithValue("@dth", dth);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool SuaTienNo(string bienso, double tn)
        {
            string sql = "UPDATE XE SET TienNo = @tn WHERE BienSo = @bienso";
            SqlConnection con = dc.getConnect();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@bienso", bienso);
               
                cmd.Parameters.AddWithValue("@tn", tn);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool Sua(string bienso, string ten, string hieu, string diachi, string dth, string email)
        {
            string sql = "UPDATE XE SET TenChuXe = @ten, HieuXe = @hieuxe, DiaChi = @diachi, DienThoai = @dienthoai, Email = @email WHERE BienSo = @bienso";
            SqlConnection con = dc.getConnect();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@bienso", bienso);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@hieuxe", hieu);
                cmd.Parameters.AddWithValue("@diachi", diachi);
                cmd.Parameters.AddWithValue("@dienthoai", dth);
                cmd.Parameters.AddWithValue("@email", email);
               
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
