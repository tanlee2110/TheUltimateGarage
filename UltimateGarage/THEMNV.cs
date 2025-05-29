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
    public partial class THEMNV : Form
    {
        public THEMNV()
        {
            InitializeComponent();
            LoadChucVu();
        }
        public void LoadChucVu()
        {
            SqlDataReader dr = NHANVIENDAO.Instance.LoadChucVu();
            while (dr.Read())
                cvcbbox.Items.Add(dr["ChucVu"]);
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thembtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tdntxtbox.Text) || String.IsNullOrEmpty(mktxtbox.Text) || String.IsNullOrEmpty(tentxtbox.Text)
                || String.IsNullOrEmpty(dctxtbox.Text) || String.IsNullOrEmpty(dthtxtbox.Text) || String.IsNullOrEmpty(emailtxtbox.Text) || String.IsNullOrEmpty(cvcbbox.Text))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            else
            {
                string tdn = tdntxtbox.Text;
                string mk = mktxtbox.Text;
                string ten = tentxtbox.Text;
                string diachi = dctxtbox.Text;
                string dth = dthtxtbox.Text;
                string email = emailtxtbox.Text;
                string cv = cvcbbox.Text;
                if (NHANVIENDAO.Instance.Them(tdn, mk, ten, diachi, dth, email, cv))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!");
                    this.Close();
                }
            }
        }
    }
}
