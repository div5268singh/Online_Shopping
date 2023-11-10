using Online_Shopping_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Infrastructure_API.IRepository
{
    public interface ISellerRepository
    {
        public Task<List<SellerViewModel>> GetlSellerList();
        public Task<SellerViewModel> AddSeller(SellerViewModel seller);
        public Task<SellerViewModel> UpdateSeller(SellerViewModel seller);
        public Task<SellerViewModel> GetSellerById(int SellerId);
        public bool DeleteSeller(int SellerId);
    }
}
