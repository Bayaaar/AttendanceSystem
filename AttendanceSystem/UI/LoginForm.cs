using System;
using AttendanceSystem.DAL;
using AttendanceSystem.Models;

namespace AttendanceSystem.UI
{
    public partial class LoginForm : Form
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Хэрэглэгчийн нэр болон нууц үгээ оруулна уу.", "Анхаар",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                User? loggedInUser = _userRepo.Authenticate(username, password);
                if (loggedInUser != null)
                {
                    Hide();
                    MainDashboardForm dashboard = new MainDashboardForm(loggedInUser);
                    dashboard.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Хэрэглэгчийн нэр эсвэл нууц үг буруу байна.", "Амжилтгүй",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системийн алдаа",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}