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
    public partial class Transaction1 : Form
    {
        NSystemEntities Ware = new NSystemEntities();
      


        public Transaction1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Changes Saved !"); 
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void Transaction1_Load(object sender, EventArgs e)
        {

            #region Product Load 
            var PROD_ID = (from d in Ware.Products

                         select d);

            foreach (var I in PROD_ID)
            {
                comboBox1.Items.Add(I.Product_ID);
            }
            #endregion
            #region Warehouse Load  
            var WH_ID = (from d in Ware.Warehouses

                         select d);

            foreach (var I in WH_ID)
            {
                comboBox3.Items.Add(I.WH_ID);
            }
            #endregion
            #region Navigation Hiden
            dataGridView1.DataSource = Ware.Werehouse_Product.ToList();
            dataGridView1.Columns["Product"].Visible = false;
            dataGridView1.Columns["Warehouse"].Visible = false;

            #endregion

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Reset();
            int id = (int)comboBox1.SelectedItem;
            var Wh_From = (from d in Ware.Werehouse_Product
                      where d.Product_ID == id
                      select d.WH_ID).ToList();

            foreach (var i in Wh_From)
            {
                comboBox2.Items.Add(i);
            }
           

        }
        public void Reset()
        {
            textBox1.Text = comboBox2.Text=string.Empty;
            comboBox2.Items.Clear();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                Werehouse_Product WHP = new Werehouse_Product();
                Werehouse_Product WHPTo = new Werehouse_Product();
                int id = (int)comboBox2.SelectedItem ;
                int id1 = (int)comboBox1.SelectedItem;

                WHP = (from d in Ware.Werehouse_Product
                       where d.WH_ID == id where d.Product_ID == id1
                       select d).First();


             
             
                WHP.Quantity_Transfared =int.Parse (textBox1.Text);
                WHP.Transfare_from = (int)comboBox2.SelectedItem;
                WHP.Transfare_to = (int)comboBox3.SelectedItem;
                WHP.Transfare_Date = dateTimePicker1.Value;
        

                int Quant = int.Parse(textBox1.Text);
                WHP.Quantity -= Quant;


      

                int id2 = (int)comboBox3.SelectedItem;              
                WHPTo = (from d in Ware.Werehouse_Product
                       where d.WH_ID == id2
                       where d.Product_ID == id1
                       select d).First();

                WHPTo.Quantity += Quant;
                WHPTo.Transfare_Date = dateTimePicker1.Value;

                Ware.SaveChanges();
                MessageBox.Show("Transfare Done !");


            }
            catch
            {
                MessageBox.Show("Invalid Data !");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

       
        }
    }
}
