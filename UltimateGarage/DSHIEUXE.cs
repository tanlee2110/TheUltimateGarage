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
    public partial class DSHIEUXE : Form
    {
        public DSHIEUXE()
        {
            InitializeComponent();
            HienThi();
        }

        void HienThi()
        {
            hieuxedtgrid.DataSource = HIEUXEDAO.Instance.HienThi();
        }

        private void themhieuxebtn_Click(object sender, EventArgs e)
        {
            THEMHIEUXE tHEMHIEUXE = new THEMHIEUXE();
            tHEMHIEUXE.ShowDialog();
            HienThi();
        }

        private void xoahieuxebtn_Click(object sender, EventArgs e)
        {
            if (hieuxedtgrid.Rows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có thực sự muốn xoá thông tin này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string s = hieuxedtgrid.CurrentRow.Cells[0].Value.ToString();
                    if (!HIEUXEDAO.Instance.Xoa(s))
                        MessageBox.Show("Không thể xóa hiệu xe!");
                    HienThi();
                }
            }
            else
            {
                MessageBox.Show("Không có thông tin để xóa!");
            }
        }

        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timkiembtn_Click(object sender, EventArgs e)
        {
            string s = timhieuxetxtbox.Text;
            if (!string.IsNullOrEmpty(s))
            {
                hieuxedtgrid.DataSource = HIEUXEDAO.Instance.TimHieuXe(s);
            }
            else
                HienThi();
        }

        private void xuatbtn_Click(object sender, EventArgs e)
        {
            if (hieuxedtgrid.Rows.Count == 0)
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
                                workbook.Worksheets.Add(hieuxedtgrid.DataSource as DataTable, "VTPT");
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
    }
}
