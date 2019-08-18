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
    public partial class Company_details : Form
    {
        public Company_details()
        {
            InitializeComponent();
            load_pdf();
        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }
        public void load_pdf()
        {
            axAcroPDF1.src = "file:///I:/NovelBooks/Project_SAD/company_profile.pdf";
        }
    }
}
