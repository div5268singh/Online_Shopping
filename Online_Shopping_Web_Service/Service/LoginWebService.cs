using Newtonsoft.Json;
using Online_Shopping_Model.ViewModel;
using Online_Shopping_Web_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Web_Service.Service
{
	public class LoginWebService : ILoginWebService
	{
		HttpClient client = new HttpClient();
		public List<CustomerViewModel> GetRoleList()
		{
			var customer = client.GetAsync("http://localhost:5157/API/GetCustomerList").Result;
			var data = customer.Content.ReadAsStringAsync().Result;
			var finalData = JsonConvert.DeserializeObject<List<CustomerViewModel>>(data);
			return finalData;
		}
	}
}
