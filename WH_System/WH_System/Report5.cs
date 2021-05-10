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
    public partial class Report5 : Form
    {
        NSystemEntities Ware = new NSystemEntities();

        public Report5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var expiryYear = DateTime.Now.AddYears(int.Parse(numericUpDown1.Text));
            var expiryMonth = DateTime.Now.AddMonths(int.Parse(numericUpDown2.Text));
            var expiryDay = DateTime.Now.AddDays(int.Parse(numericUpDown3.Text));
            
            var exp = (from t in Ware.Products
                       where t.Expiry_Date < expiryYear && t.Expiry_Date < expiryMonth && t.Expiry_Date < expiryDay
                       select new { t.Product_ID, t.Product_Name, t.Entry_Date, t.Production_Date, t.Expiry_Date }).ToList();

            dataGridView1.DataSource = exp;

        }
    }
}
