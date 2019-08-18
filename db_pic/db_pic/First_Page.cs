using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace db_pic
{
    public partial class First_Page : Form
    {
        MySqlConnection MyConn2 = new MySqlConnection("datasource=localhost;username=root;database=pro_one_try;password=");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        public DataSet ds = new DataSet();
        public First_Page()
        {
          //  Thread t = new Thread(new ThreadStart(SplashStart));
          //  t.Start();
        //    Thread.Sleep(5000);
            InitializeComponent();
        //    t.Abort();
            textBox2.PasswordChar = '*';
        }
        public void SplashStart()
        {
            //Application.Run(new Form1());
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
      
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employer_List f = new Employer_List();
            f.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            label10.Visible = true;
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            label10.Visible = false;
            try
            {
                ds = new DataSet();
                adapter = new MySqlDataAdapter("select * from admins where UserName='" + this.textBox1.Text + "' and Password='"+this.textBox2.Text+"'",MyConn2);
                adapter.Fill(ds, "admins");
                if(ds.Tables["admins"].Rows.Count > 0)
                {
                    label9.Visible = false;
                    MessageBox.Show("Login Successfull!");
                    this.Hide();
                    Admin f = new Admin();
                    f.ShowDialog();

                }
                else
                {
                    label9.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new about_front().ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://eurotelbd.net/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new channels().ShowDialog();
        }

        private void First_Page_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void First_Page_Load(object sender, EventArgs e)
        {

        }
    }
}
