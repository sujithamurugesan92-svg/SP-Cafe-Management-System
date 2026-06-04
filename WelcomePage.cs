using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPCafeProject
{
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are You Want To Exit?", "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (check == DialogResult.OK)
            {
                Application.Exit();

            }
          
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            RegisterPage RPage = new RegisterPage();
            RPage.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            RegisterPage RP = new RegisterPage();
            RP.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            LoginPage LP = new LoginPage();
            LP.Show();
            this.Hide();
        }
    }
}
