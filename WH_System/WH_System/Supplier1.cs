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
    public partial class Supplier1 : Form
    {
        NSystemEntities Ware = new NSystemEntities();
        public Supplier1()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier Supp = new Supplier();

                #region Data
                Supp.Supplier_ID = int.Parse(textBox1.Text);
                Supp.Supplier_Name = textBox2.Text;
                Supp.Supplier_Phone = int.Parse(textBox3.Text);
                Supp.Supplier_Mobile = int.Parse(textBox4.Text);
                Supp.Supplier_Email = textBox5.Text;
                Supp.Supplier_Fax = textBox6.Text;
                Supp.Supplier_WebSite = textBox7.Text; 
                #endregion
                Ware.Suppliers.Add(Supp);
                Ware.SaveChanges();

                MessageBox.Show("Insert Done ");

                Reset();
            }
            catch
            {
                MessageBox.Show("Invaild Data , Please Try Again");


            }
        }
        public void Reset()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox6.Text= textBox7.Text = string.Empty;

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Changes Saved.");
        }

        private void Update_Click(object sender, EventArgs e)
        {

            try
            {
                Supplier Supp = new Supplier();

                #region Data
                int id = int.Parse(textBox1.Text);

                Supp = (from d in Ware.Suppliers
                        where d.Supplier_ID == id
                        select d).First();

                Supp.Supplier_Name = textBox2.Text;
                Supp.Supplier_Phone = int.Parse(textBox3.Text);
                Supp.Supplier_Mobile = int.Parse(textBox4.Text);
                Supp.Supplier_Email = textBox5.Text;
                Supp.Supplier_Fax = textBox6.Text;
                Supp.Supplier_WebSite = textBox7.Text; 
                #endregion
                Ware.SaveChanges();
                MessageBox.Show("Updated Successfully.");

                Reset();

            }
            catch
            {
                MessageBox.Show("Invaild Data , Please Try Again.");


            }
        }

        private void Supplier1_Load(object sender, EventArgs e)
        {
            #region Navigation hide
            dataGridView1.DataSource = Ware.Suppliers.ToList();
            dataGridView1.Columns["Import_Table"].Visible = false;
            #endregion

        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Views
            textBox1.Text = dataGridView1.CurrentRow.Cells["Supplier_ID"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Supplier_Name"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Supplier_Mobile"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Supplier_Phone"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["Supplier_Email"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["Supplier_Fax"].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells["Supplier_WebSite"].Value.ToString();
            #endregion


            dataGridView1.Refresh();
            dataGridView1.ReadOnly = true;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier Supp = new Supplier();
                int id = int.Parse(textBox1.Text);
                Supp = (from d in Ware.Suppliers
                        where d.Supplier_ID == id
                        select d).First();
                Ware.Suppliers.Remove(Supp);
                Ware.SaveChanges();
                MessageBox.Show("Delete Done ");

            }
            catch
            {
                MessageBox.Show("Invaild ID ");
            }

        }
    }
}
