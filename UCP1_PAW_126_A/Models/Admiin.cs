using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_126_A.Models
{
    public partial class Admiin
    {
        public Admiin()
        {
            Menus = new HashSet<Menu>();
        }

        public int IdAdmin { get; set; }
        public int? IdUser { get; set; }
        public int? Password { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
