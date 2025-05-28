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
    public partial class LIENHE : Form
    {
        public LIENHE()
        {
            InitializeComponent();
            pictureBox1.TabStop = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string fbUrl = "https://www.facebook.com/profile.php?id=61575905986783";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = fbUrl,
                UseShellExecute = true
            });
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string insUrl = "https://www.facebook.com/curyhao123";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = insUrl,
                UseShellExecute = true
            });
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string messUrl = "https://www.messenger.com/t/690220560832241?locale=vi_VN";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = messUrl,
                UseShellExecute = true
            });
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string ttUrl = "https://www.facebook.com/curyhao123";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = ttUrl,
                UseShellExecute = true
            });
        }

        private void thoat_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
