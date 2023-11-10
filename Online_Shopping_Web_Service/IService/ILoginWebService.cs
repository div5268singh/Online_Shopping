using Online_Shopping_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Web_Service.IService
{
	public interface ILoginWebService
	{
		public List<CustomerViewModel> GetRoleList();
	}
}
