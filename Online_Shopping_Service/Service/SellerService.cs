using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;
using Online_Shopping_Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Service.Service
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _repository;

        public SellerService(ISellerRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<SellerViewModel>> GetlSellerList()
        {
            var data = await _repository.GetlSellerList();
            return data;
        }

        public Task<SellerViewModel> AddSeller(SellerViewModel model)
        {
            var data = _repository.AddSeller(model);
            return data;
        }
        public Task<SellerViewModel> UpdateSeller(SellerViewModel model)
        {
            var data = _repository.UpdateSeller(model);
            return data;
        }

        public async Task<SellerViewModel> GetSellerById(int SellerId)
        {
            var data = await _repository.GetSellerById(SellerId);
            var seller = new SellerViewModel
            {
                SellerId = data.SellerId,
                ProductId = data.ProductId,
                SellerName = data.SellerName,
                Phone = data.Phone,
            };
            return seller;
        }

        public bool DeleteSeller(int SellerId)
        {
            return _repository.DeleteSeller(SellerId);
        }
    }
}
