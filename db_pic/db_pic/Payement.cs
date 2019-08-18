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
using System.IO;
namespace db_pic
{
    public partial class Payement : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;database=pro_one_try;password=");
        MySqlCommand command;
        MySqlDataAdapter da;
        public Payement()
        {
            InitializeComponent();
            display();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {

         /*   try
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
                    Credentials = new NetworkCredential(from.Address, pass)
                };
                using (var message = new MailMessage(from, to)
                {
                    Subject = sub,
                    Body = body
                })
                    smtp.Send(message);
                MessageBox.Show("Mail Sent!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }
        public void display()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            int newWidth = 568;
            dataGridView1.MaximumSize = new Size(newWidth, dataGridView1.Height);
            dataGridView1.Size = new Size(newWidth, dataGridView1.Height);

            try
            {
                string selectQuery = "SELECT * FROM users";
                command = new MySqlCommand(selectQuery, connection);
                da = new MySqlDataAdapter(command);

                DataTable table = new DataTable();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 100;
                dataGridView1.AllowUserToAddRows = false;

                da.Fill(table);

                dataGridView1.DataSource = table;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[0];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

                da.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            try
            {

                string selectQuery = "SELECT * FROM users where NAME like '%" + this.textBox1.Text + "%'";
                command = new MySqlCommand(selectQuery, connection);
                da = new MySqlDataAdapter(command);

                DataTable table = new DataTable();

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 100;
                dataGridView1.AllowUserToAddRows = false;

                da.Fill(table);

                dataGridView1.DataSource = table;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[0];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

                da.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string selected_email = dataGridView1.SelectedRows[0].Cells["Email"].Value.ToString();
                string selected_name = dataGridView1.SelectedRows[0].Cells["NAME"].Value.ToString();
                // this.Hide();
                pay_form f = new pay_form(selected_email,selected_name);
                f.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                try
                {
                    int newWidth = 568;
                    dataGridView1.MaximumSize = new Size(newWidth, dataGridView1.Height);
                    dataGridView1.Size = new Size(newWidth, dataGridView1.Height);
                    panel1.Visible = true;
                    button1.Visible = true;
                    //    pictureBox1.Image = (Image)dataGridView1.SelectedRows[0].Cells["IMAGE"].Value;
                    byte[] bytes = (byte[])dataGridView1.SelectedRows[0].Cells["IMAGE"].Value;
                    MemoryStream ms = new MemoryStream(bytes);
                    pictureBox1.Image = Image.FromStream(ms);
                    idtxt.Text = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                    nametxt.Text = dataGridView1.SelectedRows[0].Cells["NAME"].Value.ToString();
                    addresstxt.Text = dataGridView1.SelectedRows[0].Cells["DETAILS"].Value.ToString();
                    label8.Text = dataGridView1.SelectedRows[0].Cells["Email"].Value.ToString();
                    label10.Text = dataGridView1.SelectedRows[0].Cells["Mobile"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            panel1.Visible = false;
            int newWidth = 932;
            dataGridView1.MaximumSize = new Size(newWidth, dataGridView1.Height);
            dataGridView1.Size = new Size(newWidth, dataGridView1.Height);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin f = new Admin();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            crrow.StartShuru sForm1 = new crrow.StartShuru();
            sForm1.Show();
        }
    }
}
