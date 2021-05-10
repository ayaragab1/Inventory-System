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
    public partial class Import_Preview : Form
    {
        NSystemEntities Ware = new NSystemEntities();
        Import_Table Exp = new Import_Table(); 
        public int SerilNum { get; set; }    
        public int EmployeeeName { get; set; }
        public int WarehouseName { get; set; }
        public Import_Preview()
        {
            InitializeComponent();
        }

        private void Import_Preview_Load(object sender, EventArgs e)
        {
            int SerialNum = this.SerilNum;
            textBox1.Text = SerialNum.ToString();
          

            var WH_Name = (from f in Ware.Warehouses
                           where f.WH_ID == this.WarehouseName
                           select f.WH_Name).First();
            textBox2.Text = WH_Name;

            var Date = (from f in Ware.Import_Table
                        where f.Import_Number == SerialNum
                        select f.Import_Date).First();
            textBox4.Text = Date.ToString();


            var LoadColum = (from t in Ware.Import_Table
                             join b in Ware.Products on t.Product_ID
                             equals b.Product_ID
                             join c in Ware.Suppliers on t.Supplier_ID
                             equals c.Supplier_ID
                             where t.Import_Number == SerialNum
                             select new { c.Supplier_Name, b.Product_Name, t.Quantity , b.Production_Date , b.Expiry_Date}).ToList();

            dataGridView1.DataSource = LoadColum;
        }
    }
}
