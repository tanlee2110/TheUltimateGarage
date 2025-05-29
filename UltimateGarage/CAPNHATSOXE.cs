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
    public partial class CAPNHATSOXE : Form
    {
        public CAPNHATSOXE()
        {
            InitializeComponent();
            HienThi();
        }
        void HienThi()
        {
            maxxenumeric.Value = QUYDINHDAO.Instance.HienThiSoXe();
        }

        private void capnhatbtn_Click(object sender, EventArgs e)
        {
            int max = Convert.ToInt32(maxxenumeric.Value);

            if (QUYDINHDAO.Instance.CapNhatSoXeMax(max))
                this.Close();
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
                this.Close();
            }
        }

        private void thoatbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
