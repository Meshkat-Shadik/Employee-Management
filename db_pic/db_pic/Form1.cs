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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png";
            dlg.Title = "Select Pictures";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picloc = dlg.FileName.ToString();
                textBox4.Text = picloc;
                pictureBox1.ImageLocation = picloc;
            }*/
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*    string MyConnection2 = "datasource=localhost;username=root;database=pro_one_try;password=";
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

                        string CmdString = "insert into users(ID,NAME,DETAILS,IMAGE) values(@Id,@Name,@Details,@Image);";
                        cmd = new MySqlCommand(CmdString, con);

                        cmd.Parameters.Add("@Id", MySqlDbType.VarChar, 45);
                        cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 45);
                        cmd.Parameters.Add("@Details", MySqlDbType.VarChar, 100);
                        cmd.Parameters.Add("@Image", MySqlDbType.Blob);


                        cmd.Parameters["@Id"].Value = textBox1.Text;
                        cmd.Parameters["@Name"].Value = textBox2.Text;
                        cmd.Parameters["@Details"].Value = textBox3.Text;
                        cmd.Parameters["@Image"].Value = ImageData;


                        con.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            MessageBox.Show("Image saved sucessfully!");
                        }
                        con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }*/

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        /*
            try
            {

                MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;database=pro_one_try;password=");
                MySqlCommand command;
                MySqlDataAdapter da;
                String selectQuery = "SELECT * FROM users WHERE Name = '" + textBox2.Text + "'";

                command = new MySqlCommand(selectQuery, connection);

                da = new MySqlDataAdapter(command);

                DataTable table = new DataTable();

                da.Fill(table);
                textBox1.Text = table.Rows[0][0].ToString();
                textBox2.Text = table.Rows[0][1].ToString();
                textBox3.Text = table.Rows[0][2].ToString();

                    byte[] img = (byte[])table.Rows[0][3];

                    MemoryStream ms = new MemoryStream(img);

                    pictureBox1.Image = Image.FromStream(ms);

                    da.Dispose();
             
            }
            catch(Exception ex)
            {
                MessageBox.Show("There is not exist any member in this name!");
            }*/
    
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
          //  Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
         //   this.Hide();
          //  First_Page f = new First_Page();
           // f.ShowDialog();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        //Timer tmr;
        private void Form1_Shown(object sender, EventArgs e)
        {
          //  tmr = new Timer();
            //set time interval 3 sec
         //   tmr.Interval = 3000;
            //starts the timer
       //     tmr.Start();
         //   tmr.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            //after 3 sec stop the timer
           // tmr.Stop();
           // //display mainform
          //  this.Hide();
           // First_Page mf = new First_Page();
          //  mf.Show();
            //hide this form
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if(progressBar1.Value == 100)
            {
                timer1.Stop();
            }
        }
    }
}
