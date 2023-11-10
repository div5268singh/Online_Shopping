using Online_Shopping_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Web_Service.IService
{
    public interface ICustomerWebService
    {
        public List<CustomerViewModel> GetAllCustomer();
        public CustomerImageViewModel AddCustomer(CustomerImageViewModel customer);
        public CustomerImageViewModel UpdateCustomer(CustomerImageViewModel customer);
        public CustomerImageViewModel GetCustomerById(int CustomerId);
        public bool DeleteCustomer(int CustomerId);
    }
}
