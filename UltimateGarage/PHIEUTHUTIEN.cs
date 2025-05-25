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
    public partial class PHIEUTHUTIEN : Form
    {
        int flag;
        public PHIEUTHUTIEN()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PHIEUTHUTIEN_Load(object sender, EventArgs e)
        {
            matttxtbox.Text = PHIEUTHUTIENDAO.Instance.LoadMaPTT();
            SqlDataReader dr = XEDAO.Instance.LoadBienSo();
            while (dr.Read())
            {
                biensocbbox.Items.Add(dr["BienSo"]);
            }
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void biensocbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader dr = XEDAO.Instance.LoadThongTinTheoBienSo(biensocbbox.Text);
            if (dr.Read())
            {
                tentxtbox.Text = dr["TenChuXe"].ToString();
                hieuxetxtbox.Text = dr["HieuXe"].ToString();
                diachitxtbox.Text = dr["DiaChi"].ToString();
                dthtxtbox.Text = dr["DienThoai"].ToString();
                emailtxtbox.Text = dr["Email"].ToString();
                tiennotxtbox.Text = dr["TienNo"].ToString();
                if (Convert.ToDouble(tiennotxtbox.Text) == 0)
                {
                    MessageBox.Show("Đã trả hết nợ!");
                    flag = 1;
                }
            }
        }

        private void tienthutxtbox_TextChanged(object sender, EventArgs e)
        {
            double output;
            double tienconno;


            if (!Double.TryParse(tienthutxtbox.Text, out output) && !String.IsNullOrEmpty(tienthutxtbox.Text))
            {
                MessageBox.Show("Vui lòng nhập tiền thu thích hợp!");
                tienthutxtbox.Clear();
            }
            else
            {
                if (!String.IsNullOrEmpty(biensocbbox.Text))
                {
                    if (String.IsNullOrEmpty(tienthutxtbox.Text))
                    {
                        tienconnotxtbox.Text = "0"
    ;
                    }
                    else
                    {
                        double tienno = Convert.ToDouble(tiennotxtbox.Text);
                        double tienthu = Convert.ToDouble(tienthutxtbox.Text);
                        if (tienthu > tienno)
                        {
                            MessageBox.Show("Tiền thu không được lớn hơn tiền nợ!");

                        }

                        else
                        {
                            tienconno = tienno - tienthu;
                            tienconnotxtbox.Text = tienconno.ToString();
                        }
                    }
                }
            }
        }

        private void lapphieubtn_Click(object sender, EventArgs e)
        {
            if (flag == 1)
                MessageBox.Show("Đã trả hết nợ!");
            else
            {
                if (String.IsNullOrEmpty(biensocbbox.Text) || String.IsNullOrEmpty(tienthutxtbox.Text))
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");


                else
                {
                    string maptt = matttxtbox.Text;
                    string bienso = biensocbbox.Text;
                    double tienthu = Convert.ToDouble(tienthutxtbox.Text);
                    if (!PHIEUTHUTIENDAO.Instance.Them(maptt, bienso, tienthu))
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                    double tienconno = Convert.ToDouble(tienconnotxtbox.Text);
                    XEDAO.Instance.SuaTienNo(bienso, tienconno);
                    this.Close();
                }
            }
        }
    }
}
