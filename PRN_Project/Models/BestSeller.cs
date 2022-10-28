using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PRN_Project.Models
{
    public partial class BestSeller
    {
        [Key]
        public int BillId { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int TotalNum { get; set; }


        public virtual Product IdProductNavigation { get; set; }
    }
}
