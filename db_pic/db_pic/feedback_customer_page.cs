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
using MySql.Data.MySqlClient;

namespace db_pic
{
    public partial class feedback_customer_page : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;database=pro_one_try;password=");
        MySqlCommand command;
        MySqlDataAdapter da;
        public feedback_customer_page()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
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
                var to = new MailAddress(textBox1.Text);
                string sub = textBox2.Text;
                string body = textBox3.Text;

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                   DeliveryMethod = SmtpDeliveryMethod.Network,
                   UseDefaultCredentials = false,
                   Credentials = new NetworkCredential (from.Address, pass)
                };
                using (var message = new MailMessage(from, to)
                {
                    Subject = sub,
                    Body = body
                })
                    smtp.Send(message);
                MessageBox.Show("Mail Sent!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel1.Visible = true;
           // int newWidth = 568;
          //  panel2.MaximumSize = new Size(newWidth, panel2.Height);
          //  panel2.Size = new Size(newWidth, panel2.Height);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            int newWidth = 568;
            panel2.MaximumSize = new Size(newWidth, panel2.Height);
            panel2.Size = new Size(newWidth, panel2.Height);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            dataGridView1.Visible = true;
            try
            {
                string selectQuery = "SELECT * FROM feedback";
                command = new MySqlCommand(selectQuery, connection);
                da = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 100;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Khaki;
                dataGridView1.EnableHeadersVisualStyles = false;
                da.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 50;
               // dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[4].Width = 35;
                dataGridView1.Columns[3].Width = 38;
                dataGridView1.Columns[5].Width = 50;
                dataGridView1.Columns[6].Width = 75;
                dataGridView1.Columns[4].DefaultCellStyle.Format = "dddd";
                dataGridView1.Columns[5].DefaultCellStyle.Format = "dd-MMM,yyyy";
                dataGridView1.Columns[6].DefaultCellStyle.Format = "hh:mm:ss tt";
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.Beige;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string val = (dataGridView1.Rows[i].Cells[3].Value.ToString());
                    if (val.Equals("Positive"))
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (val.Equals("Negative"))
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }

                da.Dispose();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            } 
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin f = new Admin();
            f.ShowDialog();
        }
    }
}
