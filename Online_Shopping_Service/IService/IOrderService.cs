
using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Service.IService
{
    public interface IOrderService
    {
        public Task<List<OrderViewModel>> GetOrderList();
        public Task<OrderViewModel> OrderProduct(OrderViewModel order);
        public Task<OrderViewModel> ChangeOrder(OrderViewModel order);
        public Task<OrderViewModel> GetOrderById(int OrderId);
        public bool RemoveOrder(int OrderId);
    }
}
