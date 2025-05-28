using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using UltimateGarage.DAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DocumentFormat.OpenXml.Vml;
using ClosedXML.Excel;

namespace UltimateGarage
{
    public partial class MANHINHCHINH : Form
    {
        int flag;
        public string tendangnhap { get; set; }

        public MANHINHCHINH()
        {

            InitializeComponent();
            xedtgrid.Columns["BienSo"].DefaultCellStyle.ForeColor = Color.Black;
            xedtgrid.Columns["TenChuXe"].DefaultCellStyle.ForeColor = Color.Black;
            xedtgrid.Columns["HieuXe"].DefaultCellStyle.ForeColor = Color.Black;
            xedtgrid.Columns["DiaChi"].DefaultCellStyle.ForeColor = Color.Black;
            xedtgrid.Columns["DienThoai"].DefaultCellStyle.ForeColor = Color.Black;
            xedtgrid.Columns["Email"].DefaultCellStyle.ForeColor = Color.Black;
            xedtgrid.Columns["TienNo"].DefaultCellStyle.ForeColor = Color.Black;
            xedtgrid.Columns["NgayTiepNhan"].DefaultCellStyle.ForeColor = Color.Black;
            HienThi();

        }
        public void HienThi()
        {
            DataTable dt = XEDAO.Instance.HienThi();
            xedtgrid.DataSource = dt;
        }

        public void HienThiXeTiepNhanTrongNgay()
        {
            DataTable dt = XEDAO.Instance.HienThiXeNhapTrongNgay();
            xedtgrid.DataSource = dt;
        }


