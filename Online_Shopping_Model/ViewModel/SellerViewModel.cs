using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Model.ViewModel
{
    public class SellerViewModel
    {
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public string SellerName { get; set; }
        public string Phone { get; set; }
    }
}
