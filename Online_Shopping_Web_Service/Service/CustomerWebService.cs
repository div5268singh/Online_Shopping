using Newtonsoft.Json;
using Online_Shopping_Model.ViewModel;
using Online_Shopping_Web_Service.IService;
using Online_Shopping_Web_Service.Url;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Web_Service.Service
{
    public class CustomerWebService : ICustomerWebService
    {
        HttpClient client = new HttpClient();
		CustomUrl custom = new CustomUrl();
		public List<CustomerViewModel> GetAllCustomer()
        {
            var customer = client.GetAsync("http://localhost:5157/API/GetCustomerList").Result;
            var data = customer.Content.ReadAsStringAsync().Result;
            var finalData = JsonConvert.DeserializeObject<List<CustomerViewModel>>(data);
            return finalData;

        }

        public CustomerImageViewModel AddCustomer(CustomerImageViewModel customer)
        {
            if (customer != null)
            {
                var data = JsonConvert.SerializeObject(customer);
                StringContent result = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var res = client.PostAsync("http://localhost:5157/API/AddCustumer", result).Result;
            }
            return null;
        }

        public CustomerImageViewModel UpdateCustomer(CustomerImageViewModel customer)
        {
            if (customer != null)
            {
                var data = JsonConvert.SerializeObject(customer);
                StringContent result = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var res = client.PostAsync("http://localhost:5157/API/UpdateCustomer", result).Result;
            }
            return null;
        }

        public CustomerImageViewModel GetCustomerById(int CustomerId)
        {
            var res = client.GetAsync("http://localhost:5157/API/GetCustomerById?CustomerId=" + CustomerId + "").Result;
            var readData = res.Content.ReadAsStringAsync().Result;
            var finalData = JsonConvert.DeserializeObject<CustomerImageViewModel>(readData);
            return finalData;
        }

        public bool DeleteCustomer(int CustomerId)
        {
            if(CustomerId != 0)
            {
                var res = client.GetAsync("http://localhost:5157/API/DeleteCustumer?CustomerId=" + CustomerId + "").Result;
            }
            return false;
        }
    }
}
