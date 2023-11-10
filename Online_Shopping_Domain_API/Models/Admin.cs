using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Domain_API.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Emai { get; set; }
        public string Password { get; set; }
    }
}
