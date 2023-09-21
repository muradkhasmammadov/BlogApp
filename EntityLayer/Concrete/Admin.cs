using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public String Username{ get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String ShortDescription { get; set; }
        public String ImageUrl { get; set; }
        public String Role { get; set; }
    }
}
