using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Model.ViewModel
{
    public class AdminViewModel
    {
        public int AdminId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Emai { get; set; }
        public string Password { get; set; }
    }
}
