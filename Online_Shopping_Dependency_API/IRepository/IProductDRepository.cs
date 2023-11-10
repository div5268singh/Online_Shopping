using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Dependency_API.IRepository
{
    public interface IProductDRepository
    {
        Task<List<ProductViewModel>> GetCatagory();
        Task<ProductViewModel> AddCatagory(ProductViewModel model);
        Task<ProductViewModel> UpdateCatagory(int CategoryID);
        Task<ProductViewModel> DeleteCatagory(int CategoryID);
    }
}
