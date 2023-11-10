using Online_Shopping_Dependency_API.IRepository;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Dependency_API.Repository
{
    public class DCatagoryRepository : IDCatagoryRepository
    {
        private readonly ICatagoryRepository _repository;
        public DCatagoryRepository(ICatagoryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CatagoryViewModel> GetAllCatagory()
        {
            var catagory = _repository.GetAllCatagory();
            return catagory;
        }
        public bool AddCatagory(CatagoryViewModel model)
        {
            var catagory = _repository.AddCatagory(model);
            return catagory;
        }
        public bool UpdateCatagory(CatagoryViewModel model)
        {
            var catagory = _repository.UpdateCatagory(model);
            return catagory;
        }

        public bool DeleteCatagory(int Id)
        {
            var customer = _repository.DeleteCatagory(Id);
            return customer;
        }

        public CatagoryViewModel FindCatagoryById(int CatagoryId)
        {
            return _repository.FindCatagoryById(CatagoryId);
        }
    }
}
