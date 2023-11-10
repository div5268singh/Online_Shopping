using Online_Shopping_Model.ViewModel;
namespace Online_Shopping_Service.IService
{
    public interface IRoleService
    {
        public IEnumerable<RoleViewModel> GetAllRole();
        public bool AddRole(string roleName);
        public bool UpdateRole(RoleViewModel model);
        public bool DeleteRole(int RoleId);
        public RoleViewModel RoleFindById(int RoleId);
    }
}
