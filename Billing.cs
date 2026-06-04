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
    public partial class Billing : Form
    {

        public Billing()
        {
            InitializeComponent();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DashBoard DB = new DashBoard();
            DB.Show();
            this.Hide();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_billid.Text == " " || txt_customername.Text == "" || txt_contactno.Text == "" || dateTimePicker1.Text == "" || txt_productname.Text == "" || txt_totalprice.Text == "")
            {
                MessageBox.Show("Please Enter Valid Credentials");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS; Initial Catalog = cafe ; Integrated Security = true");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Billing_insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@Bill_id", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = txt_billid.Text;
                    SqlParameter param2 = new SqlParameter("@CustomerName", SqlDbType.VarChar);
                    cmd.Parameters.Add(param2).Value = txt_customername.Text;
                    SqlParameter param3 = new SqlParameter("@ContactNo", SqlDbType.VarChar);
                    cmd.Parameters.Add(param3).Value = txt_contactno.Text;
                    SqlParameter param4 = new SqlParameter("@BillDate", SqlDbType.DateTime);
                    cmd.Parameters.Add(param4).Value = dateTimePicker1.Text;
                    SqlParameter param5 = new SqlParameter("@Productname", SqlDbType.VarChar);
                    cmd.Parameters.Add(param5).Value = txt_productname.Text;
                    SqlParameter param6 = new SqlParameter("@TotalPrice", SqlDbType.Int);
                    cmd.Parameters.Add(param6).Value = txt_totalprice.Text;

                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        MessageBox.Show("Bill Added Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Bill cannot be Added");

                        txt_billid.Clear();
                        txt_customername.Clear();
                        txt_contactno.Clear();
                        txt_productname.Clear();
                        txt_totalprice.Clear();
                    } 
                        
                    con.Close();



                    SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS ; Initial Catalog = cafe ; Integrated Security =true");
                    conn.Open();

                    SqlCommand cmnd = new SqlCommand("Billing_fetch", conn);
                    cmnd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmnd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                    conn.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txt_billid.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                txt_customername.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                txt_contactno.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                dateTimePicker1.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                txt_productname.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
                txt_totalprice.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(groupBox1.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));

            Bitmap imagebmp = new Bitmap(dataGridView2.Width, dataGridView2.Height);
            dataGridView2.DrawToBitmap(imagebmp, new Rectangle(0, 0, dataGridView2.Width, dataGridView2.Height));
            e.Graphics.DrawImage(imagebmp, 120, 20);
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
