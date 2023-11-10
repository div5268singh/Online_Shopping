using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Domain_API.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [ForeignKey("CatagoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ProductName { get; set; }
        public string Photo { get; set; }
        public int Price { get; set;}
        public bool IsDeleted { get; set; }
        public bool isAvailable { get; set; }
    }
}
