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
    public partial class Update_Form : Form
    {
        string name;
        public Update_Form(string x,string y)
        {
            InitializeComponent();
            label1.Text = x;
            label7.Text = "Update Information for "+y;
            name = y;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          /*  try
            {
                //This is my connection string i have assigned the database file address path  
                string MyConnection2 = "datasource=localhost;username=root;password=;database=pro_one_try";
                //This is my update query in which i am taking input from the user through windows forms and update the record.  
                string Query = "update users set ID='" + this.textBox1.Text + "',NAME='" + this.textBox2.Text + "',Mobile='" + this.textBox6.Text + "',Email='" + this.textBox7.Text + "',DETAILS='" + this.textBox3.Text + "' where Mobile='" + this.label1.Text + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Contact Updated!");

                //  gridview_data();
                MyConn2.Close();//Connection closed here  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
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

                string CmdString = "update users set ID=@Id,NAME=@Name,Rank=@Rank,Mobile=@mob,Email=@Email,DETAILS=@Details,IMAGE=@Image where Mobile='"+this.label1.Text+"'";
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
                    MessageBox.Show("Updated Information for "+name);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /*
         *  string MyConnection2 = "datasource=localhost;username=root;database=pro_one_try;password=";
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

                string CmdString = "insert into users(ID,NAME,Mobile,Email,DETAILS,IMAGE) values(@Id,@Name,@mob,@Email,@Details,@Image);";
                cmd = new MySqlCommand(CmdString, con);

                cmd.Parameters.Add("@Id", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@mob", MySqlDbType.VarChar, 15);
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@Details", MySqlDbType.VarChar, 100);
                cmd.Parameters.Add("@Image", MySqlDbType.Blob);


                cmd.Parameters["@Id"].Value = textBox1.Text;
                cmd.Parameters["@Name"].Value = textBox2.Text;
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
         */
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
