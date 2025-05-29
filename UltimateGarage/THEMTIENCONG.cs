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
    public partial class THEMTIENCONG : Form
    {
        public THEMTIENCONG()
        {
            InitializeComponent();
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thembtn_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(tctxtbox.Text) || String.IsNullOrEmpty(ndtxtbox.Text))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");

            else
            {
                string matc = matctxtbox.Text;
                double tc = Convert.ToDouble(tctxtbox.Text);
                string nd = ndtxtbox.Text;
                if (TIENCONGDAO.Instance.Them(matc, tc, nd))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm loại tiền công thất bại!");
                    this.Close();
                }
            }
        }

        private void THEMTIENCONG_Load(object sender, EventArgs e)
        {
            matctxtbox.Text = TIENCONGDAO.Instance.LoadMaTienCong();
        }

        private void tctxtbox_TextChanged(object sender, EventArgs e)
        {
            double output;
            if (!double.TryParse(tctxtbox.Text, out output) && !String.IsNullOrEmpty(tctxtbox.Text))
            {
                MessageBox.Show("Vui lòng nhập tiền công thích hợp!");
                tctxtbox.Clear();
            }
        }
    }
}
