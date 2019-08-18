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
    public partial class Employer_List : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;database=pro_one_try;password=");
        MySqlCommand command;
        MySqlDataAdapter da;
        public Employer_List()
        {

            InitializeComponent();
            panel1.Visible = false;
            int newWidth = 932;
            dataGridView1.MaximumSize = new Size(newWidth, dataGridView1.Height);
            dataGridView1.Size = new Size(newWidth, dataGridView1.Height);
            display();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void display()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            panel1.Visible = false;
            int newWidth = 932;
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
               dataGridView1.Columns["Src"].Visible = false;
               dataGridView1.Columns["Salary"].Visible = false;
                da.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            int newWidth = 568;
            dataGridView1.MaximumSize = new Size(newWidth, dataGridView1.Height);
            dataGridView1.Size = new Size(newWidth, dataGridView1.Height);

            display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                try
                {
                    int newWidth = 568;
                    dataGridView1.MaximumSize = new Size(newWidth, dataGridView1.Height);
                    dataGridView1.Size = new Size(newWidth, dataGridView1.Height);
                    panel1.Visible = true;
                //    pictureBox1.Image = (Image)dataGridView1.SelectedRows[0].Cells["IMAGE"].Value;
                   byte[] bytes = (byte[])dataGridView1.SelectedRows[0].Cells["IMAGE"].Value;
                   MemoryStream ms = new MemoryStream(bytes);
                   pictureBox1.Image = Image.FromStream(ms);
                   idtxt.Text = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                   nametxt.Text = dataGridView1.SelectedRows[0].Cells["NAME"].Value.ToString();
                   addresstxt.Text = dataGridView1.SelectedRows[0].Cells["DETAILS"].Value.ToString();
                   label8.Text = dataGridView1.SelectedRows[0].Cells["Email"].Value.ToString();
                   label12.Text =  dataGridView1.SelectedRows[0].Cells["Mobile"].Value.ToString();
                   label10.Text = dataGridView1.SelectedRows[0].Cells["Rank"].Value.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            int newWidth = 932;
            dataGridView1.MaximumSize = new Size(newWidth, dataGridView1.Height);
            dataGridView1.Size = new Size(newWidth, dataGridView1.Height);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int newWidth = 568;
            dataGridView1.MaximumSize = new Size(newWidth, dataGridView1.Height);
            dataGridView1.Size = new Size(newWidth, dataGridView1.Height);

            try
            {

                string selectQuery = "SELECT * FROM users where NAME like '%"+this.textBox1.Text+"%'";
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
                dataGridView1.Columns["Src"].Visible = false;
                dataGridView1.Columns["Salary"].Visible = false;
                da.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            First_Page f = new First_Page();
            f.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
