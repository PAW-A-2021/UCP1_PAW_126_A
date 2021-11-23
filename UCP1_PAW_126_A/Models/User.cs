using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_126_A.Models
{
    public partial class User
    {
        public User()
        {
            Admiins = new HashSet<Admiin>();
        }

        public int IdUser { get; set; }
        public string Name { get; set; }
        public int? Password { get; set; }

        public virtual ICollection<Admiin> Admiins { get; set; }
    }
}
