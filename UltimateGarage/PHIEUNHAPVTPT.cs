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
    public partial class PHIEUNHAPVTPT : Form
    {
        public PHIEUNHAPVTPT()
        {
            InitializeComponent();
            
        }

        private void PHIEUNHAPVTPT_Load(object sender, EventArgs e)
        {
            mapntxtbox.Text = PNKVTPTDAO.Instance.LoadMPN();
            SqlDataReader dr = VTPTDAO.Instance.LoadVTPT();
            while (dr.Read())
            {
                tenvtcbbox.Items.Add(dr["TenVTPT"]);
            }
        }

        private void thembtn_Click(object sender, EventArgs e)
        {  
            if (String.IsNullOrEmpty(dgtxtbox.Text) || String.IsNullOrEmpty(tenvtcbbox.Text))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");

            else
            {
                string mpn = mapntxtbox.Text;
                string ten = tenvtcbbox.Text;
                string dgn = dgtxtbox.Text;
                int sl = Convert.ToInt32(slnum.Value);
                string mavt = "";
                SqlDataReader dr = VTPTDAO.Instance.LoadVTPTTheoTen(ten);
                if (dr.Read())
                    mavt = dr["MaVTPT"].ToString();
                ctnkgrid.Rows.Add(mavt, ten, sl, dgn);
            }
        }

        private void xoabtn_Click(object sender, EventArgs e)
        {
            if (ctnkgrid.Rows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có thực sự muốn xoá thông tin này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ctnkgrid.Rows.RemoveAt(ctnkgrid.CurrentCell.RowIndex);
                }
            }
            else
                MessageBox.Show("Không có thông tin để xóa!");
        }

        private void lpbtn_Click(object sender, EventArgs e)
        {
            if (ctnkgrid.Rows.Count == 0)
                MessageBox.Show("Vui lòng nhập thông tin!");
            else
            {
                string mpn = mapntxtbox.Text;
                PNKVTPTDAO.Instance.Them(mpn);

                foreach (DataGridViewRow dataRow in ctnkgrid.Rows)
                {
                    string mavt = dataRow.Cells["MaVTPT"].Value.ToString();
                    double dgn = Convert.ToDouble(dataRow.Cells["GiaNhap"].Value);
                    string ten = dataRow.Cells["TenVTPT"].Value.ToString();
                    int sl = Convert.ToInt32(dataRow.Cells["SoLuong"].Value);
                    CT_PNKVTPTDAO.Instance.Them(mpn, mavt, ten, sl, dgn);
                    double tile = QUYDINHDAO.Instance.LoadTiLeLai();
                    SqlDataReader dr = VTPTDAO.Instance.LoadVTPTTheoTen(ten);
                    int slcu = 0;

                    if (dr.Read())
                    {
                        slcu = Convert.ToInt32(dr["SoLuongTon"]);
                    }
                    int slmoi = sl + slcu;
                    double dgm = dgn * tile;
                    VTPTDAO.Instance.SuaSLDG(mavt, slmoi, dgm);

                }
                this.Close();
            }
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ctnkgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
