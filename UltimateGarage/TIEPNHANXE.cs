using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UltimateGarage.DAO;

namespace UltimateGarage
{
    public partial class TIEPNHANXE : Form
    {
        public TIEPNHANXE()
        {
            InitializeComponent();
            LoadHieuXe();
        }

        public void LoadHieuXe()
        {
            SqlDataReader dr = HIEUXEDAO.Instance.HienThiCBBox();
            while (dr.Read())
            {
                hieuxecbbox.Items.Add(dr["HieuXe"]);
            }
        }

        public bool TiepNhan(string bs, string t, string h, string d, string dth, string email)
        {

            return XEDAO.Instance.TiepNhanXe(bs, t, h, d, dth, email);
        }

        private void tiepnhanbtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(biensotxtbox.Text) || String.IsNullOrEmpty(tentxtbox.Text)
                || String.IsNullOrEmpty(hieuxecbbox.Text) || String.IsNullOrEmpty(diachitxtbox.Text)
                    || String.IsNullOrEmpty(dthtxtbox.Text) || String.IsNullOrEmpty(emailtxtbox.Text))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            else
            {
                string bs = biensotxtbox.Text;
                string t = tentxtbox.Text;
                string h = hieuxecbbox.Text;
                string d = diachitxtbox.Text;
                string dth = dthtxtbox.Text;
                string email = emailtxtbox.Text;
                if (TiepNhan(bs, t, h, d, dth, email))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Trùng biển số/ Vượt quá số xe tiếp nhận trong ngày", "Tiếp nhận xe thất bại!");
                    this.Close();
                }
            }
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hieuxecbbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
