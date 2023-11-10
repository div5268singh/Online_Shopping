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
    
    public class ProductWebService : IProductWebService
    {
        HttpClient client = new HttpClient();
        public List<ProductViewModel> GetProductList()
        {
            var product = client.GetAsync("http://localhost:5157/API/GetProductList").Result;
            var data = product.Content.ReadAsStringAsync().Result;
            var finalData = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
            return finalData;
           
        }
        public ProductImageViewModel AddProduct(ProductImageViewModel product)
        {
            if (product != null)
            {
                var data = JsonConvert.SerializeObject(product);
                StringContent result = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var res = client.PostAsync("http://localhost:5157/API/AddProduct", result).Result;
            }
            return null;
        }
        public ProductImageViewModel GetProductById(int ProductId)
        {
            var res = client.GetAsync("http://localhost:5157/API/GetProductById?ProductId=" + ProductId + "").Result;
            var readData = res.Content.ReadAsStringAsync().Result;
            var finalData = JsonConvert.DeserializeObject<ProductImageViewModel>(readData);
            return finalData;
        }
        public ProductImageViewModel UpdateProduct(ProductImageViewModel product)
        {
            if (product != null)
            {
                var data = JsonConvert.SerializeObject(product);
                StringContent result = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var res = client.PostAsync("http://localhost:5157/API/UpdateProduct", result).Result;
            }
            return null;
        }

        public bool DeleteProduct(int ProductId)
        {
            if (ProductId != 0)
            {
                var res = client.GetAsync("http://localhost:5157/API/DeleteProduct?ProductId=" + ProductId + "").Result;
            }
            return false;
        }
    }
}
