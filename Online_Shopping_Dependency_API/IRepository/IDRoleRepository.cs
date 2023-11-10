
using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Dependency_API.IRepository
{
    public interface IDRoleRepository
    {
        public IEnumerable<RoleViewModel> GetAllRole();
        public bool AddRole(string roleName);
        public bool UpdateRole(RoleViewModel model);
        public bool DeleteRole(int CustomerId);
        public RoleViewModel RoleFindById(int CustomerId);
    }
}
