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
    public partial class PHIEUSUACHUA : Form
    {
        double s = 0;

        public PHIEUSUACHUA()
        {
            InitializeComponent();
        }

        private void PHIEUSUACHUA_Load(object sender, EventArgs e)
        {
            mapsctxtbox.Text = PHIEUSUACHUADAO.Instance.LoadMPSC();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = true;
            SqlDataReader dr = XEDAO.Instance.LoadBienSo();
            while (dr.Read())
            {
                biensocbbox.Items.Add(dr["BienSo"]);
            }
            SqlDataReader dr1 = TIENCONGDAO.Instance.LoadTienCong();
            while (dr1.Read())
            {
                ndcbbox.Items.Add(dr1["NoiDung"]);
            }
            SqlDataReader dr2 = VTPTDAO.Instance.LoadVTPT();
            while (dr2.Read())
            {
                ptcbbox.Items.Add(dr2["TenVTPT"]);
            }
        }

        private void thembtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ndcbbox.Text) || String.IsNullOrEmpty(ptcbbox.Text))
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            else
            {
                string nd = ndcbbox.Text;
                string tenvt = ptcbbox.Text;
                string dg = dgtxtbox.Text;
                double tt = Convert.ToDouble(thanhtientxtbox.Text);
                string tc = tctxtbox.Text;
                int sl = Convert.ToInt32(slnumeric.Value);
                int slt = 0;
                string mavt = "";
                SqlDataReader dr = VTPTDAO.Instance.LoadVTPTTheoTen(tenvt);
                if (dr.Read())
                {
                    mavt = dr["MaVTPT"].ToString();
                    slt = Convert.ToInt32(dr["SoLuongTon"]);
                }
                if (slt - sl >= 0)
                {
                    pscdtgrid.Rows.Add(nd, mavt, tenvt, sl, dg, tc, tt);

                    s += tt;
                    ttttxtbox.Text = s.ToString();
                }
                else
                    MessageBox.Show("Không đủ vật tư phụ tùng!");

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void ptcbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int slt = 0;
            SqlDataReader dr = VTPTDAO.Instance.LoadVTPTTheoTen(ptcbbox.Text);
            if (dr.Read())
            {
                dgtxtbox.Text = dr["DonGia"].ToString();
                slt = Convert.ToInt32(dr["SoLuongTon"]);
            }
            tonkhotxtbox.Text = slt.ToString();
            int sl = Convert.ToInt32(slnumeric.Value);
            if (!String.IsNullOrEmpty(tctxtbox.Text) && !String.IsNullOrEmpty(dgtxtbox.Text))
            {
                double dg = Double.Parse(dgtxtbox.Text);

                double tc = Double.Parse(tctxtbox.Text);
                thanhtientxtbox.Text = (dg * sl + tc).ToString();
            }
        }

        private void ndcbbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader dr = TIENCONGDAO.Instance.LoadTienCongTheoNoiDung(ndcbbox.Text);
            if (dr.Read())
                tctxtbox.Text = dr["TienCong"].ToString();
            int sl = Convert.ToInt32(slnumeric.Value);
            if (!String.IsNullOrEmpty(tctxtbox.Text) && !String.IsNullOrEmpty(dgtxtbox.Text) && sl > 0)
            {
                double dg = Double.Parse(dgtxtbox.Text);

                double tc = Double.Parse(tctxtbox.Text);
                thanhtientxtbox.Text = (dg * sl + tc).ToString();
            }
        }

        private void slnumeric_ValueChanged(object sender, EventArgs e)
        {
            int sl = Convert.ToInt32(slnumeric.Value);
            if (!String.IsNullOrEmpty(tctxtbox.Text) && !String.IsNullOrEmpty(dgtxtbox.Text) && sl > 0)
            {
                double dg = Double.Parse(dgtxtbox.Text);

                double tc = Double.Parse(tctxtbox.Text);
                thanhtientxtbox.Text = (dg * sl + tc).ToString();
            }
        }

        private void xoabtn_Click(object sender, EventArgs e)
        {
            if (pscdtgrid.Rows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có thực sự muốn xoá thông tin này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    double tt = Convert.ToDouble(pscdtgrid.CurrentRow.Cells["ThanhTien"].Value);
                    pscdtgrid.Rows.RemoveAt(pscdtgrid.CurrentCell.RowIndex);
                    s -= tt;
                    ttttxtbox.Text = s.ToString();
                }
            }
            else
                MessageBox.Show("Không có thông tin để xóa!");
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Event handler for dateTimePicker1 value change
            // You can add any logic here if needed when the date changes
        }

        private void lapphieubtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(biensocbbox.Text))
                MessageBox.Show("Vui lòng chọn biển số xe!");




            else if (pscdtgrid.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin!");
            }
            else
            {
                string masc = mapsctxtbox.Text;
                string bienso = biensocbbox.Text;
                double tongtien = Convert.ToDouble(ttttxtbox.Text);
                DateTime ngaySuaChua = dateTimePicker1.Value;
                PHIEUSUACHUADAO.Instance.Them(masc, bienso, tongtien, ngaySuaChua);

                foreach (DataGridViewRow dataRow in pscdtgrid.Rows)
                {
                    string mavt = dataRow.Cells["MaVTPT"].Value.ToString();
                    string tenvt = dataRow.Cells["TenVTPT"].Value.ToString();
                    string noidung = dataRow.Cells["NoiDung"].Value.ToString();
                    int sl = Convert.ToInt32(dataRow.Cells["SoLuong"].Value);
                    string dg = dataRow.Cells["DonGia"].Value.ToString();
                    double tc = Convert.ToDouble(dataRow.Cells["TienCong"].Value.ToString());
                    string tt = dataRow.Cells["ThanhTien"].Value.ToString();
                    string matc = "";
                    SqlDataReader dr = TIENCONGDAO.Instance.LoadTienCongTheoNoiDung(noidung);
                    if (dr.Read())
                        matc = dr["MaTienCong"].ToString();

                    CT_PSCDAO.Instance.Them(masc, noidung, mavt, tenvt, sl, dg, matc, tc, tt);
                    SqlDataReader dr2 = VTPTDAO.Instance.LoadVTPTTheoTen(tenvt);
                    int slcu = 0;

                    if (dr2.Read())
                    {
                        slcu = Convert.ToInt32(dr2["SoLuongTon"]);
                    }
                    int slmoi = slcu - sl;
                    VTPTDAO.Instance.SuaSL(mavt, slmoi);



                }
                SqlDataReader dr1 = XEDAO.Instance.LoadThongTinTheoBienSo(bienso);
                if (dr1.Read())
                {
                    double tiennocu = Convert.ToDouble(dr1["TienNo"]);
                    double tiennomoi = tiennocu + tongtien;
                    XEDAO.Instance.SuaTienNo(bienso, tiennomoi);
                }
                this.Close();
            }
        }
    }
}
