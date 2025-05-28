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
    public partial class THONGTINADMIN : Form
    {
        public string tendangnhap { get; set; }

        public THONGTINADMIN()
        {
            InitializeComponent();
        }
        public void HienThi()
        {
            SqlDataReader data = NHANVIENDAO.Instance.HienThiThongTin(tendangnhap);
            if (data.Read())
            {
                tentxtbox.Text = data["TenNV"].ToString();
                dctxtbox.Text = data["DiaChi"].ToString();
                dthtxtbox.Text = data["DienThoai"].ToString();
                emailtxtbox.Text = data["Email"].ToString();
                chucvutxtbox.Text = data["ChucVu"].ToString();
            }
        }

        private void suaThongTinAdmin_btnClick(object sender, EventArgs e)
        {
            SUATHONGTINADMIN form = new SUATHONGTINADMIN();
            form.tendangnhap = tendangnhap;
            form.ten = tentxtbox.Text;
            form.diachi = dctxtbox.Text;
            form.dth = dthtxtbox.Text;
            form.email = emailtxtbox.Text;
            form.chucvu = chucvutxtbox.Text;

            form.ShowDialog();
            HienThi();
        }

        private void THONGTINADMIN_Load(object sender, EventArgs e)
        {
            tdntxtbox.Text = tendangnhap;
            SqlDataReader data = NHANVIENDAO.Instance.HienThiThongTin(tendangnhap);
            if (data.Read())
            {
                tentxtbox.Text = data["TenNV"].ToString();
                dctxtbox.Text = data["DiaChi"].ToString();
                dthtxtbox.Text = data["DienThoai"].ToString();
                emailtxtbox.Text = data["Email"].ToString();
                chucvutxtbox.Text = data["ChucVu"].ToString();
            }
        }

        private void doiMatKhau_btnClick(object sender, EventArgs e)
        {
            DOIMATKHAU form = new DOIMATKHAU();
            form.tendangnhap = tendangnhap;

            form.ShowDialog();
        }

        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
