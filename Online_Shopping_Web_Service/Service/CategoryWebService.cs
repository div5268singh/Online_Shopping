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
    public class CategoryWebService :ICategoryWebService
    {
        HttpClient client = new HttpClient();

        public List<CategoryViewModel> GetCategoryList()
        {
            var customer = client.GetAsync("http://localhost:5157/API/GetCategoryList").Result;
            var data = customer.Content.ReadAsStringAsync().Result;
            var finalData = JsonConvert.DeserializeObject<List<CategoryViewModel>>(data);
            return finalData;
        }

        public CategoryViewModel AddCategory(CategoryViewModel category)
        {
            if (category != null)
            {
                var data = JsonConvert.SerializeObject(category);
                StringContent result = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var res = client.PostAsync("http://localhost:5157/API/AddCategory", result).Result;
            }
            return null;
        }

        public CategoryViewModel UpdateCategory(CategoryViewModel category)
        {
            if (category != null)
            {
                var data = JsonConvert.SerializeObject(category);
                StringContent result = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var res = client.PostAsync("http://localhost:5157/API/UpdateCategory", result).Result;
            }
            return null;
        }

        public CategoryViewModel GetCategoryById(int CategoryId)
        {
            var res = client.GetAsync("http://localhost:5157/API/GetCategoryById?CatagoryId=" + CategoryId + "").Result;
            var readData = res.Content.ReadAsStringAsync().Result;
            var finalData = JsonConvert.DeserializeObject<CategoryViewModel>(readData);
            return finalData;
        }

        public bool DeleteCategory(int CategoryId)
        {
            if (CategoryId != 0)
            {
                var res = client.GetAsync("http://localhost:5157/API/DeleteCategory?CatagoryId=" + CategoryId + "").Result;
            }
            return false;
        }
    }
}
