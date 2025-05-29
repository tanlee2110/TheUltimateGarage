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
    public partial class SUATIENCONG : Form
    {
        public string matiencong { get; set; }
        public string tiencong { get; set; }
        public string noidung { get; set; }
        public SUATIENCONG()
        {
            InitializeComponent();
        }



        private void ChangeWageForm_Load(object sender, EventArgs e)
        {
            matctxtbox.Text = matiencong;
            tctxtbox.Text = tiencong;
            ndtxtbox.Text = noidung;
        }

        private void suabtn_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(tctxtbox.Text) || String.IsNullOrEmpty(ndtxtbox.Text))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");

            else
            {
                string mtc = matctxtbox.Text;
                double tc = Convert.ToDouble(tctxtbox.Text);
                string nd = ndtxtbox.Text;
                if (TIENCONGDAO.Instance.Sua(mtc, tc, nd))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật loại tiền công thất bại!");
                    this.Close();
                }
            }
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
