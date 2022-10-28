using System;
using System.Collections.Generic;

#nullable disable

namespace PRN_Project.Models
{
    public partial class Category
    {
     
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Idcid { get; set; }
        public string NameCid { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}
