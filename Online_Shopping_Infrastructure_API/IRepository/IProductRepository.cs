

using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Infrastructure_API.IRepository
{
    public interface IProductRepository
    {
        public Task<List<ProductViewModel>> GetProductList();
        public Task<ProductViewModel> AddProduct(ProductViewModel product);
        public Task<ProductViewModel> UpdateProduct(ProductViewModel product);
        public Task<ProductViewModel> GetProductById(int ProductId);
        public bool DeleteProduct(int ProductId);
    }
}
