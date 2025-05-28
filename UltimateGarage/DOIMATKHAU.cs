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

namespace UltimateGarage
{
    public partial class DOIMATKHAU : Form
    {
        public string tendangnhap { get; set; }
        public string matkhaucu { get; set; }

        public DOIMATKHAU()
        {
            InitializeComponent();
        }



        private void doiMatKhau_btnClick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(mkctxtbox.Text) || String.IsNullOrEmpty(nhaplaitxtbox.Text) || String.IsNullOrEmpty(mkmtxtbox.Text))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            else
            {
                string username = tendangnhap;
                string password = mkctxtbox.Text;
                if (!NHANVIENDAO.Instance.DangNhap(username, password))
                    MessageBox.Show("Mật khẩu cũ không đúng!");
                else if (mkmtxtbox.Text != nhaplaitxtbox.Text)
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu trùng nhau!");
                }
                else
                {
                    NHANVIENDAO.Instance.DoiMatKhau(tendangnhap, mkmtxtbox.Text);
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    this.Close();
                }
            }
        }

        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