        private void MANHINHCHINH_Load(object sender, EventArgs e)
        {
            if (NHANVIENDAO.Instance.flag == 0)
                dangsudungtxtbox.Text = "Khách";
            else
            {
                SqlDataReader dr = NHANVIENDAO.Instance.HienThiThongTin(tendangnhap);
                if (dr.Read())
                    dangsudungtxtbox.Text = dr["TenNV"].ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddCarButton_Click(object sender, EventArgs e)
        {
            if (NHANVIENDAO.Instance.flag == 0)
                MessageBox.Show("Khách không được sử dụng chức năng này!");
            else
            {
                TIEPNHANXE t = new TIEPNHANXE();
                t.ShowDialog();
                HienThi();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void xedtgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (NHANVIENDAO.Instance.flag == 0)
                MessageBox.Show("Khách không được sử dụng chức năng này!");
            else
            {
                if (xedtgrid.Rows.Count == 0)
                    MessageBox.Show("Không có xe để cập nhật!");
                else
                {
                    SUATHONGTINXE changeForm = new SUATHONGTINXE();
                    changeForm.bienso = biensotxtbox.Text;
                    changeForm.ten = tentxtbox.Text;
                    changeForm.hieuxe = hieuxetxtbox.Text;
                    changeForm.diachi = diachitxtbox.Text;
                    changeForm.dth = dthtxtbox.Text;
                    changeForm.email = emailtxtbox.Text;
                    changeForm.no = notxtbox.Text;
                    changeForm.ngay = ngaydtpicker.Value;
                    changeForm.ShowDialog();
                    HienThi();
                }
            }
        }

        private void xedtgrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lapphieuvtptbtn_Click(object sender, EventArgs e)
        {
            if (NHANVIENDAO.Instance.flag == 0)
                MessageBox.Show("Khách không được sử dụng chức năng này!");
            else
            {
                PHIEUNHAPVTPT p = new PHIEUNHAPVTPT();
                p.ShowDialog();
            }
        }

        private void RepairButton_Click(object sender, EventArgs e)
        {
            if (NHANVIENDAO.Instance.flag == 0)
                MessageBox.Show("Khách không được sử dụng chức năng này!");
            else
            {
                PHIEUSUACHUA repairForm = new PHIEUSUACHUA();
                repairForm.ShowDialog();
                HienThi();
            }
        }

        private void xedtgrid_SelectionChanged(object sender, EventArgs e)
        {
            biensotxtbox.DataBindings.Clear();
            biensotxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "BienSo");
            tentxtbox.DataBindings.Clear();
            tentxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "TenChuXe");
            hieuxetxtbox.DataBindings.Clear();
            hieuxetxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "HieuXe");
            diachitxtbox.DataBindings.Clear();
            diachitxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "DiaChi");
            dthtxtbox.DataBindings.Clear();
            dthtxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "DienThoai");
            emailtxtbox.DataBindings.Clear();
            emailtxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "Email");
            notxtbox.DataBindings.Clear();
            notxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "TienNo");
            ngaydtpicker.DataBindings.Clear();
            ngaydtpicker.DataBindings.Add("Value", xedtgrid.DataSource, "NgayTiepNhan");
        }

        private void thutienbtn_Click(object sender, EventArgs e)
        {
            if (NHANVIENDAO.Instance.flag == 0)
                MessageBox.Show("Khách không được sử dụng chức năng này!");
            else
            {
                PHIEUTHUTIEN t = new PHIEUTHUTIEN();
                t.ShowDialog();
                HienThi();
            }
        }

        private void dangxuatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (NHANVIENDAO.Instance.flag == 0)
                MessageBox.Show("Khách không được sử dụng chức năng này!");
            else
            {
                string bienso = biensotxtbox.Text;
                if (xedtgrid.Rows.Count == 0)
                    MessageBox.Show("Không có xe để xóa");
                else
                {
                    if (!XEDAO.Instance.XoaXe(bienso))
                        MessageBox.Show("Không thể xóa xe!");
                    else
                    {
                        if (xedtgrid.Rows.Count == 0)
                        {
                            biensotxtbox.Clear();
                            tentxtbox.Clear();
                            dthtxtbox.Clear();
                            diachitxtbox.Clear();
                            emailtxtbox.Clear();
                            hieuxetxtbox.Clear();
                            notxtbox.Clear();
                        }
                        else
                        {
                            biensotxtbox.DataBindings.Clear();
                            biensotxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "BienSo");
                            tentxtbox.DataBindings.Clear();
                            tentxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "TenChuXe");
                            hieuxetxtbox.DataBindings.Clear();
                            hieuxetxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "HieuXe");
                            diachitxtbox.DataBindings.Clear();
                            diachitxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "DiaChi");
                            dthtxtbox.DataBindings.Clear();
                            dthtxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "DienThoai");
                            emailtxtbox.DataBindings.Clear();
                            emailtxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "Email");
                            notxtbox.DataBindings.Clear();
                            notxtbox.DataBindings.Add("Text", xedtgrid.DataSource, "TienNo");
                            ngaydtpicker.DataBindings.Clear();
                            ngaydtpicker.DataBindings.Add("Value", xedtgrid.DataSource, "NgayTiepNhan");
                        }
                        HienThi();
                    }
                }


            }
        }

        private void xetiepnhantrongngaybtn_Click(object sender, EventArgs e)
        {
            HienThiXeTiepNhanTrongNgay();
        }

        private void xuatbtn_Click(object sender, EventArgs e)
        {
            if (NHANVIENDAO.Instance.flag == 0)
                MessageBox.Show("Khách không được sử dụng chức năng này!");
            else
            {
                if (xedtgrid.Rows.Count == 0)
                    MessageBox.Show("Không có thông tin để xuất");
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
                                    workbook.Worksheets.Add(xedtgrid.DataSource as DataTable, "Xe");

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

        private void timkiembtn_Click(object sender, EventArgs e)
        {
            string s = timtxtbox.Text;
            if (!string.IsNullOrEmpty(s))
            {
                if (flag == 1)
                    xedtgrid.DataSource = XEDAO.Instance.TimKiemTheoTen(s);
                else if (flag == 2)
                    xedtgrid.DataSource = XEDAO.Instance.TimKiemTheoSDT(s);
                else if (flag == 3)
                    xedtgrid.DataSource = XEDAO.Instance.TimKiemTheoBienSo(s);
                else if (flag == 4)
                    xedtgrid.DataSource = XEDAO.Instance.TimKiemTheoNgay(s);
            }
            else
                HienThi();
        }

        private void NameSearchRadiobtn_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1;
        }

        private void sdttimradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 2;
        }

        private void biensotimradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 3;
        }

        private void timtheongayradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 4;
        }

        //Nav bar above
        private void thongTinAdmin_btnClick(object sender, EventArgs e)
        {
            if (NHANVIENDAO.Instance.flag == 0)
                MessageBox.Show("Khách không được sử dụng chức năng này!");
            else if (NHANVIENDAO.Instance.flag != 1)
                MessageBox.Show("Phải là quản lý mới có quyền truy cập!");
            else
            {
                THONGTINADMIN t = new THONGTINADMIN();
                t.tendangnhap = tendangnhap;
                t.ShowDialog();
            }
        }

        private void baoCaoTonVatTuPhuTung_btnClick(object sender, EventArgs e)
        {
            if (NHANVIENDAO.Instance.flag == 0)
                MessageBox.Show("Khách không được sử dụng chức năng này!");
            else
            {
                BAOCAOTON form = new BAOCAOTON();
                form.ShowDialog();
            }
        }

        private void baoCaoDoanhSoThang_btnClick(object sender, EventArgs e)
        {
            if (NHANVIENDAO.Instance.flag == 0)
                MessageBox.Show("Khách không được sử dụng chức năng này!");
            else
            {
                BAOCAODOANHSO form = new BAOCAODOANHSO();
                form.ShowDialog();
            }
        }

        private void thongTinPhanMem_btnClick(object sender, EventArgs e)
        {
            THONGTINPM form = new THONGTINPM();
            form.ShowDialog();
        }

        private void lienHe_btnClick(object sender, EventArgs e)
        {
            LIENHE form = new LIENHE();
            form.ShowDialog();
        }
    }
}
