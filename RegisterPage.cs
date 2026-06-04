using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SPCafeProject
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {

        }

        private void btn_register_Click_1(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_username.Text == "" || txt_password.Text == "" || txt_email.Text == "" || cb_gender.Text == " " || txt_mobileno.Text == "")
            {
                MessageBox.Show("Please Enter Valid Datas");
            }

            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS; Initial Catalog = cafe ; Integrated Security = true");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("sp_register", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@Name", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = txt_name.Text;
                    SqlParameter param2 = new SqlParameter("@UName", SqlDbType.VarChar);
                    cmd.Parameters.Add(param2).Value = txt_username.Text;
                    SqlParameter param3 = new SqlParameter("@pwd", SqlDbType.VarChar);
                    cmd.Parameters.Add(param3).Value = txt_password.Text;
                    SqlParameter param4 = new SqlParameter("@Email", SqlDbType.VarChar);
                    cmd.Parameters.Add(param4).Value = txt_email.Text;
                    SqlParameter param5 = new SqlParameter("@Gender", SqlDbType.VarChar);
                    cmd.Parameters.Add(param5).Value = cb_gender.Text;
                    SqlParameter param6 = new SqlParameter("@MobileNo", SqlDbType.VarChar);
                    cmd.Parameters.Add(param6).Value = txt_mobileno.Text;

                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        MessageBox.Show("Registered Successfully");
                        LoginPage LPage = new LoginPage();
                        LPage.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Registration Failed");
                        txt_name.Clear();
                        txt_username.Clear();
                        txt_password.Clear();
                        txt_email.Clear();
                        txt_mobileno.Clear();

                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            WelcomePage WPage = new WelcomePage();
            WPage.Show();
            this.Hide();
        }



        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            WelcomePage WPage = new WelcomePage();
            WPage.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            LoginPage LPage = new LoginPage();
            LPage.Show();
            this.Hide();
        }
    }
}
