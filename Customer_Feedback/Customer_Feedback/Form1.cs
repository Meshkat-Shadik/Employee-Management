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

namespace Customer_Feedback
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.comboBox1.Text != "" && this.textBox3.Text != "")
            {
                try
                {

                    string MyConnection2 = "datasource = localhost; username = root; password=; database = pro_one_try";
                    string Query = "insert into feedback(Mobile,Name,Description,Comment) values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.comboBox1.Text +"');";
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Feedback Sent!");
                    MyConn2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (this.textBox2.Text == "")
            {
                MessageBox.Show("Insert Name in the text box!");
            }
            else if (this.comboBox1.Text == "")
            {
                MessageBox.Show("Insert Comment in the text box!");
            }
            else if (this.textBox1.Text == "")
            {
                MessageBox.Show("Insert mobile number in the text box!");
            }
        }
    }
}
