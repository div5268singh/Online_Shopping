using Microsoft.AspNetCore.Mvc;
using Online_Shopping_Model.ViewModel;
using Online_Shopping_Web_Service.IService;

namespace Online_Shopping_Web.Controllers
{
    public class CategoryController : Controller
    {
		private readonly ICategoryWebService _service;
		public CategoryController(ICategoryWebService service)
		{
			_service = service;
		}
		public IActionResult GetCategoryList()
		{
			return View();
		}
		[HttpGet]
		public JsonResult CategoryList()
		{
			var category = _service.GetCategoryList();
			return new JsonResult(category);
		}
		public JsonResult GetCategoryById(int CategoryId)
		{
			var category = _service.GetCategoryById(CategoryId);
			return new JsonResult(category);
		}
		public JsonResult AddCategory(CategoryViewModel category)
		{
			var data = _service.AddCategory(category);
			return new JsonResult(data);
		}
		public JsonResult UpdateCategory(CategoryViewModel category)
		{
			var data = _service.UpdateCategory(category);
			return new JsonResult(data);
		}
		[HttpGet]
		public JsonResult DeleteCategory(int CategoryId)
		{
			var data = _service.DeleteCategory(CategoryId);
			return new JsonResult(data);
		}
	}
}
