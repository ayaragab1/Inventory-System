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
    public partial class Report3 : Form
    {
        NSystemEntities Ware = new NSystemEntities();
        public Report3()
        {
            InitializeComponent();
        }

        private void Report3_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id_2 = int.Parse(comboBox1.Text);
                DateTime Fromm = dateTimePicker1.Value.Date;
                DateTime to = dateTimePicker2.Value.Date;

                var report = (from t in Ware.Werehouse_Product
                              join d in Ware.Products on
                              t.Product_ID equals d.Product_ID
                              where t.Product_ID == id_2
                          && t.Transfare_Date >= Fromm && t.Transfare_Date <= to && t.Transfare_from != null
                              select new { t.WH_ID, d.Product_ID, d.Product_Name, t.Transfare_Date, t.Transfare_from, t.Transfare_to, t.Quantity, t.Quantity_Transfared }).ToList();
                dataGridView1.DataSource = report;
            }
            catch
            {
                MessageBox.Show("Invaild ID");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
