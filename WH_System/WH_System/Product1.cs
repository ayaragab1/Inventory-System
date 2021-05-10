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
    public partial class Product1 : Form
    {
        NSystemEntities Ware = new NSystemEntities();
       
        public Product1()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                Product Prod = new Product();
                Werehouse_Product WHP = new Werehouse_Product();
                Prod.Product_ID = int.Parse(textBox1.Text);
                Prod.Product_Name = textBox2.Text;
                Prod.Measuring_Unit = textBox3.Text;
                Prod.Production_Date = dateTimePicker2.Value;
                Prod.Expiry_Date = dateTimePicker3.Value;
                Prod.Total_Quantity = int.Parse(textBox4.Text);
                Prod.Price = int.Parse(textBox5.Text);
                Prod.Entry_Date = dateTimePicker1.Value;
                WHP.Product_ID = int.Parse(textBox1.Text);
                WHP.WH_ID = (int)comboBox1.SelectedItem;
                WHP.Quantity = int.Parse(textBox4.Text);
                Ware.Werehouse_Product.Add(WHP); 
                Ware.Products.Add(Prod);
                Ware.SaveChanges();

                MessageBox.Show("Insert Done");

                Reset();
            }
            catch 
            {
                MessageBox.Show("Invaild Data , Please Try Again");

            }
        }
        public void Reset()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;

        }

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Changes Saved.");

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                Product Prod = new Product();
                Werehouse_Product WHP = new Werehouse_Product();
                int id = int.Parse(textBox1.Text);

                Prod = (from d in Ware.Products
                       where d.Product_ID == id
                       select d).First();
                Prod.Product_Name = textBox2.Text;
                Prod.Measuring_Unit = textBox3.Text; // Prod.Measuring_Unit;
                Prod.Production_Date = dateTimePicker2.Value;
                Prod.Expiry_Date = dateTimePicker3.Value;
                Prod.Total_Quantity = int.Parse(textBox4.Text);
                Prod.Price = int.Parse(textBox5.Text);
                Prod.Entry_Date = dateTimePicker1.Value;
                WHP.Product_ID = int.Parse(textBox1.Text);
                WHP.WH_ID = (int)comboBox1.SelectedItem;
                WHP.Quantity = int.Parse(textBox4.Text);
                Ware.SaveChanges();
                MessageBox.Show("Updated Successfully");

                Reset();

            }
            catch
            {
                MessageBox.Show("Invaild Data , Please Try Again");

                
            }
        }

        private void Product1_Load(object sender, EventArgs e)
        {
            #region Navigation hide
            dataGridView1.DataSource = Ware.Products.ToList();
            dataGridView1.Columns["Export_Table"].Visible = false;
            dataGridView1.Columns["Import_Table"].Visible = false;
            dataGridView1.Columns["Werehouse_Product"].Visible = false;

            #endregion

            #region WareHouse Load
            var WH_Name = (from d in Ware.Warehouses

                           select d);

            foreach (var I in WH_Name)
            {
                comboBox1.Items.Add(I.WH_ID);
            } 
            #endregion

        }

      
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Product Prod = new Product();
            Werehouse_Product WHP = new Werehouse_Product();
            DataGridViewRow row = dataGridView1.CurrentRow;
            int x = int.Parse(row.Cells[0].Value.ToString());
            Prod = (from t in Ware.Products where t.Product_ID == x select t).First();
            textBox1.Text = Prod.Product_ID.ToString();
            textBox2.Text= Prod.Product_Name ;
            textBox3.Text=Prod.Measuring_Unit;
            dateTimePicker2.Value = Prod.Production_Date.Value;
            dateTimePicker3.Value = Prod.Expiry_Date.Value;
            textBox4.Text = Prod.Total_Quantity.ToString();
            textBox5.Text = Prod.Price.ToString();
            dateTimePicker1.Value= Prod.Entry_Date.Value;

            Reset();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
