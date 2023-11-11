using Microsoft.AspNetCore.Mvc;
using Online_Shopping_Model.ViewModel;
using Online_Shopping_Web_Service.IService;

namespace Online_Shopping_Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IProductWebService _service;
        public ProductController(IProductWebService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

		public IActionResult GetProducts()
		{
			var data = _service.GetProductList();
			return View(data);
		}
		public ActionResult Index()
        {
            return View();
        }
		public ActionResult GetProductList()
		{
			return View();
		}
		public JsonResult GetProduct()
        {
            var data = _service.GetProductList();
            return new JsonResult(data);
        }
        public IActionResult AddProduct(ProductImageViewModel product)
        {
            string uniqueFileName = "";
            if (product.PhotoPath != null)
            {
                string uploadFile = Path.Combine(_environment.WebRootPath, "Images/Products");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.PhotoPath.FileName;
                var filePath = Path.Combine(uploadFile, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.PhotoPath.CopyTo(fileStream);
                }
            }
            product.Photo = uniqueFileName;

            var data = _service.AddProduct(product);
            return new JsonResult(data);
        }


        public IActionResult UpdateProduct(ProductImageViewModel product)
        {
            string uniqueFileName = "";
            if (product.PhotoPath != null)
            {
                string uploadFile = Path.Combine(_environment.WebRootPath, "Images/Products");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + product.PhotoPath.FileName;
                var filePath = Path.Combine(uploadFile, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.PhotoPath.CopyTo(fileStream);
                }
            }
            product.Photo = uniqueFileName;

            var data = _service.UpdateProduct(product);
            return new JsonResult(data);
        }

        [HttpGet]
        public JsonResult GetProductById(int ProductId)
        {
            var data = _service.GetProductById(ProductId);
            return new JsonResult(data);
        }
        [HttpGet]
        public JsonResult DeleteProduct(int ProductId)
        {
            var data = _service.DeleteProduct(ProductId);
            return new JsonResult(data);
        }
        public IActionResult ProductDetail(int ProductId)
        {
			var data = _service.GetProductById(ProductId);
			return View(data);
        }
    }
}
