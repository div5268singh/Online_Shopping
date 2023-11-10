using Online_Shopping_Dependency_API.IRepository;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Dependency_API.Repository
{
     
    public class DRoleRepository : IDRoleRepository
    {
        private readonly IRoleRepository _repository;
        public DRoleRepository(IRoleRepository repository) 
        { 
          _repository = repository;
        }
        public IEnumerable<RoleViewModel> GetAllRole()
        {
            return _repository.GetAllRole();
        }
        public bool AddRole(string roleName)
        {
            return _repository.AddRole(roleName);
        }

        public bool UpdateRole(RoleViewModel model)
        {
            return _repository.UpdateRole(model);
        }

        public bool DeleteRole(int RoleId)
        {
            return _repository.DeleteRole(RoleId);
        }

        public RoleViewModel RoleFindById(int RoleId)
        {
            return _repository.RoleFindById(RoleId);
        }
    }
}
