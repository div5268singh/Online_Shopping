
using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Infrastructure_API.IRepository
{
    public interface ICustomerRepository
    {
        public Task<List<CustomerViewModel>> GetCustomerList();
        public Task<CustomerViewModel> AddCustomer(CustomerViewModel customer);
        public Task<CustomerViewModel> UpdateCustomer(CustomerViewModel customer);
        public Task<CustomerViewModel> GetCustomerById(int CustomerId);
        public bool DeleteCustomer(int CustomerId);        
    }
}
