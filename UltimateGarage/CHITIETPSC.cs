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
    public partial class CHITIETPSC : Form
    {
        public string mapsc { get; set; }
        public string bienso { get; set; }
        public string ngaysua { get; set; }
        public string tongtien { get; set; }
        public CHITIETPSC()
        {
            InitializeComponent();
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pscdtgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CHITIETPSC_Load(object sender, EventArgs e)
        {
            masctxtbox.Text = mapsc;
            biensotxtbox.Text = bienso;
            ngaydtpicker.Text = ngaysua;
            ttttxtbox.Text = tongtien;
            pscdtgrid.DataSource = CT_PSCDAO.Instance.HienThi(mapsc);
        }
    }
}
