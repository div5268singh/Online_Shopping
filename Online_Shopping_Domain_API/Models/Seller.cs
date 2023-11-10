using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Domain_API.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string SellerName { get; set; }
        public string Phone { get;}
        public bool IsDeleted { get; set; }
    }
}
