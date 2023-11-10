using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Shopping_Model.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Photo { get; set; }
        public int Price { get; set; }
    }
}
