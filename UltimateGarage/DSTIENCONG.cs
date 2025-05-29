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
    public partial class DSTIENCONG : Form
    {
        int flag;
        public DSTIENCONG()
        {
            InitializeComponent();
            HienThi();
        }
        void HienThi()
        {
            ptdtgrid.DataSource = TIENCONGDAO.Instance.HienThi();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void WageForm_Load(object sender, EventArgs e)
        {

        }

        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void themtiencong_btn_Click(object sender, EventArgs e)
        {
            THEMTIENCONG themTienCong = new THEMTIENCONG();
            themTienCong.ShowDialog();
            HienThi();
        }

        private void suatiencong_btn_Click(object sender, EventArgs e)
        {
            if (ptdtgrid.Rows.Count == 0)
            {
                MessageBox.Show("Không có loại tiền công để cập nhật!");
            }
            else
            {
                SUATIENCONG wageForm = new SUATIENCONG();
                wageForm.matiencong = matctxtbox.Text;
                wageForm.tiencong = tctxtbox.Text;
                wageForm.noidung = ndtxtbox.Text;
                wageForm.ShowDialog();
                HienThi();
            }
        }

        private void tcdtgrid_SelectionChanged(object sender, EventArgs e)
        {
            matctxtbox.DataBindings.Clear();
            matctxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "MaTienCong");
            tctxtbox.DataBindings.Clear();
            tctxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "TienCong");
            ndtxtbox.DataBindings.Clear();
            ndtxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "NoiDung");
        }

        private void xoatcbtn_Click(object sender, EventArgs e)
        {
            if (ptdtgrid.Rows.Count > 0)
            {
                string mtc = matctxtbox.Text;
                if (!TIENCONGDAO.Instance.Xoa(mtc))
                    MessageBox.Show("Không thể xóa tiền công!");
                else
                {
                    if (ptdtgrid.Rows.Count == 0)
                    {
                        tctxtbox.Clear();
                        ndtxtbox.Clear();
                        matctxtbox.Clear();
                    }
                    else
                    {
                        matctxtbox.DataBindings.Clear();
                        matctxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "MaTienCong");
                        tctxtbox.DataBindings.Clear();
                        tctxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "TienCong");
                        ndtxtbox.DataBindings.Clear();
                        ndtxtbox.DataBindings.Add("Text", ptdtgrid.DataSource, "NoiDung");
                    }
                    HienThi();
                }
            }
            else
                MessageBox.Show("Không có loại tiền công để xóa!");
        }

        private void matcradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1;

        }

        private void ndtcbtn_CheckedChanged(object sender, EventArgs e)
        {
            flag = 2;

        }

        private void timkiembtn_Click(object sender, EventArgs e)
        {
            string s = timkiemtxtbox.Text;
            if (!string.IsNullOrEmpty(timkiemtxtbox.Text))
            {
                if (flag == 1)
                {
                    ptdtgrid.DataSource = TIENCONGDAO.Instance.TimKiemTheoMa(s);

                }
                else if (flag == 2)
                {
                    ptdtgrid.DataSource = TIENCONGDAO.Instance.TimKiemTheoNoiDung(s);

                }
            }
            else
                HienThi();
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
                                workbook.Worksheets.Add(ptdtgrid.DataSource as DataTable, "TienCong");

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

        private void ptdtgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
