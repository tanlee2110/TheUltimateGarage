using ClosedXML.Excel;
using UltimateGarage.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimateGarage
{
    public partial class DSPNKVTPT : Form
    {
        int flag;
        public DSPNKVTPT()
        {
            InitializeComponent();
            HienThi();
        }

        public void HienThi()
        {
            phieunhapvtptdtgrid.DataSource = PNKVTPTDAO.Instance.HienThi();
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
