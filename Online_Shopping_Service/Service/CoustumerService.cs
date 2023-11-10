using Online_Shopping_Domain_API.Models;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;
using Online_Shopping_Service.IService;
using System.Net;

namespace Online_Shopping_Service.Service
{
    public class CoustumerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CoustumerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<CustomerViewModel>> GetCustomerList()
        {
            var data = await _repository.GetCustomerList();
            return data;
        }

        public Task<CustomerViewModel> AddCustomer(CustomerViewModel model)
        {
            var data =  _repository.AddCustomer(model);
            return data;
        }
        public Task<CustomerViewModel> UpdateCustomer(CustomerViewModel model)
        {
            var data = _repository.UpdateCustomer(model);
            return data;
        }

        public async Task<CustomerViewModel> GetCustomerById(int CustomerId)
        {
            var data = await _repository.GetCustomerById(CustomerId);
            var customer = new CustomerViewModel
            {
                CustomerId = data.CustomerId,
                CustomerName = data.CustomerName,
                Phone = data.Phone,
                Address = data.Address,
                City = data.City,
                PostalCode = data.PostalCode,
                Country = data.Country,
                Photo = data.Photo,
                Email = data.Email,
                Password = data.Password
            };
            return customer;
        }

        public bool DeleteCustomer(int CustomerId)
        {
            return _repository.DeleteCustomer(CustomerId);
        }
    }
}
