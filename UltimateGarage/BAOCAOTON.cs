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
    public partial class BAOCAOTON : Form
    {
        public BAOCAOTON()
        {
            InitializeComponent();
        }

        private void xuatBaoCao_btnClick(object sender, EventArgs e)
        {
            if (bctdtgrid.Rows.Count == 0)
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
                                workbook.Worksheets.Add(bctdtgrid.DataSource as DataTable, "BAOCAOTON");

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

            DataTable dt = BAOCAOTONDAO.Instance.PhatSinhVaSuDung(thang, nam);
            dt.Columns.Add("TonCuoi");
            dt.Columns.Add("TonDau");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SqlDataReader dr = VTPTDAO.Instance.LoadVTPTTheoTen(dt.Rows[i]["TenVTPT"].ToString());
                    if (dr.Read())
                    {
                        int tc = Convert.ToInt32(dr["SoLuongTon"]);
                        int ps = Convert.ToInt32(dt.Rows[i]["PhatSinh"]);
                        int sd = Convert.ToInt32(dt.Rows[i]["SuDung"]);
                        int td = tc - ps + sd;
                        dt.Rows[i]["TonCuoi"] = tc.ToString();
                        dt.Rows[i]["TonDau"] = td.ToString();
                    }
                }
                bctdtgrid.DataSource = dt;
            }
            else
                bctdtgrid.DataSource = null;
        }

        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
