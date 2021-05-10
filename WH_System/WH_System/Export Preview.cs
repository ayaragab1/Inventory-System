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
    public partial class Export_Preview : Form
    {
        NSystemEntities Ware = new NSystemEntities();
        Export_Table Exp = new Export_Table(); 
        public int SerilNum { get; set; }    
        public int CustomName{ get; set; }
        public int WarehouseName { get; set; }


        public Export_Preview()
        {
            InitializeComponent();
            
        }
       

        private void Print_Export_Load(object sender, EventArgs e)
        {
            //int SerialNum = this.SerilNum;
            textBox1.Text = SerilNum.ToString();

            var Cus_name = (from f in Ware.Customers
                            where f.Customer_ID == this.CustomName
                            select f.Customer_Name).First();
            textBox3.Text = Cus_name;

            var WH_Name = (from f in Ware.Warehouses
                            where f.WH_ID == this.WarehouseName
                           select f.WH_Name).First();
            textBox2.Text = WH_Name;

            var Date = (from f in Ware.Export_Table
                        where f.Export_Number == SerilNum
                        select f.Export_Date).First();
            textBox4.Text = Date.ToString();

           

            var LoadColum = (from t in Ware.Export_Table join b in Ware.Products on t.Product_ID 
                     equals b.Product_ID where t.Export_Number == SerilNum
                     select new { t.Supplier_Name, b.Product_Name ,t.Quantity }).ToList();

             dataGridView1.DataSource = LoadColum;
        

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
