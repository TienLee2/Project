using System;
using System.Collections.Generic;

#nullable disable

namespace PRN_Project.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public DateTime? Date { get; set; }
        public int? IdAccount { get; set; }
        public double? Total { get; set; }

        public virtual Account IdAccountNavigation { get; set; }
    }
}
