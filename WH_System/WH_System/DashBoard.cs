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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void Werehouse_Click(object sender, EventArgs e)
        {
            Warehouse1 we = new Warehouse1();
            we.Show(); 
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            Customer1 Cust = new Customer1();
            Cust.Show(); 
            
        }

        private void Transaction_Click(object sender, EventArgs e)
        {
            Transaction1 trans = new Transaction1();
            trans.Show(); 
        }

        private void Employee_Click(object sender, EventArgs e)
        {
            Employee1 Employ = new Employee1();
            Employ.Show(); 
        }

        private void Supplier_Click(object sender, EventArgs e)
        {
            Supplier1 Supp = new Supplier1();
            Supp.Show(); 
        }

        private void Export_Click(object sender, EventArgs e)
        {
            Export1 Exp = new Export1();
            Exp.Show(); 
        }

        private void Product_Click(object sender, EventArgs e)
        {
            Product1 Prod = new Product1();
            Prod.Show(); 
        }

        private void Import_Click(object sender, EventArgs e)
        {
            Import1 Imp = new Import1();
            Imp.Show(); 


        }

        private void Report_Click(object sender, EventArgs e)
        {
            Reports rprts = new Reports();
            rprts.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
