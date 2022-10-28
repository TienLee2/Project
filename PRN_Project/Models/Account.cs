using System;
using System.Collections.Generic;

#nullable disable

namespace PRN_Project.Models
{
    public partial class Account
    {
        public Account()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? IsCus { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CustomerType { get; set; }
        public int? BonusPoint { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
