using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UltimateGarage.DAO;
using System.Data.SqlClient;

namespace UltimateGarage
{
    public partial class SUATHONGTINADMIN : Form
    {
        public string tendangnhap { get; set; }
        public string matkhau { get; set; }
        public string ten { get; set; }
        public string diachi { get; set; }
        public string dth { get; set; }
        public string email { get; set; }
        public string chucvu { get; set; }


        public SUATHONGTINADMIN()
        {
            InitializeComponent();
        }

        private void SUANV_Load(object sender, EventArgs e)
        {
            tdntxtbox.Text = tendangnhap;
            tentxtbox.Text = ten;
            dthtxtbox.Text = dth;
            dctxtbox.Text = diachi;
            cvcbbox.Text = chucvu;
            emailtxtbox.Text = email;
            SqlDataReader dr = NHANVIENDAO.Instance.LoadChucVu();
            while (dr.Read())
                cvcbbox.Items.Add(dr["ChucVu"]);
        }

        private void capNhat_btnClick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tentxtbox.Text)
                || String.IsNullOrEmpty(dctxtbox.Text)
                || String.IsNullOrEmpty(dthtxtbox.Text)
                || String.IsNullOrEmpty(cvcbbox.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
                            
            string tdn = tdntxtbox.Text;
            string ten = tentxtbox.Text;
            string dc = dctxtbox.Text;
            string dth = dthtxtbox.Text;
            string email = emailtxtbox.Text;
            string cv = cvcbbox.Text;
            if (NHANVIENDAO.Instance.SuaAdmin(tdn, ten, dc, dth, email, cv))
            {
                MessageBox.Show("Cập nhập thông tin quản lý thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin quản lý thất bại!");
                this.Close();
            }
        }
        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
