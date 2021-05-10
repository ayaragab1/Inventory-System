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
    public partial class Export1 : Form
    {

        NSystemEntities Ware = new NSystemEntities();
        
        public int SerialNumb;
        public int Customerid;
        public int WareHouseid;


        public Export1()
        {
            InitializeComponent();
        }

        private void Export1_Load(object sender, EventArgs e)
        {
            #region Warehouse Load  
            var WH_ID = (from d in Ware.Warehouses

                           select d);

            foreach (var I in WH_ID)
            {
                comboBox4.Items.Add(I.WH_ID);
            }
            #endregion

            #region Customer Load
            var Custm_Name = (from d in Ware.Customers

                              select d);

            foreach (var I in Custm_Name)
            {
                comboBox2.Items.Add(I.Customer_ID);
            }
            #endregion

            #region Navigation hide
            dataGridView1.DataSource = Ware.Export_Table.ToList();
            dataGridView1.Columns["Customer"].Visible = false;
            dataGridView1.Columns["Employee"].Visible = false;
            dataGridView1.Columns["Product"].Visible = false;   
            #endregion
        }

        public void Reset()
        {
            textBox2.Text = comboBox3.Text=textBox3.Text = string.Empty;

        }
     

       

        private void ComboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int id = (int)comboBox4.SelectedItem;
            Employee emeep = new Employee();
            var emp = (from d in Ware.Warehouses
                       where d.WH_ID == id
                       select d.EmpResponsible_ID).FirstOrDefault();

            textBox1.Text = emp.ToString();

            var Produ = (from f in Ware.Werehouse_Product
                         where f.WH_ID == id
                         select f.Product_ID).ToList();


            foreach (var I in Produ)
            {
                comboBox3.Items.Add(I);

            }
        }

        private void ComboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox3.Text);
            var sup = (from d in Ware.Import_Table
                       where d.Product_ID == id
                       select d.Supplier_ID).FirstOrDefault();

            var sup_name = (from f in Ware.Suppliers
                            where f.Supplier_ID == sup
                            select f.Supplier_Name).First();

            textBox3.Text = sup_name;

        }

        private void Insert_Click_1(object sender, EventArgs e)
        {
            try
            {

                Export_Table Exp = new Export_Table();
                Exp.Customer_ID = int.Parse(comboBox2.Text);
                Exp.Product_ID = int.Parse(comboBox3.Text);
                Exp.Emp_ID = int.Parse(textBox1.Text);
                Exp.Quantity = int.Parse(textBox2.Text);
                Exp.Supplier_Name = textBox3.Text;
                Exp.Export_Date = dateTimePicker1.Value;
                Exp.Export_Number = int.Parse(textBox4.Text);
                Ware.Export_Table.Add(Exp);
                Ware.SaveChanges();

                MessageBox.Show("Insert Done");

                Reset();
            }
            catch
            {
                MessageBox.Show("Invaild Data , Please Try Again !");


            }
        }

        private void Update_Click_1(object sender, EventArgs e)
        {
            try
            {
                Export_Table Exp = new Export_Table();
                int id = int.Parse(textBox1.Text);
                int id2 = int.Parse(comboBox2.Text);
                int id3 = int.Parse(comboBox3.Text);
                Exp = (from d in Ware.Export_Table
                       where d.Emp_ID == id
                       where d.Customer_ID == id2
                       where d.Product_ID == id3
                       select d).First();


                Exp.Quantity = int.Parse(textBox2.Text);
                Exp.Supplier_Name = Exp.Supplier_Name;
                Exp.Export_Date = Exp.Export_Date;
                Exp.Export_Number = Exp.Export_Number;
                Ware.SaveChanges();

                MessageBox.Show("Updates Done ");
            }
            catch
            {
                MessageBox.Show("Invalid Data , please Try Again ");

            }

        }

        private void Save_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Changes Saved ");
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            #region Views

            textBox1.Text = dataGridView1.CurrentRow.Cells["Emp_ID"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["Customer_ID"].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells["Product_ID"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Quantity"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["Export_Date"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Export_Number"].Value.ToString();

            #endregion

            dataGridView1.Refresh();
            dataGridView1.ReadOnly = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SerialNumb = int.Parse(textBox4.Text);
            Customerid = int.Parse(comboBox2.Text);
            WareHouseid = int.Parse(comboBox4.Text);


            Export_Preview PEX = new Export_Preview();
            PEX.SerilNum = SerialNumb;
            PEX.CustomName = Customerid;
            PEX.WarehouseName = WareHouseid;

            PEX.Show();
        }

       
    }
}

      