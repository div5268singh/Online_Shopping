using Online_Shopping_Domain_API.Models;
using Online_Shopping_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Infrastructure_API.IRepository
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetOrderList();
        public Task<OrderViewModel> OrderProduct(OrderViewModel order);
        public Task<OrderViewModel> ChangeOrder(OrderViewModel order);
        public Task<OrderViewModel> GetOrderById(int OrderId);
        public bool RemoveOrder(int OrderId);
    }
}
