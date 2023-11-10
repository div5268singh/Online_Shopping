
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online_Shopping_Domain_API.Data;
using Online_Shopping_Domain_API.Models;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Infrastructure_API.Repopsitory
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public OrderRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Order>> GetOrderList()
        {
            return await _context
                .Orders.Where(x => x.IsDeleted == false)
                .ToListAsync();
            
        }
        public async Task<OrderViewModel> OrderProduct(OrderViewModel model)
        {
            if (model != null)
            {
                await _context.Orders.AddAsync(_mapper.Map<Order>(model));
                _context.SaveChanges();
            }
            return null;
        }
        public Task<OrderViewModel> ChangeOrder(OrderViewModel model)
        {
            if (model != null)
            {
                _context.Orders.Update(_mapper.Map<Order>(model));
                _context.SaveChanges();
            }
            return null;
        }
        public async Task<OrderViewModel> GetOrderById(int OrderId)
        {
            if (OrderId != 0)
            {
                var order = await _context.Orders.Where(x => x.OrderId == OrderId).FirstOrDefaultAsync();
                var data = _mapper.Map<OrderViewModel>(order);
                return data;
            }
            return null;
        }

        public bool RemoveOrder(int OrderId)
        {
            var order = _context.Orders.Where(x => x.OrderId == OrderId).FirstOrDefault();
            var data = _mapper.Map<Order>(order);
            if (data != null)
            {
                _context.Orders.Remove(data);
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
