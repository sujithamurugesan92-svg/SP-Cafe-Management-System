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
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DashBoard DB = new DashBoard();
            DB.Show();
            this.Hide();
        }

        private void btn_showall_Click(object sender, EventArgs e, object Showall)
        {
           

            

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
           MessageBox.Show("Submitted");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DashBoard DB = new DashBoard();
            DB.Show();
            this.Hide();
        }
    }
}
