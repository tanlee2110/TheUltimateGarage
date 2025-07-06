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
    public partial class DSNHANVIEN : Form
    {
        public DSNHANVIEN()
        {
            InitializeComponent();
            HienThi();
        }
        
        int flag;
        
        public void HienThi()
        {
            nvdtgrid.DataSource = NHANVIENDAO.Instance.HienThi();
        }

        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void themNhanVien_btnClick(object sender, EventArgs e)
        {
            THEMNV themNV = new THEMNV();
            themNV.ShowDialog();
            HienThi();
        }

        private void xuatbtn_Click(object sender, EventArgs e)
        {
            if (nvdtgrid.Rows.Count == 0)
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
                                workbook.Worksheets.Add(nvdtgrid.DataSource as DataTable, "NhanVien");

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

        private void nvdtgrid_SelectionChanged(object sender, EventArgs e)
        {

            tdntxtbox.DataBindings.Clear();
            tdntxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "TenDangNhap");
            mktxtbox.DataBindings.Clear();
            mktxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "MatKhau");
            tentxtbox.DataBindings.Clear();
            tentxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "TenNV");
            dctxtbox.DataBindings.Clear();
            dctxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "DiaChi");
            dthtxtbox.DataBindings.Clear();
            dthtxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "DienThoai");
            emailtxtbox.DataBindings.Clear();
            emailtxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "Email");
            chucvutxtbox.DataBindings.Clear();
            chucvutxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "ChucVu");

        }

        private void xoanvbtn_Click(object sender, EventArgs e)
        {
            if (nvdtgrid.Rows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có thực sự muốn xoá thông tin này không?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    NHANVIENDAO.Instance.Xoa(tdntxtbox.Text);
                    HienThi();
                    if (nvdtgrid.Rows.Count == 0)
                    {
                        tdntxtbox.Clear();
                        mktxtbox.Clear();
                        tentxtbox.Clear();
                        dctxtbox.Clear();
                        dthtxtbox.Clear();
                        emailtxtbox.Clear();
                        chucvutxtbox.Clear();
                    }
                    else
                    {
                        tdntxtbox.DataBindings.Clear();
                        tdntxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "TenDangNhap");
                        mktxtbox.DataBindings.Clear();
                        mktxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "MatKhau");
                        tentxtbox.DataBindings.Clear();
                        tentxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "TenNV");
                        dctxtbox.DataBindings.Clear();
                        dctxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "DiaChi");
                        dthtxtbox.DataBindings.Clear();
                        dthtxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "DienThoai");
                        emailtxtbox.DataBindings.Clear();
                        emailtxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "Email");
                        chucvutxtbox.DataBindings.Clear();
                        chucvutxtbox.DataBindings.Add("Text", nvdtgrid.DataSource, "ChucVu");
                    }
                }
            }
            else
                MessageBox.Show("Không có nhân viên để xóa!");
        }

        private void suanvbtn_Click(object sender, EventArgs e)
        {
            if (nvdtgrid.Rows.Count == 0)
                MessageBox.Show("Không có nhân viên để cập nhật!");
            else
            {
                SUANV suaNV = new SUANV();
                suaNV.ten = tentxtbox.Text;
                suaNV.tendangnhap = tdntxtbox.Text;
                suaNV.matkhau = mktxtbox.Text;
                suaNV.diachi = dctxtbox.Text;
                suaNV.dth = dthtxtbox.Text;
                suaNV.email = emailtxtbox.Text;
                suaNV.chucvu = chucvutxtbox.Text;

                suaNV.ShowDialog();
                HienThi();
            }
        }

        private void sdtradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 3;
        }

        private void tennvradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            flag = 2;
        }

        private void tendangnhapradio_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1;
        }

        private void timkiembtn_Click(object sender, EventArgs e)
        {
            string s = timkiemtxtbox.Text;
            if (!string.IsNullOrEmpty(timkiemtxtbox.Text))
            {
                if (flag == 1)
                {
                    nvdtgrid.DataSource = NHANVIENDAO.Instance.TimKiemTheoTenDangNhap(s);

                }
                else if (flag == 2)
                {
                    nvdtgrid.DataSource = NHANVIENDAO.Instance.TimKiemTheoTen(s);

                }
                else if (flag == 3)
                {
                    nvdtgrid.DataSource = NHANVIENDAO.Instance.TimKiemTheoSDT(s);
                }
            }
            else
                HienThi();
        }
    }
}
