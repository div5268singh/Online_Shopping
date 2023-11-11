using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Online_Shopping_Model.ViewModel;
using Online_Shopping_Web_Service.IService;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Online_Shopping_Web.Controllers
{
	//[Route("api/[controller]")]
	public class CustomerController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IWebHostEnvironment _environment;
        private readonly ICustomerWebService _service;

		HttpClient client = new HttpClient();
		public CustomerController(IHttpClientFactory httpClientFactory, ICustomerWebService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment= environment;
			_httpClientFactory = httpClientFactory;
        }
        public IActionResult GetCustomerList()
        {
            return View();
        }
        [HttpGet]
        public JsonResult CustomerList()
        {
            var customer = _service.GetAllCustomer();
            return new JsonResult(customer);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> AddCustomer(CustomerViewModel customer, IFormFile PhotoPath)
		{
			using (var client = new HttpClient())
			{
				using (var content = new MultipartFormDataContent())
				{
					// Serialize the CustomerViewModel as JSON and add it to the request
					var customerJson = JsonConvert.SerializeObject(customer);
					content.Add(new StringContent(customerJson), "customer");

					if (PhotoPath != null && PhotoPath.Length > 0)
					{
						// Add the image file to the request
						content.Add(new StreamContent(PhotoPath.OpenReadStream()), "PhotoPath", PhotoPath.FileName);
					}

					var response = await client.PostAsync("http://localhost:5157/API/UploadImage", content);

					if (response.IsSuccessStatusCode)
					{
						return Ok("Customer data and image uploaded to API successfully.");
					}
				}
			}

			return BadRequest("Failed to upload customer data and image to API.");
		}



		[HttpPost]
		//public async Task<IActionResult> AddCustomer(CustomerViewModel customer, IFormFile PhotoPath)
		public async Task<IActionResult> ImageCustomer(CustomerViewModel customer, IFormFile PhotoPath)
		{

			if (PhotoPath != null && PhotoPath.Length > 0)
			{
				using (var client = new HttpClient())
				{
					using (var content = new MultipartFormDataContent())
					{
						content.Add(new StreamContent(PhotoPath.OpenReadStream()), "PhotoPath", PhotoPath.FileName);
						var response = await client.PostAsync("http://localhost:5157/API/UploadImage", content);
					}
				}
				return Ok("Image uploaded to API successfully.");
			}
			else
			{
				return BadRequest("Image upload to API failed.");
			}
		}

		//     [HttpPost]
		//     public JsonResult AddCustomer(CustomerViewModel customer, IFormFile PhotoPath)
		//     {
		//         string uniqueFileName = "";
		//if (PhotoPath != null)
		//{
		//	string fileName = Guid.NewGuid().ToString() + Path.GetExtension(PhotoPath.FileName);



		//	//string uploadFile = Path.Combine(_environment.WebRootPath, "Images/Customers");
		//	//uniqueFileName = Guid.NewGuid().ToString() + "_" + PhotoPath.FileName;
		//	//var filePath = Path.Combine(uploadFile, uniqueFileName);
		//	//using (var fileStream = new FileStream(filePath, FileMode.Create))
		//	//{
		//	//	PhotoPath.CopyTo(fileStream);
		//	//}
		//	customer.Photo = uniqueFileName;
		//}
		//var data = JsonConvert.SerializeObject(customer);
		//StringContent result = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
		//var res = client.PostAsync("http://localhost:5157/API/AddCustumer", result).Result;
		//return new JsonResult(res);
		//     }
		//public void UploadFile(IFormFile file,  a)


		// How to pass IFormFile image path from web controller to API controller solution asp.net core 6

		public JsonResult UpdateCustomer(CustomerViewModel customer, IFormFile PhotoPath)
        {
			string uniqueFileName = "";
			if (PhotoPath != null)
			{
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(PhotoPath.FileName);

				
				//string uploadFile = Path.Combine(_environment.WebRootPath, "Images/Customers");
				//uniqueFileName = Guid.NewGuid().ToString() + "_" + PhotoPath.FileName;
				//var filePath = Path.Combine(uploadFile, uniqueFileName);
				//using (var fileStream = new FileStream(filePath, FileMode.Create))
				//{
				//	PhotoPath.CopyTo(fileStream);
				//}
				customer.Photo = uniqueFileName;
			}
			var data = JsonConvert.SerializeObject(customer);
			StringContent result = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
			var res = client.PostAsync("http://localhost:5157/API/UpdateCustomer", result).Result;
			return new JsonResult(res);
		}

        [HttpGet]
        public JsonResult GetCustomerById(int CustomerId)
        {
            var data = _service.GetCustomerById(CustomerId);
            return new JsonResult(data);
        }
        [HttpGet]
        public JsonResult DeleteCustomer(int CustomerId)
        {
            var data = _service.DeleteCustomer(CustomerId);
            return new JsonResult(data);
        }
    }
}
