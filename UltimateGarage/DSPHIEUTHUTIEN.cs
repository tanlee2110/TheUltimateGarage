using ClosedXML.Excel;
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
    public partial class DSPHIEUTHUTIEN : Form
    {
        int flag;
        public DSPHIEUTHUTIEN()
        {
            InitializeComponent();
            HienThi();
        }
        public void HienThi()
        {
            pttdtgrid.DataSource = PHIEUTHUTIENDAO.Instance.HienThi();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string s = timkiemtxtbox.Text;
            int ngay = ngaydtpicker.Value.Day;
            int thang = ngaydtpicker.Value.Month;
            int nam = ngaydtpicker.Value.Year;
            if (flag == 2)
                pttdtgrid.DataSource = PHIEUTHUTIENDAO.Instance.TimKiemTheoNgay(ngay, thang, nam);
            else
            {
                if (!string.IsNullOrEmpty(s))
                {
                    if (flag == 1)
                        pttdtgrid.DataSource = PHIEUTHUTIENDAO.Instance.TimKiemTheoMa(s);

                }
                else
                    HienThi();
            }

        }

        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xuatbtn_Click(object sender, EventArgs e)
        {
            if (pttdtgrid.Rows.Count == 0)
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
                                workbook.Worksheets.Add(pttdtgrid.DataSource as DataTable, "PHIEUTHUTIEN");

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

        private void xoaButton_Click(object sender, EventArgs e)
        {
            
        }

        private void mapnradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1;
        }

        private void timtheongayradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 2;
        }

        private void xoaButton_Click_1(object sender, EventArgs e)
        {
            if (pttdtgrid.Rows.Count > 0 && pttdtgrid.CurrentRow != null)
            {
                var result = MessageBox.Show("Bạn có thực sự muốn xoá phiếu thu tiền này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string maPTT = pttdtgrid.CurrentRow.Cells[0].Value.ToString();
                    PHIEUTHUTIENDAO.Instance.Xoa(maPTT);
                    HienThi();
                }
            }
            else
            {
                MessageBox.Show("Không có phiếu thu tiền để xóa!");
            }
        }
    }
}
