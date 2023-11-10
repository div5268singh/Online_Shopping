using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Dependency_API.IRepository
{
    public interface IOrderDRepository
    {
        Task<List<OrderViewModel>> GetCatagory();
        Task<OrderViewModel> AddCatagory(OrderViewModel model);
        Task<OrderViewModel> UpdateCatagory(int CategoryID);
        Task<OrderViewModel> DeleteCatagory(int CategoryID);
    }
}
