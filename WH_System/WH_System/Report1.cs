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

    public partial class Report_1 : Form
    {
        NSystemEntities Ware = new NSystemEntities();
      
        public Report_1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Warehouse Name  
            var WH_Name = (from d in Ware.Warehouses

                           select d);

            foreach (var I in WH_Name)
            {
                comboBox1.Items.Add(I.WH_ID);
            }
            #endregion


        }



        private void button1_Click(object sender, EventArgs e)
        {

            int id = int.Parse(comboBox1.Text);
            //DateTime Fromm = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            //DateTime to = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());

            DateTime Fromm = dateTimePicker1.Value.Date;
            DateTime to = dateTimePicker2.Value.Date;

            var report = (from t in Ware.Products
                          join b in Ware.Werehouse_Product
                              on t.Product_ID equals b.Product_ID
                          where b.WH_ID == id
                          && t.Entry_Date >= Fromm && t.Entry_Date <= to
                          select t).ToList();
            dataGridView1.DataSource = report;

            var WH_N = (from d in Ware.Warehouses
                           where d.WH_ID == id
                           select d.WH_Name).FirstOrDefault();

            textBox1.Text = WH_N;


            var WH_LOC = (from d in Ware.Warehouses
                        where d.WH_ID == id
                        select d.WH_Location).FirstOrDefault();

            textBox2.Text = WH_LOC;


            var EmpName = (from d in Ware.Employees
                          where d.Emp_ID == id
                          select d.Emp_Name).FirstOrDefault();

            textBox3.Text = EmpName;
            #region Navigation hide
            //dataGridView1.DataSource = Ware.Suppliers.ToList();
            dataGridView1.Columns["Import_Table"].Visible = false;
            dataGridView1.Columns["Export_Table"].Visible = false;
           dataGridView1.Columns["Werehouse_Product"].Visible = false;


            #endregion
            #region Visibaility
            groupBox1.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            comboBox1.Visible = false;
            dataGridView1.Visible = true;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            button1.Visible = false;
            #endregion


        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
