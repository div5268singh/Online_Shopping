
using AutoMapper;
using Online_Shopping_Domain_API.Models;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;
using Online_Shopping_Service.IService;

namespace Online_Shopping_Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<OrderViewModel>> GetOrderList()
        {
            var data = await _repository.GetOrderList();
            var result = _mapper.Map <List<OrderViewModel>> (data);
            return result;
		}
        public async Task<OrderViewModel> OrderProduct(OrderViewModel model)
        {
            var data = await _repository.OrderProduct(model);
            return data;
        }
        public Task<OrderViewModel> ChangeOrder(OrderViewModel model)
        {
            var data = _repository.ChangeOrder(model);
            return data;
        }

        public async Task<OrderViewModel> GetOrderById(int OrderId)
        {
            var data = await _repository.GetOrderById(OrderId);
            var seller = new OrderViewModel
            {
                OrderId = data.OrderId,
                CustomerId = data.CustomerId,
                ProductId = data.ProductId,
                Date = data.Date,
            };
            return seller;
        }
        public bool RemoveOrder(int OrderId)
        {
            return _repository.RemoveOrder(OrderId);
        }
    }
}
