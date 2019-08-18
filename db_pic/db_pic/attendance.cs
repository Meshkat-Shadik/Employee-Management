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
using System.IO;

namespace db_pic
{
    public partial class attendance : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;database=pro_one_try;password=");
       // MySqlCommand command,command2;
      //  string shortDate;
     //   string  roboIp;
       // string sD = null;
     //   string sD2 = null;
     //   string shortDate;
        //MySqlDataAdapter da;
    //    int salary;
     //   string a, b, c, d, p, exx, q, r, s, late, abs;
    //    byte[] ImageData;
        public attendance()
        {
            InitializeComponent();
           // display();

            //dateTimePicker4.Format = DateTimePickerFormat.Custom;
           // dateTimePicker4.CustomFormat = "dd-MM-yyyy";
          //  this.BindGrid();
            setdate();
            
        }
        public void setdate()
        {
            label5.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
      
        }
       
        /*   private void BindGrid()
           {
               try
               {
                   string selectQuery = "SELECT ID,NAME,DETAILS FROM users";
                   command = new MySqlCommand(selectQuery, connection);
                   da = new MySqlDataAdapter(command);

                   DataTable table = new DataTable();

                   dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                   dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                   //dataGridView1.RowTemplate.Height = 100;
                   dataGridView1.AllowUserToAddRows = false;
                   da.Fill(table);
                   dataGridView1.DataSource = table;

                   /* DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[0];
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

                   da.Dispose();


               }
               catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
               //Add a CheckBox Column to the DataGridView at the first position.
               DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
               checkBoxColumn.HeaderText = "";
               checkBoxColumn.Width = 30;
               checkBoxColumn.Name = "checkBoxColumn";
               dataGridView1.Columns.Insert(0, checkBoxColumn);
           }*/

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //dataGridView2.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin f = new Admin();
            f.ShowDialog();
        }

        private void attendance_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
       
            //label2.Text = date.ToString("yyyy-mm-dd");
            //label6.Text = shortDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //StartShuru obj = new StartShuru();
         //   obj.ShowDialog();
         //   System.Diagnostics.Process.Start(Application.StartupPath.ToString() + @"..crrow\crrow\bin\Debug\crrow.exe");
            //StartShuru obj = new StartShuru();
           // obj.ShowDialog();
          /*  dataGridView2.Visible = true;
            try
            {
                //    string selectQuery = "SELECT users.ID,users.NAME,users.Rank,CAST(presents.Date as DATE), CAST(presents.Time as TIME) FROM users inner join presents where users.ID=presents.ID and  CAST(Date as DATE)  BETWEEN " + shortDate + " and " + shortDate2 + ";";
                //string selectQuery = "SELECT CAST(Date as DATE), CAST(Time as TIME) from presents   WHERE CAST(Date as DATE)  BETWEEN " + shortDate + " and " + shortDate2 + ";";

                string selectQuery = "Select ID,NAME,Rank,DATE_FORMAT(CAST(Date as DATE),'%d-%M,%Y') as Date,Time,Src,Salary,Mobile,Email from tryview where Date BETWEEN " + shortDate + " and " + shortDate2 + ";";//SELECT CAST(Date as DATE), CAST(Time as TIME) from presents
                // string selectQuery2 = "SELECT COUNT(*) FROM demos WHERE val = 2";
                command = new MySqlCommand(selectQuery, connection);
                da = new MySqlDataAdapter(command);

                DataTable table = new DataTable();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.RowTemplate.Height = 20;
                dataGridView2.AllowUserToAddRows = false;

                da.Fill(table);

                dataGridView2.DataSource = table;
                da.Dispose();
                //    ordersBindingSource.DataSource = connection.Query<Orders>(selectQuery, CommandType: CommandType.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            crrow.StartShuru sForm1 =new crrow.StartShuru();
	        sForm1.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            hisab.Form1 sForm1 = new hisab.Form1();
            sForm1.Show();
        }
    }
}
