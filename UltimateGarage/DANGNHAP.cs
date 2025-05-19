using UltimateGarage.DAO;

namespace UltimateGarage
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = tendangnhap_txtbox.Text;
            string password = pass_txtbox.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }
            else
            {
                if (NHANVIENDAO.Instance.DangNhap(username, password))
                {

                    if (NHANVIENDAO.Instance.flag == 1)
                        MessageBox.Show("Chào mừng admin!");
                    else
                        MessageBox.Show("Chào mừng nhân viên!");
                    MANHINHCHINH frm = new MANHINHCHINH();
                    this.Hide();
                    frm.tendangnhap = username;


                    frm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
        }

        private void chedokhachbtn_Click(object sender, EventArgs e)
        {
            MANHINHCHINH frm = new MANHINHCHINH();
            this.Hide();
            NHANVIENDAO.Instance.flag = 0;

            frm.ShowDialog();
            this.Show();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
