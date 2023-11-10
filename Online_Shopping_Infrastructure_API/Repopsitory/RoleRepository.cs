using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online_Shopping_Domain_API.Data;
using Online_Shopping_Domain_API.Models;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Infrastructure_API.Repopsitory
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public RoleRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<RoleViewModel> GetAllRole()
        {
            return _mapper.Map<IEnumerable<RoleViewModel>>(_context.Roles.ToList());
        }
        public bool AddRole(string? roleName)
        {
            if(roleName != null)
            {
                Role role = new Role();
                role.RoleName= roleName;
                _context.Roles.Add(role);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public bool UpdateRole(RoleViewModel model)
        {
            if (model.RoleId > 0)
            {
                _context.Roles.Update(_mapper.Map<Role>(model));
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteRole(int RoleId)
        {
            var role = _context.Roles.Where(x => x.RoleId == RoleId).FirstOrDefault();
            var data = _mapper.Map<Role>(role);
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public RoleViewModel RoleFindById(int RoleId)
        {
            return _mapper.Map<RoleViewModel>(_context.Roles.Where(a => a.RoleId == RoleId).FirstOrDefault());
        }
    }
}
