
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;
using Online_Shopping_Service.IService;

namespace Online_Shopping_Service.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleService;
        public RoleService(IRoleRepository roleService)
        {
            _roleService = roleService;
        }
        public IEnumerable<RoleViewModel> GetAllRole()
        {
            return _roleService.GetAllRole();
        }
        public bool AddRole(string roleName)
        {
            return _roleService.AddRole(roleName);
        }

        public bool UpdateRole(RoleViewModel model)
        {
            return _roleService.UpdateRole(model);
        }

        public bool DeleteRole(int RoleId)
        {
            return _roleService.DeleteRole(RoleId);
        }

        public RoleViewModel RoleFindById(int RoleId)
        {
            return _roleService.RoleFindById(RoleId);
        }
    }
}
