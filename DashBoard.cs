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
    public partial class DashBoard : Form
    {
       
        public DashBoard()
        {
            InitializeComponent();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            LoginPage LPage = new LoginPage();
            LPage.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Billing O = new Billing();
            O.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Feedback FB = new Feedback();
            FB.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Employee E = new Employee();
            E.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Product P = new Product();
            P.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are You Want To Logout?" , "Confirmation Message" , MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (check == DialogResult.OK)
            {

                LoginPage LPage = new LoginPage();
                LPage.Show();
                this.Hide();
            }
           
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e )
        {
            if (txt_productname.Text == "" || txt_price.Text == "" || cb_quantity.Text == "" || txt_total.Text == "")
            {
                MessageBox.Show("Please Enter Valid Credentials");
            }
            else
            {
                try
                {

                    SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS; Initial Catalog = cafe ; Integrated Security = true");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("sp_Order", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@PName", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = txt_productname.Text;
                    SqlParameter param2 = new SqlParameter("@Price", SqlDbType.Int);
                    cmd.Parameters.Add(param2).Value = txt_price.Text;
                    SqlParameter param3 = new SqlParameter("@Quantity", SqlDbType.Int);
                    cmd.Parameters.Add(param3).Value = cb_quantity.Text;
                    SqlParameter param4 = new SqlParameter("@Total", SqlDbType.Int);
                    cmd.Parameters.Add(param4).Value = txt_total.Text;


                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        MessageBox.Show("Order Added Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Order cannot be Added");

                        txt_productname.Clear();
                        txt_price.Clear();
                        txt_total.Clear();
                    }
                        
                        

                    SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS; Initial Catalog = cafe ; Integrated Security = true");
                    conn.Open();

                    SqlCommand cmnd = new SqlCommand("Orders_fetch", conn);
                    cmnd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmnd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    conn.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Billing O = new Billing();
            O.Show();
            this.Hide();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txt_productname.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txt_price.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                cb_quantity.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_total.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

                pictureBox8.Visible = true;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;

           
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS ; Initial Catalog = cafe ; Integrated Security =true");
            con.Open();

            SqlCommand cmd = new SqlCommand("order_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@PName", SqlDbType.VarChar);
            cmd.Parameters.Add(param1).Value = txt_productname.Text;

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                MessageBox.Show("Order Deleted");
            }
            else MessageBox.Show("Order cannot be Deleted");
            con.Close();
        }
    }
}
