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
    public partial class Employee1 : Form
    {
        NSystemEntities Ware = new NSystemEntities();
       
        public Employee1()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Changes Saved.");
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void InsertEmp_Click(object sender, EventArgs e)
        {
            try
          {
                Employee Emp = new Employee();
                Emp.Emp_ID = int.Parse(textBox1.Text);
                Emp.Emp_Name = textBox2.Text;
                Emp.Emp_Phone = int.Parse(textBox3.Text);
                Emp.Emp_Address = textBox4.Text;
                Emp.Emp_Mail = textBox5.Text;
                Ware.Employees.Add(Emp);
                Ware.SaveChanges();
                MessageBox.Show("Insert Done ");
                Reset();
            }
            catch 
            {
                MessageBox.Show("Invaild Data, Please Try Again");              
            }
        }

        public void Reset()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
        }

        private void UpdateEmp_Click(object sender, EventArgs e)
        {
            try
            {
                Employee Emp = new Employee();
                int id = int.Parse(textBox1.Text);
                Emp = (from d in Ware.Employees
                       where d.Emp_ID == id
                       select d).First();
                Emp.Emp_Name = textBox2.Text;
                Emp.Emp_Phone = int.Parse(textBox3.Text);
                Emp.Emp_Address = textBox4.Text;
                Emp.Emp_Mail = textBox5.Text;
                Ware.SaveChanges();
                MessageBox.Show("Data Updated Successfully.");
                Reset();
            }
            catch 
            {
                MessageBox.Show("Invaild Data , Please Try Again");
            }
        }

        private void Employee1_Load(object sender, EventArgs e)
        {
            #region Navigation hide
            dataGridView1.DataSource = Ware.Employees.ToList();
            dataGridView1.Columns["Export_Table"].Visible = false;
            dataGridView1.Columns["Import_Table"].Visible = false;
            dataGridView1.Columns["Warehouses"].Visible = false;
            #endregion
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
            #region Views
            textBox1.Text = dataGridView1.CurrentRow.Cells["Emp_ID"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Emp_Name"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Emp_Phone"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Emp_Address"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["Emp_Mail"].Value.ToString();

            #endregion

            dataGridView1.Refresh();
            dataGridView1.ReadOnly = true;

        }
    }
}
