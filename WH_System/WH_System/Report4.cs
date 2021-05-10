using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WH_System
{
    public partial class Report4 : Form
    {
        NSystemEntities Ware = new NSystemEntities();

        public Report4()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Report4_Load(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d1 = System.DateTime.Now.AddMonths(-(int)numericUpDown2.Value).AddYears(-(int)numericUpDown1.Value);

            var dat = (from t in Ware.Products where t.Entry_Date <= d1 select t).ToList();
            dataGridView1.DataSource = dat;

          

            dataGridView1.Columns["Export_Table"].Visible = false;
            dataGridView1.Columns["Import_Table"].Visible = false;
            dataGridView1.Columns["Werehouse_Product"].Visible = false;
        }
    }
}
