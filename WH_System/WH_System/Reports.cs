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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report_1 rep1 = new Report_1();
            rep1.Show();                 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report2 rep2 = new Report2();
            rep2.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Report3 rep3 = new Report3();
            rep3.Show(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report4 rep4 = new Report4();
            rep4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report5 rep5 = new Report5();
            rep5.Show();
        }
    }
}
