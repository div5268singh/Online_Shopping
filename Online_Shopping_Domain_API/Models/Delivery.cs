using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Domain_API.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
