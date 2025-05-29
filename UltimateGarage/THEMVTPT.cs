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
    public partial class THEMVTPT : Form
    {
        public THEMVTPT()
        {
            InitializeComponent();
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thembtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tenvttxtbox.Text))

                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            else
            {
                string ma = mavttxtbox.Text;
                string ten = tenvttxtbox.Text;
                if (VTPTDAO.Instance.Them(ma, ten))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm vật tư phụ tùng thất bại!");
                    this.Close();
                }
            }
        }

        private void THEMVTPT_Load(object sender, EventArgs e)
        {
            mavttxtbox.Text = VTPTDAO.Instance.LoadMAVTPT();
        }
    }
}
