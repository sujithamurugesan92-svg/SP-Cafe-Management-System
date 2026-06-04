using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SPCafeProject
{
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            LoginPage LPage = new LoginPage();
            LPage.Show();
            this.Hide();
        }

        private void btn_resetpassword_Click(object sender, EventArgs e)
        {
            if(txt_ENPassword.Text == txt_confirmpassword.Text)
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS; Initial Catalog = cafe ; Integrated Security = true");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("user_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@UName", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = txt_username.Text;
                    SqlParameter param2 = new SqlParameter("@pwd", SqlDbType.VarChar);
                    cmd.Parameters.Add(param2).Value = txt_ENPassword.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Password Reset Sccessfully");
                    else MessageBox.Show("Error");
                    con.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
          
            }
        }

        private void txt_confirmpassword_TextChanged(object sender, EventArgs e)
        {
          
                
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }
    }
}