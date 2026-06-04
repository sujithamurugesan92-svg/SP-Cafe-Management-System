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
    public partial class Employee : Form
    {
        public Employee()
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
            if (txt_employeeid.Text == "" || txt_Ename.Text == "" || txt_email.Text == "" || txt_contactno.Text == "" || txt_address.Text == "" || txt_salary.Text == "" || cb_gender.Text == "")
            {
                MessageBox.Show("Please Enter Valid Credentials");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS; Initial Catalog = cafe ; Integrated Security = true");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("sp_insert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param1 = new SqlParameter("@Emp_id", SqlDbType.VarChar);
                    cmd.Parameters.Add(param1).Value = txt_employeeid.Text;
                    SqlParameter param2 = new SqlParameter("@EmpName", SqlDbType.VarChar);
                    cmd.Parameters.Add(param2).Value = txt_Ename.Text;
                    SqlParameter param3 = new SqlParameter("@Email", SqlDbType.VarChar);
                    cmd.Parameters.Add(param3).Value = txt_email.Text;
                    SqlParameter param4 = new SqlParameter("@ContactNo", SqlDbType.VarChar);
                    cmd.Parameters.Add(param4).Value = txt_contactno.Text;
                    SqlParameter param5 = new SqlParameter("@Address", SqlDbType.VarChar);
                    cmd.Parameters.Add(param5).Value = txt_address.Text;
                    SqlParameter param6 = new SqlParameter("@Salary", SqlDbType.Int);
                    cmd.Parameters.Add(param6).Value = txt_salary.Text;
                    SqlParameter param7 = new SqlParameter("@Gender", SqlDbType.VarChar);
                    cmd.Parameters.Add(param7).Value = cb_gender.Text;

                    int i = cmd.ExecuteNonQuery();

                    if (i > 0)
                    {
                        MessageBox.Show("Employeee Added Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Employee cannot be Added");
                        txt_employeeid.Clear();
                        txt_Ename.Clear();
                        txt_email.Clear();
                        txt_contactno.Clear();
                        txt_address.Clear();
                        txt_salary.Clear();
                    } 
                        con.Close();

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS ; Initial Catalog = cafe ; Integrated Security =true");
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@Emp_id", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = txt_employeeid.Text;
                SqlParameter param2 = new SqlParameter("@EmpName", SqlDbType.VarChar);
                cmd.Parameters.Add(param2).Value = txt_Ename.Text;
                SqlParameter param3 = new SqlParameter("@Email", SqlDbType.VarChar);
                cmd.Parameters.Add(param3).Value = txt_email.Text;
                SqlParameter param4 = new SqlParameter("@ContactNo", SqlDbType.VarChar);
                cmd.Parameters.Add(param4).Value = txt_contactno.Text;
                SqlParameter param5 = new SqlParameter("@Address", SqlDbType.VarChar);
                cmd.Parameters.Add(param5).Value = txt_address.Text;
                SqlParameter param6 = new SqlParameter("@Salary", SqlDbType.Int);
                cmd.Parameters.Add(param6).Value = txt_salary.Text;
                SqlParameter param7 = new SqlParameter("@Gender", SqlDbType.VarChar);
                cmd.Parameters.Add(param7).Value = cb_gender.Text;

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Employeee Upadated ");
                }
                else
                {
                    MessageBox.Show("Employee cannot be Updated");

                  
                    txt_employeeid.Clear();
                    txt_Ename.Clear();
                    txt_email.Clear();
                    txt_contactno.Clear();
                    txt_address.Clear();
                    txt_salary.Clear();
                }  
                    con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txt_search_TextChanged_1(object sender, EventArgs e)
        {
          
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS ; Initial Catalog = cafe ; Integrated Security =true");
                con.Open();

                SqlCommand cmd = new SqlCommand("employee_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("@Emp_id", SqlDbType.VarChar);
                cmd.Parameters.Add(param1).Value = txt_employeeid.Text;

                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Employeee Deleted");
                }
                else MessageBox.Show("Employee cannot be Deleted");
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void btn_Displaye_Click(object sender, EventArgs e)
        {
           SqlConnection conn = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS; Initial Catalog = cafe ; Integrated Security = true");
           conn.Open();

            SqlCommand cmnd = new SqlCommand("employee_fetch", conn);
            cmnd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmnd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();

 

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-32TS4A9\SQLEXPRESS; Initial Catalog = cafe ; Integrated Security = true");
            con.Open();

            SqlCommand cmd = new SqlCommand("employee_search", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter("@EmpName", SqlDbType.VarChar);
            cmd.Parameters.Add(param1).Value = txt_search.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txt_employeeid.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txt_Ename.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txt_email.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txt_contactno.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txt_address.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txt_salary.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                cb_gender.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
