
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online_Shopping_Domain_API.Data;
using Online_Shopping_Domain_API.Models;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Infrastructure_API.Repopsitory
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CustomerViewModel>> GetCustomerList()
        {
            var customer = await _context.Customers.ToListAsync();
            var data = _mapper.Map<List<CustomerViewModel>>(customer);
            return data;
        }
        public async Task<CustomerViewModel> AddCustomer(CustomerViewModel model)
        {
            if (model != null)
            {
                await _context.Customers.AddAsync(_mapper.Map<Customer>(model));
                _context.SaveChanges();                                
            }
            return null;
        }
        public Task<CustomerViewModel> UpdateCustomer(CustomerViewModel model)
        {
            if (model != null)
            {
                _context.Customers.Update(_mapper.Map<Customer>(model));
                _context.SaveChanges();
            }
            return null;
        }
        public async Task<CustomerViewModel> GetCustomerById(int CustomerId)
        {
            if (CustomerId != 0)
            {
                var customer = await _context.Customers.Where(x => x.CustomerId == CustomerId).FirstOrDefaultAsync();
                var data = _mapper.Map<CustomerViewModel>(customer);
                return data;
            }
            return null;
        }

        public bool DeleteCustomer(int CustomerId)
        {
            var customer = _context.Customers.Where(x => x.CustomerId == CustomerId).FirstOrDefault();
            var data = _mapper.Map<Customer>(customer);
            if(data != null)
            {
                _context.Customers.Remove(data);
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
