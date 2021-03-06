//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WH_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Export_Table = new HashSet<Export_Table>();
            this.Import_Table = new HashSet<Import_Table>();
            this.Werehouse_Product = new HashSet<Werehouse_Product>();
        }
    
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Measuring_Unit { get; set; }
        public Nullable<System.DateTime> Production_Date { get; set; }
        public Nullable<System.DateTime> Expiry_Date { get; set; }
        public Nullable<int> Total_Quantity { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<System.DateTime> Entry_Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Export_Table> Export_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Import_Table> Import_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Werehouse_Product> Werehouse_Product { get; set; }
    }
}
