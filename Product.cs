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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DashBoard DB = new DashBoard();
            DB.Show();
            this.Hide();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_productid.Text == " " || txt_Pname.Text == "" || cb_quantity.Text == ""  || txt_price.Text == "" || txt_totalprice.Text == "")
            {
                MessageBox.Show("Please Enter Valid Credentials");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS; Initial Catalog = cafe ; Integrated Security = true");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("product_insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@Pro_id", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = txt_productid.Text;
                    SqlParameter param2 = new SqlParameter("@ProName", SqlDbType.VarChar);
                    cmd.Parameters.Add(param2).Value = txt_Pname.Text;
                    SqlParameter param3 = new SqlParameter("@Quantity", SqlDbType.VarChar);
                    cmd.Parameters.Add(param3).Value = cb_quantity.Text;
                    SqlParameter param4 = new SqlParameter("@Price", SqlDbType.Int);
                    cmd.Parameters.Add(param4).Value = txt_price.Text;
                    SqlParameter param5 = new SqlParameter("@TotalPrice", SqlDbType.Int);
                    cmd.Parameters.Add(param5).Value = txt_totalprice.Text;

                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        MessageBox.Show("Product Added Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Product cannot be Added");
                        txt_productid.Clear();
                        txt_Pname.Clear();
                        txt_price.Clear();
                        txt_totalprice.Clear();
                    }
                        con.Close();



                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Product_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS ; Initial Catalog = cafe ; Integrated Security =true");
            con.Open();

            SqlCommand cmd = new SqlCommand("product_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@Pro_id", SqlDbType.VarChar);
            cmd.Parameters.Add(param1).Value = txt_productid.Text;

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                MessageBox.Show("Product Deleted");
            }
            else MessageBox.Show("Product cannot be Deleted");
            con.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS ; Initial Catalog = cafe ; Integrated Security =true");
            con.Open();

            SqlCommand cmd = new SqlCommand("product_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@Pro_id", SqlDbType.VarChar);
            cmd.Parameters.Add(param1).Value = txt_productid.Text;
            SqlParameter param2 = new SqlParameter("@ProName", SqlDbType.VarChar);
            cmd.Parameters.Add(param2).Value = txt_Pname.Text;
            SqlParameter param3 = new SqlParameter("@Quantity", SqlDbType.VarChar);
            cmd.Parameters.Add(param3).Value = cb_quantity.Text;
            SqlParameter param4 = new SqlParameter("@Price", SqlDbType.Int);
            cmd.Parameters.Add(param4).Value = txt_price.Text;
            SqlParameter param5= new SqlParameter("@TotalPrice", SqlDbType.Int);
            cmd.Parameters.Add(param5).Value = txt_totalprice.Text;
           
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                MessageBox.Show("Product Edited ");
            }
            else
            {
                MessageBox.Show("Product cannot be Edited");

                MessageBox.Show("Product cannot be Edited");
                txt_productid.Clear();
                txt_Pname.Clear();
                txt_price.Clear();
                txt_totalprice.Clear();
            }
                con.Close();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txt_productid.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_Pname.Text     = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                cb_quantity.Text   = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txt_price.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_totalprice.Text   = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                btn_edit.Visible = true;
                btn_delete.Visible = true; 

               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS ; Initial Catalog = cafe ; Integrated Security =true");
            conn.Open();

            SqlCommand cmnd = new SqlCommand("sp_fetch", conn);
            cmnd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmnd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
