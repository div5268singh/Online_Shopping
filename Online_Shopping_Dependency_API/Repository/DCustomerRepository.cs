
using Online_Shopping_Dependency_API.IRepository;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Dependency_API.Repository
{
    public class DCustomerRepository : IDCustomerRepository
    {
        private readonly ICustomerRepository _repository;
        public DCustomerRepository(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<CustomerViewModel> GetAllCustomer()
        {
            var customer = _repository.GetAllCustomer();
            return customer;
        }
        public bool AddCustomer(CustomerViewModel model)
        {
            var customer = _repository.AddCustomer(model);
            return customer;
        }
        public bool UpdateCustomer(CustomerViewModel model)
        {
            var customer = _repository.UpdateCustomer(model);
            return customer;
        }

        public bool DeleteCustomer(int CustomerId)
        {
            var customer = _repository.DeleteCustomer(CustomerId);
            return customer;
        }

        public CustomerViewModel CustumerFindById(int CustomerId)
        {
            return _repository.FindCustomerById(CustomerId);
        }
    }
}
