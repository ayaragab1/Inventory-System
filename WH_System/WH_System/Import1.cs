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
    public partial class Import1 : Form
    {

        NSystemEntities Ware = new NSystemEntities();
        public int SerialNumb;
        public int WareHouseid;
       

        public Import1()
        {
            InitializeComponent();
        }

        private void Import1_Load(object sender, EventArgs e)
        {

            #region Warehouse Name  
            var WH_Name = (from d in Ware.Warehouses

                           select d);

            foreach (var I in WH_Name)
            {
                comboBox1.Items.Add(I.WH_ID);
            }
            #endregion
       
            #region Navogation Hide
            dataGridView1.DataSource = Ware.Import_Table.ToList();
            dataGridView1.Columns["Supplier"].Visible = false;
            dataGridView1.Columns["Employee"].Visible = false;
            dataGridView1.Columns["Product"].Visible = false; 
            #endregion
        }

        private void Insert_Click(object sender, EventArgs e)
        {

            try
            {
                Import_Table Imp = new Import_Table();

                Imp.Supplier_ID = int.Parse(comboBox2.Text);
                Imp.Product_ID = int.Parse(comboBox3.Text);
                Imp.Emp_ID = int.Parse(textBox3.Text);
                Imp.Quantity = int.Parse(textBox2.Text);
                Imp.Import_Number = int.Parse(textBox1.Text);
                Imp.Import_Date = dateTimePicker1.Value;
                Ware.Import_Table.Add(Imp);
                Ware.SaveChanges();

                MessageBox.Show("Done ! ");

                Reset();
            }
            catch
            {
                MessageBox.Show("Invild Data !");


            }
        }
        public void Reset()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = comboBox2.Text = comboBox3.Text = string.Empty;
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         

            int id = (int)comboBox1.SelectedItem;
            
            var emp = (from d in Ware.Warehouses
                       where d.WH_ID == id
                       select d.EmpResponsible_ID).FirstOrDefault();

            textBox3.Text = emp.ToString();

            var Produ = (from f in Ware.Werehouse_Product
                         where f.WH_ID == id
                         select f.Product_ID).ToList();


            foreach (var I in Produ)
            {
                comboBox3.Items.Add(I);

            }

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox3.Text);
            var sup = (from d in Ware.Import_Table
                       where d.Product_ID == id
                       select d.Supplier_ID).ToList();

            foreach(var I in sup)
            {
                comboBox2.Items.Add(I);
            }
         

        }

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Changes Saved ");

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                Import_Table Imp = new Import_Table();

                int id = int.Parse(textBox3.Text);
                int id1 = int.Parse(comboBox3.Text);
                int id2 = int.Parse(comboBox2.Text);

                Imp = (from d in Ware.Import_Table
                       where d.Emp_ID == id
                       where d.Product_ID == id1
                       where d.Supplier_ID == id2
                       select d).First();


                Imp.Quantity = int.Parse(textBox2.Text);
                Imp.Import_Number = int.Parse(textBox1.Text);
                Imp.Import_Date = dateTimePicker1.Value;
                Reset();
                Ware.SaveChanges();
                MessageBox.Show("Update Done !");
            }
            catch
            {
                MessageBox.Show("Invaild Data");
            }
            
           
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SerialNumb = int.Parse(textBox1.Text);
                WareHouseid = int.Parse(comboBox1.Text);
                Import_Preview PEX = new Import_Preview();
                PEX.SerilNum = SerialNumb;
                PEX.WarehouseName = WareHouseid;
                PEX.Show();
            }
            catch
            {
                MessageBox.Show("Invaild Data !");
            }
        }

      
    }
}
