using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace SPCafeProject
{
    public partial class ForgotPassword : Form
    {
        string randcode;
        string to;
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            LoginPage LPage = new LoginPage();
            LPage.Show();
            this.Hide();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randcode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txt_regemail.Text).ToString();
            from = "sujithamurugesan92@gmail.com";
            pass = "mgzg ehgp snfz kkhr";
            messageBody = "Your Verification OTP :" + randcode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "OTP Verification";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("OTP Sended Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (randcode == (txt_EOTP.Text).ToString())
            {
                MessageBox.Show("OTP Verified Successful");

                ResetPassword RP = new ResetPassword();
                RP.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("OTP Incorrect");
            }
        }
    }
}
