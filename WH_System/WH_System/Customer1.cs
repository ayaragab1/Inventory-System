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
    public partial class Customer1 : Form
    {

        NSystemEntities Ware = new NSystemEntities();
        public Customer1()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                Customer Cust = new Customer();

                #region data
                Cust.Customer_ID = int.Parse(textBox8.Text);
                Cust.Customer_Name = textBox9.Text;
                Cust.Customer_Phone = int.Parse(textBox11.Text);
                Cust.Customer_Mobile = int.Parse(textBox14.Text);
                Cust.Customer_Email = textBox13.Text;
                Cust.Customer_Fax = textBox12.Text;
                Cust.Customer_Website = textBox10.Text; 
                #endregion
                Ware.Customers.Add(Cust);
                Ware.SaveChanges();

                MessageBox.Show("Insert Done.");

                Reset();
            }
            catch
            {
                MessageBox.Show("Invaild Data, please Try Again");


            }
        }
        public void Reset()
        {
            textBox8.Text = textBox9.Text = textBox10.Text = textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text =  string.Empty;


        }

        private void Update_Click(object sender, EventArgs e)
        {
            Customer Cust = new Customer();

            try
            {
                #region Data
                int id = int.Parse(textBox8.Text);
                Cust = (from d in Ware.Customers
                        where d.Customer_ID == id
                        select d).First();
                Cust.Customer_Name = textBox9.Text;
                Cust.Customer_Phone = int.Parse(textBox11.Text);
                Cust.Customer_Mobile = int.Parse(textBox14.Text);
                Cust.Customer_Email = textBox13.Text;
                Cust.Customer_Fax = textBox12.Text;
                Cust.Customer_Website = textBox10.Text; 
                #endregion
                Ware.SaveChanges();
                MessageBox.Show("Update Successfully .");
                Reset();

            }
            catch
            {
                MessageBox.Show("Invaild Data , Please Try Again ");
                 
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Changes Saved.");

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Customer1_Load(object sender, EventArgs e)
        {
            #region Navigation hide
            dataGridView1.DataSource = Ware.Customers.ToList();
            dataGridView1.Columns["Export_Table"].Visible = false;           
            #endregion
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            #region Views
            textBox8.Text = dataGridView1.CurrentRow.Cells["Customer_ID"].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells["Customer_Name"].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells["Customer_Website"].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells["Customer_Phone"].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells["Customer_Fax"].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells["Customer_Email"].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells["Customer_Mobile"].Value.ToString(); 
            #endregion

            dataGridView1.Refresh();
            dataGridView1.ReadOnly = true;


          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Customer Cust = new Customer();

                int id = int.Parse(textBox8.Text);
                Cust = (from d in Ware.Customers
                       where d.Customer_ID == id
                       select d).First();
                Ware.Customers.Remove(Cust);
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
