using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateGarage.DAO
{
    internal class TIENCONGDAO
    {
        DataConnection dc;
        SqlDataAdapter da;
        private static TIENCONGDAO instance;
        private TIENCONGDAO()
        {
            dc = new DataConnection();
        }
        public static TIENCONGDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new TIENCONGDAO();
                return instance;
            }
            set { instance = value; }
        }
        public DataTable HienThi()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM TIENCONG";
            SqlCommand cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public bool Xoa(string mtc)
        {

            SqlConnection con = dc.getConnect();
            try
            {
                con.Open();

                string sql = "DELETE FROM TIENCONG WHERE MaTienCong = @mtc";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@mtc", mtc);
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
        public SqlDataReader LoadTienCongTheoNoiDung(string ten)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM TIENCONG WHERE NoiDung = @ten";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", ten);
            SqlDataReader dt = cmd.ExecuteReader();
            return dt;


        }
        
        public SqlDataReader LoadTienCong()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM TIENCONG";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dt = cmd.ExecuteReader();
            return dt;
        }
        
        public bool Them(string mtc, double tc, string nd)
        {
            string sql = "INSERT INTO TIENCONG (MaTienCong, TienCong, NoiDung)" +
                "VALUES (@mtc, @tc, @nd)";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                cmd.Parameters.AddWithValue("@mtc", mtc);
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@nd", nd);
         
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool Sua(string mtc, double tc, string nd)
        {
            string sql = "UPDATE TIENCONG SET TienCong = @tc, NoiDung = @nd WHERE MaTienCong = @mtc";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                    
                con.Open();
                cmd.Parameters.AddWithValue("@mtc", mtc);
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@nd", nd);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public DataTable TimKiemTheoMa(string s)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM TIENCONG WHERE MaTienCong LIKE CONCAT('%', @ten, '%')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", s);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;


        }
        public DataTable TimKiemTheoNoiDung(string s)
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT * FROM TIENCONG WHERE dbo.fuConvertToUnsign1(NoiDung) LIKE N'%' + dbo.fuConvertToUnsign1(@ten) + '%'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ten", s);
            DataTable dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;


        }
        public string LoadMaTienCong()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT COUNT(*) + 1 AS SO FROM TIENCONG";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            string l = "";
            if (dr.Read())
                l = dr["SO"].ToString();
            return "TC" + l;
        }
        public SqlDataReader LoadTienCongCBBox()
        {
            SqlConnection con = dc.getConnect();
            con.Open();
            string sql = "SELECT NoiDung FROM TIENCONG";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Connection = con;
            SqlDataReader dt = cmd.ExecuteReader();
            return dt;
        }
    }
}
