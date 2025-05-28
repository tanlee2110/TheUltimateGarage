using ClosedXML.Excel;
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
    public partial class BAOCAODOANHSO : Form
    {
        public BAOCAODOANHSO()
        {
            InitializeComponent();
        }

        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xuat_btnClick(object sender, EventArgs e)
        {
            if (bcdsdtgrid.Rows.Count == 0)
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
                                workbook.Worksheets.Add(bcdsdtgrid.DataSource as DataTable, "BAOCAODOANHSO");

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

        private void hienBaoCao_btnClick(object sender, EventArgs e)
        {
            int thang = Convert.ToInt32(thangnumeric.Value);
            int nam = Convert.ToInt32(namnumeric.Value);
            double tongThanhTien = 0;


            DataTable dt = BAOCAODOANHTHUDAO.Instance.BaoCao(thang, nam);
            dt.Columns.Add("TiLe");
            if (dt.Rows.Count > 0)
            {

                SqlDataReader dr = BAOCAODOANHTHUDAO.Instance.TongThanhTien(thang, nam);
                if (dr.Read())
                    tongThanhTien = Convert.ToDouble(dr["TONGTHANHTIEN"]);
                tongThanhTien_txtbox.Text = tongThanhTien.ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["TiLe"] = Math.Round(Convert.ToDouble(dt.Rows[i]["THANHTIEN"]) / tongThanhTien, 4);
                }
                bcdsdtgrid.DataSource = dt;
            }
            else
            {
                bcdsdtgrid.DataSource = null;
                tongThanhTien_txtbox.Clear();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
