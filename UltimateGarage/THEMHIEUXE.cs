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
    public partial class THEMHIEUXE : Form
    {
        public THEMHIEUXE()
        {
            InitializeComponent();
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thembtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(themtxtbox.Text))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            else
            {
                string s = themtxtbox.Text;
                if (HIEUXEDAO.Instance.Them(s))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm hiệu xe thất bại!");
                    this.Close();
                }
            }
        }
    }
}
