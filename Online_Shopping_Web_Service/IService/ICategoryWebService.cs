using Online_Shopping_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Web_Service.IService
{
    public interface ICategoryWebService
    {
        public List<CategoryViewModel> GetCategoryList();
        public CategoryViewModel AddCategory(CategoryViewModel category);
        public CategoryViewModel UpdateCategory(CategoryViewModel category);
        public CategoryViewModel GetCategoryById(int CategoryId);
        public bool DeleteCategory(int CategoryId);
    }
}
