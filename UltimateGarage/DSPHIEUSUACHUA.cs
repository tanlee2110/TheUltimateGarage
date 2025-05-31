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
    public partial class DSPHIEUSUACHUA : Form
    {
        int flag;
        public DSPHIEUSUACHUA()
        {
            InitializeComponent();
            HienThi();
        }
        public void HienThi()
        {
            pscdtgrid.DataSource = PHIEUSUACHUADAO.Instance.HienThi();
        }

        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xembtn_Click(object sender, EventArgs e)
        {
            CHITIETPSC t = new CHITIETPSC();
            t.tongtien = pscdtgrid.CurrentRow.Cells["TongTien"].Value.ToString();
            t.ngaysua = pscdtgrid.CurrentRow.Cells["NgaySuaChua"].Value.ToString();
            t.bienso = pscdtgrid.CurrentRow.Cells["BienSo"].Value.ToString();
            t.mapsc = pscdtgrid.CurrentRow.Cells["MaPSC"].Value.ToString();
            t.ShowDialog();
        }

        private void xuatbtn_Click(object sender, EventArgs e)
        {
            if (pscdtgrid.Rows.Count == 0)
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
                                workbook.Worksheets.Add(pscdtgrid.DataSource as DataTable, "PHIEUSUACHUA");

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

        private void mapscradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1;
        }

        private void timkiembtn_Click(object sender, EventArgs e)
        {
            string s = timkiemtxtbox.Text;
            int ngay = ngaydtpicker.Value.Day;
            int thang = ngaydtpicker.Value.Month;
            int nam = ngaydtpicker.Value.Year;
            if (flag == 2)
                pscdtgrid.DataSource = PHIEUSUACHUADAO.Instance.TimKiemTheoNgay(ngay, thang, nam);
            else
            {
                if (!string.IsNullOrEmpty(s))
                {

                    pscdtgrid.DataSource = PHIEUSUACHUADAO.Instance.TimKiemTheoMa(s);


                }
                else
                    HienThi();
            }

        }

        private void timtheongayradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 2;
        }
    }
}
