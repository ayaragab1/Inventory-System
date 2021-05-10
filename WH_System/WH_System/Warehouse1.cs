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
    public partial class Warehouse1 : Form
    {
        NSystemEntities Ware = new NSystemEntities();
        Warehouse war = new Warehouse(); 
        public Warehouse1()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                war.WH_ID = int.Parse(textBox1.Text);
                war.WH_Name = textBox2.Text;
                war.WH_Location = textBox3.Text;
                var ID = (from d in Ware.Employees
                          where d.Emp_Name == comboBox1.SelectedItem.ToString()
                          select d.Emp_ID).First();
                war.EmpResponsible_ID = ID;

                Ware.Warehouses.Add(war);
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
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;

        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                war = (from d in Ware.Warehouses
                         where d.WH_ID == id
                         select d).First();
                war.WH_Name = textBox2.Text;
                var ID = (from d in Ware.Employees
                          where d.Emp_Name == comboBox1.SelectedItem.ToString()
                          select d.Emp_ID).First();
                war.EmpResponsible_ID = ID;
                Ware.SaveChanges();

                MessageBox.Show("Data Updated Successfully.");
                Reset();

            }
            catch 
            {
                MessageBox.Show("Invaild Data , Please Try Again");



            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Changes Saved");   
        }

        private void Warehouse1_Load(object sender, EventArgs e)
        {
            var resp = (from d in Ware.Employees
                        select d);

            foreach (var I in resp)
            {
                comboBox1.Items.Add(I.Emp_Name);
            }

            #region Navigation hide
            dataGridView1.DataSource = Ware.Warehouses.ToList();
            dataGridView1.Columns["Employee"].Visible = false;
            dataGridView1.Columns["Werehouse_Product"].Visible = false;           
            #endregion
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            textBox1.Text = dataGridView1.CurrentRow.Cells["WH_ID"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["WH_Name"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["WH_Location"].Value.ToString();
            dataGridView1.Refresh();
            dataGridView1.ReadOnly = true; 
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                war = (from d in Ware.Warehouses
                       where d.WH_ID == id
                       select d).First();
                Ware.Warehouses.Remove(war);
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
