using Online_Shopping_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Infrastructure_API.IRepository
{
    public interface IAdminRepository
    {
        public IEnumerable<AdminViewModel> GetAllAdmin();
        public bool AddAdmin(AdminViewModel admin);
        public bool UpdateAdmin(AdminViewModel admin);
        public CategoryViewModel GetEdit(AdminViewModel admin);
        public bool DeleteAdmin(int AdminId);
        public CategoryViewModel AdminFindById(int AdminId);
    }
}
