using Online_Shopping_Domain_API.Models;
using Online_Shopping_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Infrastructure_API.IRepository
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetCatagoryList();
        public Task<Category> AddCatagory(Category catagory);
        public Task<Category> UpdateCatagory(Category catagory);
        public Task<CategoryViewModel> GetCatagoryById(int CatagoryId);
        public bool DeleteCatagory(int CatagoryId);
    }
}
