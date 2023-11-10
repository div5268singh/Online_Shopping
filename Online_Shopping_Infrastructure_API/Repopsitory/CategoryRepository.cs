using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online_Shopping_Domain_API.Data;
using Online_Shopping_Domain_API.Models;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Infrastructure_API.Repopsitory
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Category>> GetCatagoryList()
        {
            return await _context
                .Catagories
                .ToListAsync();
        }
        public async Task<Category> AddCatagory(Category model)
        {
            if (model != null)
            {
                await _context.Catagories.AddAsync(model);
                _context.SaveChanges();
            }
            return null;
        }
        public Task<Category> UpdateCatagory(Category model)
        {
            if (model != null)
            {
				 _context.Catagories.Update(model);
				_context.SaveChanges();
			}
            return null;
        }
        public async Task<CategoryViewModel> GetCatagoryById(int CatagoryId)
        {
            if (CatagoryId != 0)
            {
                var catagory = await _context.Catagories.Where(x => x.CategoryId == CatagoryId).FirstOrDefaultAsync();
                var data = _mapper.Map<CategoryViewModel>(catagory);
                return data;
            }
            return null;
        }

        public bool DeleteCatagory(int CatagoryId)
        {
            var catagory = _context.Catagories.Where(x => x.CategoryId == CatagoryId).FirstOrDefault();
            var data = _mapper.Map<Category>(catagory);
            if (data != null)
            {
                _context.Catagories.Remove(data);
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
