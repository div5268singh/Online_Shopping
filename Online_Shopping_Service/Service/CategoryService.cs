using AutoMapper;
using Online_Shopping_Domain_API.Models;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;
using Online_Shopping_Service.IService;

namespace Online_Shopping_Service.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<CategoryViewModel>> GetCatagoryList()
        {
            var data = await _repository.GetCatagoryList();
            var result = _mapper.Map<List<CategoryViewModel>>(data);
            return result;
        }

        public Task<CategoryViewModel> AddCatagory(CategoryViewModel model)
        {
            if(model != null) 
            {
				var data = _repository.AddCatagory(_mapper.Map<Category>(model));
			}
            return null;
            
        }
        public Task<CategoryViewModel> UpdateCatagory(CategoryViewModel model)
        {
			if (model != null)
			{
				var data = _repository.UpdateCatagory(_mapper.Map<Category>(model));
			}
			return null;
		}

        public async Task<CategoryViewModel> GetCatagoryById(int CategoryId)
        {
            var data = await _repository.GetCatagoryById(CategoryId);
            var catagory = new CategoryViewModel
            {
                CategoryId = data.CategoryId,
                CategoryName = data.CategoryName,
                CategoryType = data.CategoryType,
            };
            return catagory;
        }

        public bool DeleteCatagory(int CategoryID)
        {
            var data = _repository.DeleteCatagory(CategoryID);
            return data;
        }
    }
}
