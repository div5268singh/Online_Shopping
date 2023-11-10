

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online_Shopping_Domain_API.Data;
using Online_Shopping_Domain_API.Models;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Infrastructure_API.Repopsitory
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductViewModel>> GetProductList()
        {
            var product = await _context.Products.ToListAsync();
            var data = _mapper.Map<List<ProductViewModel>>(product);
            return data;
        }
        public async Task<ProductViewModel> AddProduct(ProductViewModel model)
        {
            if (model != null)
            {
                await _context.Products.AddAsync(_mapper.Map<Product>(model));
                _context.SaveChanges();
            }
            return null;
        }
        public Task<ProductViewModel> UpdateProduct(ProductViewModel model)
        {
            if (model != null)
            {
                _context.Products.Update(_mapper.Map<Product>(model));
                _context.SaveChanges();
            }
            return null;
        }
        public async Task<ProductViewModel> GetProductById(int ProductId)
        {
            if (ProductId != 0)
            {
                var product = await _context.Products.Where(x => x.ProductID == ProductId).FirstOrDefaultAsync();
                var data = _mapper.Map<ProductViewModel>(product);
                return data;
            }
            return null;
        }

        public bool DeleteProduct(int ProductId)
        {
            var catagory = _context.Products.Where(x => x.ProductID == ProductId).FirstOrDefault();
            var data = _mapper.Map<Product>(catagory);
            if (data != null)
            {
                _context.Products.Remove(data);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
