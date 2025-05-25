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
    public partial class SUAVTPT : Form
    {
        public string mavtpt { get; set; }
        public string tenvtpt { get; set; }
        public int soluong { get; set; }
        public string dongia { get; set; }

        public SUAVTPT()
        {
            InitializeComponent();
        }

        private void capnhatbtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dgtxtbox.Text) || String.IsNullOrEmpty(tenvtpttxtbox.Text))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");

            else
            {
                string ma = mavtpttxtbox.Text;
                string ten = tenvtpttxtbox.Text;
                double dg = Convert.ToDouble(dgtxtbox.Text);
                if (VTPTDAO.Instance.Sua(ma, ten, dg))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật vật tư phụ tùng thất bại!");
                    this.Close();
                }
            }
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SUAVTPT_Load(object sender, EventArgs e)
        {
            mavtpttxtbox.Text = mavtpt;
            tenvtpttxtbox.Text = tenvtpt;
            dgtxtbox.Text = dongia;
        }

        private void dgtxtbox_TextChanged(object sender, EventArgs e)
        {
            double output;
            if (!double.TryParse(dgtxtbox.Text, out output) && !String.IsNullOrEmpty(dgtxtbox.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá thích hợp!");
                dgtxtbox.Clear();
            }
        }
    }
}
