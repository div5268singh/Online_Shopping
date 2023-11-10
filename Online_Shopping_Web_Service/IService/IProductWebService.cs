using Online_Shopping_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Web_Service.IService
{
    public interface IProductWebService
    {
        public List<ProductViewModel> GetProductList();
        public ProductImageViewModel AddProduct(ProductImageViewModel product);
        public ProductImageViewModel UpdateProduct(ProductImageViewModel product);
        public ProductImageViewModel GetProductById(int ProductId);
        public bool DeleteProduct(int ProductId);
    }
}
