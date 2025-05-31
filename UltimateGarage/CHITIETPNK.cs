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
    public partial class CHITIETPNK : Form
    {
        public string maphieunhap { get; set; }
        public string ngaynhap { get; set; }
        public CHITIETPNK()
        {
            InitializeComponent();

        }

        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CHITIETPNK_Load(object sender, EventArgs e)
        {
            mpntxtbox.Text = maphieunhap;

            ngaynhapdtpicker.Text = ngaynhap;
            pnkvtptdtgrid.DataSource = CT_PNKVTPTDAO.Instance.HienThi(maphieunhap);

        }
    }
}
