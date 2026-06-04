using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPCafeProject
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            WelcomePage WPage = new WelcomePage();
            WPage.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
           RegisterPage RPage = new RegisterPage();
            RPage.Show();
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "" || txt_password.Text == "")
            {
                MessageBox.Show("Please Enter Valid Datas");
            }

            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS; Initial Catalog = cafe ; Integrated Security = true");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("sp_user", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    SqlParameter param1 = new SqlParameter("@UName", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = txt_username.Text;
                    SqlParameter param2 = new SqlParameter("@pwd", SqlDbType.VarChar);
                    cmd.Parameters.Add(param2).Value = txt_password.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

                    if (i > 0)
                    {
                        MessageBox.Show("Valid User");
                        MessageBox.Show("Login Successfully");
                        MessageBox.Show("Welcome Back !!! " + txt_username.Text);
                        DashBoard DB = new DashBoard();
                        DB.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User");
                        
                        txt_username.Clear();
                        txt_password.Clear();
                  
                    }
                    con.Close();
                }
                catch (Exception )
                {
                    MessageBox.Show("Invalid User");
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ForgotPassword FP = new ForgotPassword();
            FP.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e )
        {
            txt_password.PasswordChar = checkBox1.Checked ? '\0' : '#';
        }
    }
}
