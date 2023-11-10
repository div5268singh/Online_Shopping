using System.ComponentModel.DataAnnotations.Schema;

namespace 
    
    Online_Shopping_Model.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }
}
