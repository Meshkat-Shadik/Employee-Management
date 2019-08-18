using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_pic
{
    public partial class about_front : Form
    {
        public about_front()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new about_us().ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new Company_details().ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new First_Page().ShowDialog();
        }
    }
}
