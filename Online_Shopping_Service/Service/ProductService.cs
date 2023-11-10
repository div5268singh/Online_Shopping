using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;
using Online_Shopping_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ProductViewModel>> GetProductList()
        {
            var data = await _repository.GetProductList();
            return data;
        }

        public Task<ProductViewModel> AddProduct(ProductViewModel model)
        {
            var data = _repository.AddProduct(model);
            return data;
        }
        public Task<ProductViewModel> UpdateProduct(ProductViewModel model)
        {
            var data = _repository.UpdateProduct(model);
            return data;
        }

        public async Task<ProductViewModel> GetProductById(int ProductId)
        {
            var data = await _repository.GetProductById(ProductId);
            var product = new ProductViewModel
            {
                ProductId = data.ProductId,
                CategoryId = data.CategoryId,
                ProductName = data.ProductName,
                Photo = data.Photo,
                Price = data.Price
            };
            return product;
        }

        public bool DeleteProduct(int ProductId)
        {
            return _repository.DeleteProduct(ProductId);
        }
    }
}
