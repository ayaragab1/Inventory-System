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
    public partial class Report2 : Form
    {
        NSystemEntities Ware = new NSystemEntities();

        public Report2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id_2 = int.Parse(comboBox1.Text);

                DateTime Fromm = dateTimePicker1.Value.Date;
                DateTime to = dateTimePicker2.Value.Date;

                var report = (from t in Ware.Products
                              join b in Ware.Werehouse_Product
                              on t.Product_ID equals b.Product_ID
                              join f in Ware.Warehouses
                              on b.WH_ID equals f.WH_ID
                              where b.Product_ID == id_2
                              && t.Entry_Date >= Fromm && t.Entry_Date <= to
                              select new { f.WH_Name, b.WH_ID, t.Product_ID, t.Product_Name, t.Entry_Date, t.Production_Date, t.Expiry_Date, b.Quantity }).ToList();
                dataGridView1.DataSource = report;
            }
            catch
            {
                MessageBox.Show("InVaild Data ");
            }
        }

        private void Report2_Load(object sender, EventArgs e)
        {
            #region Product Load 
            var PROD_ID = (from d in Ware.Products

                           select d);

            foreach (var I in PROD_ID)
            {
                comboBox1.Items.Add(I.Product_ID);
            }
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
