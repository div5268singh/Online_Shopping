using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Dependency_API.IRepository
{
    public interface IDCatagoryRepository
    {
        public IEnumerable<CatagoryViewModel> GetAllCatagory();
        public bool AddCatagory(CatagoryViewModel model);
        public bool UpdateCatagory(CatagoryViewModel model);
        public bool DeleteCatagory(int CatagoryId);
        public CatagoryViewModel FindCatagoryById(int CatagoryId);
    }
}
