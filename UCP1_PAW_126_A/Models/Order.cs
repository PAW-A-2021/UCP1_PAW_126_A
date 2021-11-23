using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_126_A.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int? Price { get; set; }
        public DateTime? Date { get; set; }
        public int? IdMenu { get; set; }

        public virtual Menu IdMenuNavigation { get; set; }
    }
}
