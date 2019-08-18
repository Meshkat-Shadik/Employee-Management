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
    public partial class Create_Employee : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;database=pro_one_try;password=");
        MySqlCommand command;
        MySqlDataAdapter da;
        MySqlDataReader dr;
     //   string loc;
        public Create_Employee()
        {
            InitializeComponent();
           // display();
        }
        public void display()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;

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
                da.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png";
            dlg.Title = "Select Pictures";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picloc = dlg.FileName.ToString();
                textBox4.Text = picloc;
                pictureBox1.ImageLocation = picloc;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string MyConnection2 = "datasource=localhost;username=root;database=pro_one_try;password=";
            MySqlConnection con = new MySqlConnection(MyConnection2);
            MySqlCommand cmd;
            FileStream fs;
            BinaryReader br;

            try
            {
                string FileName = textBox4.Text;
                byte[] ImageData;
                fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                ImageData = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
            //    loc = textBox4.Text;
                string CmdString = "insert into users(ID,NAME,Rank,Mobile,Email,DETAILS,IMAGE) values(@Id,@Name,@Rank,@mob,@Email,@Details,@Image);";
                cmd = new MySqlCommand(CmdString, con);

                cmd.Parameters.Add("@Id", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Rank", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@mob", MySqlDbType.VarChar, 15);
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Details", MySqlDbType.VarChar, 100);
                cmd.Parameters.Add("@Image", MySqlDbType.Blob);


                cmd.Parameters["@Id"].Value = textBox1.Text;
                cmd.Parameters["@Name"].Value = textBox2.Text;
                cmd.Parameters["@Rank"].Value = comboBox1.Text;
                cmd.Parameters["@mob"].Value = textBox6.Text;
                cmd.Parameters["@Email"].Value = textBox7.Text;
                cmd.Parameters["@Details"].Value = textBox3.Text;
                cmd.Parameters["@Image"].Value = ImageData;


                con.Open();
                int RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    MessageBox.Show("New Employee added!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin f = new Admin();
            f.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel2.Visible = true;
            button2.Visible = false;
            panel2.Visible = false;
            textBox5.Visible = true;
            pictureBox5.Visible = true;
            dataGridView1.Visible = true;
            button5.Visible = true;
            display();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
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
                dataGridView1.Columns["Src"].Visible = false;
                da.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel2.Visible = true;
            button2.Visible = false;
            textBox5.Visible = false;
            button5.Visible = false;
            pictureBox5.Visible = false;
            dataGridView1.Visible = false;
            button5.Visible = false;
            panel2.Location = new Point(330, 200);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* if (e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                try
                {
                    /*int newWidth = 568;
                    dataGridView1.MaximumSize = new Size(newWidth, dataGridView1.Height);
                    dataGridView1.Size = new Size(newWidth, dataGridView1.Height);
                    panel1.Visible = true;*/
                    //    pictureBox1.Image = (Image)dataGridView1.SelectedRows[0].Cells["IMAGE"].Value;
                //    byte[] bytes = (byte[])dataGridView1.SelectedRows[0].Cells["IMAGE"].Value;
                 //   MemoryStream ms = new MemoryStream(bytes);
                  //  pictureBox1.Image = Image.FromStream(ms);
                    //idtxt.Text = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                   // nametxt.Text = dataGridView1.SelectedRows[0].Cells["NAME"].Value.ToString();
                  //  addresstxt.Text = dataGridView1.SelectedRows[0].Cells["DETAILS"].Value.ToString();
                /*    try
                    {
                    //    string MyConnection2 = "datasource = localhost; username = root; password=; database = pro_try_one";
                     //   string Query = "delete from users where name='" + dataGridView1.SelectedRows[0].Cells["NAME"].Value.ToString() + "';";
                     //   MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    //    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                        MySqlDataReader MyReader2;
                        MyConn2.Open();
                        MyReader2 = MyCommand2.ExecuteReader();
                        MessageBox.Show("Data Deleted");
                      //  gridview_data();
                        MyConn2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }*/
            }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string selected_name = dataGridView1.SelectedRows[0].Cells["NAME"].Value.ToString();
                string selected_id = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                string selected_details = dataGridView1.SelectedRows[0].Cells["DETAILS"].Value.ToString();

                string delete_query = "delete from users where ID = '" + selected_id + "'and NAME = '" + selected_name + "' and DETAILS= '" + selected_details + "'";
                command = new MySqlCommand(delete_query, connection);
                //   MySqlDataReader MyReader2;
                connection.Open();
                dr = command.ExecuteReader();
                MessageBox.Show("Deleted!");
                connection.Close();
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel2.Visible = true;
            button2.Visible = true;
            panel2.Visible = false;
            button5.Visible = false;
            textBox5.Visible = true;
            pictureBox5.Visible = true;
            dataGridView1.Visible = true;
            display();
 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string selected_mobile = dataGridView1.SelectedRows[0].Cells["Mobile"].Value.ToString();
                string selected_name = dataGridView1.SelectedRows[0].Cells["NAME"].Value.ToString();
                // this.Hide();
                Update_Form f = new Update_Form(selected_mobile,selected_name);
                f.ShowDialog();
                display();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
