using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGarage.DAO
{
    internal class NHANVIENDAO
    {
        DataConnection dc;
        SqlDataAdapter da;
        public int flag { get; set; }
        private static NHANVIENDAO instance;
        private NHANVIENDAO()
        {
            dc = new DataConnection();
        }
        public static NHANVIENDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NHANVIENDAO();
                return instance;
            }
            set { instance = value; }

        }
        public DataTable HienThi()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM NHANVIEN WHERE ChucVu != N'Quản lý'";
            SqlCommand cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public bool DoiMatKhau(string tdn, string mk)
        {
            string sql = "UPDATE NHANVIEN SET MatKhau = @mk WHERE TenDangNhap = @tdn";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                cmd.Parameters.AddWithValue("@tdn", tdn);
                cmd.Parameters.AddWithValue("@mk", mk);
                
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public SqlDataReader LoadChucVu()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM CHUCVU";
            SqlCommand cmd = new SqlCommand(sql, con);
          
            cmd.ExecuteNonQuery();
            SqlDataReader dt = cmd.ExecuteReader();
            return dt;

        }
        public SqlDataReader HienThiThongTin(string tdn)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM NHANVIEN WHERE TenDangNhap = @tdn";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@tdn", tdn);
            cmd.ExecuteNonQuery();
            SqlDataReader dt = cmd.ExecuteReader();
            return dt;
           
        }
        public bool Sua(string tdn, string mk, string ten, string diachi, string dth, string email, string cv)
        {
            string sql = "UPDATE NHANVIEN SET MatKhau = @mk, TenNV = @ten, DienThoai = @dth, DiaChi = @dc, Email = @email, ChucVu = @cv WHERE TenDangNhap = @tdn";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                cmd.Parameters.AddWithValue("@tdn", tdn);
                cmd.Parameters.AddWithValue("@mk", mk);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@dth", dth);
                cmd.Parameters.AddWithValue("@dc", diachi);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@cv", cv);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool SuaAdmin(string tdn, string ten, string diachi, string dth, string email, string cv)
        {
            string sql = "UPDATE NHANVIEN SET TenNV = @ten, DienThoai = @dth, DiaChi = @dc, Email = @email, ChucVu = @cv WHERE TenDangNhap = @tdn";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                cmd.Parameters.AddWithValue("@tdn", tdn);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@dth", dth);
                cmd.Parameters.AddWithValue("@dc", diachi);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@cv", cv);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public DataTable TimKiemTheoTenDangNhap(string s)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM NHANVIEN WHERE dbo.fuConvertToUnsign1(TenDangNhap) LIKE N'%' +dbo.fuConvertToUnsign1(@ten) + '%' AND ChucVu != N'Quản lý'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", s);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;


        }
        public DataTable TimKiemTheoTen(string s)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM NHANVIEN WHERE dbo.fuConvertToUnsign1(TenNV) LIKE N'%' +dbo.fuConvertToUnsign1(@ten) + '%' AND ChucVu != N'Quản lý'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", s);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;


        }
        public bool DangNhap(string username, string password)
        {
            bool l = false;
            SqlConnection con = dc.getConnect();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DANGNHAP";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                l = true;
                if (dr["ChucVu"].ToString() == "Quản lý")
                    flag = 1;
                else 
                    flag = 2;
            }
            return l;
        }
        public DataTable TimKiemTheoSDT(string s)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM NHANVIEN WHERE DienThoai LIKE CONCAT('%', @ten, '%') AND ChucVu != N'Quản lý'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", s);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;


        }
        public bool Them(string tdn, string mk, string ten, string diachi, string dth, string email, string cv)
        {
            string sql = "INSERT INTO NHANVIEN (TenDangNhap, MatKhau, TenNV, DienThoai, Email, DiaChi, ChucVu) " +
                "VALUES(@tdn, @mk, @ten, @dth, @email, @dc, @cv)";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                cmd.Parameters.AddWithValue("@tdn", tdn);
                cmd.Parameters.AddWithValue("@mk", mk);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@dth", dth);
                cmd.Parameters.AddWithValue("@dc", diachi);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@cv", cv);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public void Xoa(string tdn)
        {
            SqlConnection con = dc.getConnect();
            con.Open();

            string sql = "DELETE FROM NHANVIEN WHERE TenDangNhap = @tdn";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@tdn", tdn);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
