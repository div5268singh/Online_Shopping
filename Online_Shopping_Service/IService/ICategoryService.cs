using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Service.IService
{
    public interface ICategoryService
    {
        public Task<List<CategoryViewModel>> GetCatagoryList();
        public Task<CategoryViewModel> AddCatagory(CategoryViewModel catagory);
        public Task<CategoryViewModel> UpdateCatagory(CategoryViewModel catagory);
        public Task<CategoryViewModel> GetCatagoryById(int CatagoryId);
        public bool DeleteCatagory(int CatagoryId);
    }
}
