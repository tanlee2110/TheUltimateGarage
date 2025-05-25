using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using UltimateGarage.DAO;

namespace UltimateGarage
{
    public partial class DSVTPT : Form
    {
        int flag;
        public DSVTPT()
        {
            InitializeComponent();
            HienThi();
        }

        public void HienThi()
        {
            ptdtgrid.DataSource = VTPTDAO.Instance.HienThi();
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void suavtptbtn_Click(object sender, EventArgs e)
        {
            if (ptdtgrid.Rows.Count == 0)
                MessageBox.Show("Không có vật tư phụ tùng để cập nhật!");
            else
            {
                SUAVTPT infoAccChangeForm = new SUAVTPT();
                infoAccChangeForm.mavtpt = mavtpttxtbox.Text;
                infoAccChangeForm.tenvtpt = tenvtpttxtbox.Text;
                infoAccChangeForm.soluong = Convert.ToInt32(sltxtbox.Text);
                infoAccChangeForm.dongia = dgtxtbox.Text;
                infoAccChangeForm.ShowDialog();
                HienThi();
            }
        }

        private void ptdtgrid_SelectionChanged(object sender, EventArgs e)
        {
            mavtpttxtbox.DataBindings.Clear();
            mavtpttxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "MaVTPT");
            tenvtpttxtbox.DataBindings.Clear();
            tenvtpttxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "TenVTPT");
            sltxtbox.DataBindings.Clear();
            sltxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "SoLuongTon");
            dgtxtbox.DataBindings.Clear();
            dgtxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "DonGia");
        }

        private void xoavtptbtn_Click(object sender, EventArgs e)
        {
            if (ptdtgrid.Rows.Count > 0)
            {
                string ma = mavtpttxtbox.Text;
                if (!VTPTDAO.Instance.Xoa(ma))
                    MessageBox.Show("Không thể xóa vật tư phụ tùng!");
                else
                {
                    if (ptdtgrid.Rows.Count == 0)
                    {
                        mavtpttxtbox.Clear();
                        tenvtpttxtbox.Clear();
                        dgtxtbox.Clear();
                        sltxtbox.Clear();
                    }
                    else
                    {
                        mavtpttxtbox.DataBindings.Clear();
                        mavtpttxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "MaVTPT");
                        tenvtpttxtbox.DataBindings.Clear();
                        tenvtpttxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "TenVTPT");
                        sltxtbox.DataBindings.Clear();
                        sltxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "SoLuongTon");
                        dgtxtbox.DataBindings.Clear();
                        dgtxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "DonGia");
                    }
                    HienThi();

                }


            }
            else
                MessageBox.Show("Không có vật tư phụ tùng để xóa!");
        }

        private void theomaradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1;
        }

        private void theotenradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 2;
        }

        private void xuatbtn_Click(object sender, EventArgs e)
        {
            if (ptdtgrid.Rows.Count == 0)
                MessageBox.Show("Không có thông tin để xuất!");
            else
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                workbook.Worksheets.Add(ptdtgrid.DataSource as DataTable, "VTPT");

                                workbook.SaveAs(saveFileDialog.FileName);


                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Xuất file không thành công!");
                        }
                    }
                }
            }
        }

        private void timkiembtn_Click(object sender, EventArgs e)
        {
            string s = timkiemtxtbox.Text;
            if (!string.IsNullOrEmpty(timkiemtxtbox.Text))
            {
                if (flag == 1)
                {
                    ptdtgrid.DataSource = VTPTDAO.Instance.TimKiemTheoMa(s);
                }
                else if (flag == 2)
                {
                    ptdtgrid.DataSource = VTPTDAO.Instance.TimKiemTheoTen(s);
                }
            }
            else
                HienThi();
        }

        private void themtcbtn_Click(object sender, EventArgs e)
        {
            THEMVTPT t = new THEMVTPT();
            t.ShowDialog();
        }
    }
}
