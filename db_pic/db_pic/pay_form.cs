using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace db_pic
{
    public partial class pay_form : Form
    {
        public pay_form(string x, string y)
        {
            InitializeComponent();
            label3.Text = x;
            label4.Text = "Payment for "+y;
        }

        private void pay_form_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var from = new MailAddress("unknown1602058@gmail.com");
                var pass = "296667681575";
                var to = new MailAddress(label3.Text);
                string sub = "PAYMENT";
                string body = textBox1.Text + " Taka added to your account as payment for "+comboBox1.Text+" month, please check your Bkash account!";

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(from.Address, pass)
                };
                using (var message = new MailMessage(from, to)
                {
                    Subject = sub,
                    Body = body
                })
                    smtp.Send(message);
                MessageBox.Show("Payment Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
