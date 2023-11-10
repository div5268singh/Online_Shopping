using Online_Shopping_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Dependency_API.IRepository
{
    public interface IDCustomerRepository
    {
        public IEnumerable<CustomerViewModel> GetAllCustomer();
        public bool AddCustomer(CustomerViewModel model);
        public bool UpdateCustomer(CustomerViewModel model);
        public bool DeleteCustomer(int CustomerId);
        public CustomerViewModel CustumerFindById(int CustomerId);
    }
}
