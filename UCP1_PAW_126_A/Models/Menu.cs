using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_126_A.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Orders = new HashSet<Order>();
        }

        public int IdMenu { get; set; }
        public string About { get; set; }
        public string Product { get; set; }
        public int? IdOrder { get; set; }
        public int? IdAdmin { get; set; }

        public virtual Admiin IdAdminNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
