using ClosedXML.Excel;
using UltimateGarage.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimateGarage
{
    public partial class DSPNKVTPT : Form
    {
        int flag;
        public DSPNKVTPT()
        {
            InitializeComponent();
            HienThi();
        }
        public void HienThi()
        {
            phieunhapvtptdtgrid.DataSource = PNKVTPTDAO.Instance.HienThi();
        }
        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xemctbtn_Click(object sender, EventArgs e)
        {
            CHITIETPNK c = new CHITIETPNK();
            c.maphieunhap = phieunhapvtptdtgrid.CurrentRow.Cells[0].Value.ToString();
            c.ngaynhap = phieunhapvtptdtgrid.CurrentRow.Cells[1].Value.ToString();
            c.ShowDialog();
        }

        private void xuatbtn_Click(object sender, EventArgs e)
        {
            if (phieunhapvtptdtgrid.Rows.Count == 0)
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
                                workbook.Worksheets.Add(phieunhapvtptdtgrid.DataSource as DataTable, "PNKVTPT");

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
            int ngay = ngaydtpicker.Value.Day;
            int thang = ngaydtpicker.Value.Month;
            int nam = ngaydtpicker.Value.Year;
            if (flag == 2)
                phieunhapvtptdtgrid.DataSource = PNKVTPTDAO.Instance.TimKiemTheoNgay(ngay, thang, nam);
            else
            {
                if (!string.IsNullOrEmpty(s))
                {
                    if (flag == 1)
                        phieunhapvtptdtgrid.DataSource = PNKVTPTDAO.Instance.TimKiemTheoMa(s);

                }
                else
                    HienThi();
            }
        }

        private void timngayradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 2;
        }

        private void timtheomaradio_CheckedChanged_1(object sender, EventArgs e)
        {
            flag = 1;
        }

        private void xoaButton_Click(object sender, EventArgs e)
        {
            if (phieunhapvtptdtgrid.Rows.Count > 0 && phieunhapvtptdtgrid.CurrentRow != null)
            {
                var result = MessageBox.Show("Bạn có thực sự muốn xoá phiếu nhập này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string maNKVTPT = phieunhapvtptdtgrid.CurrentRow.Cells[0].Value.ToString();
                    PNKVTPTDAO.Instance.Xoa(maNKVTPT);
                    HienThi();
                }
            }
            else
            {
                MessageBox.Show("Không có phiếu nhập để xóa!");
            }
        }
    }
}
