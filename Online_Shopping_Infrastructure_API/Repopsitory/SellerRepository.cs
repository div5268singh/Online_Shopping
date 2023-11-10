using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online_Shopping_Domain_API.Data;
using Online_Shopping_Domain_API.Models;
using Online_Shopping_Infrastructure_API.IRepository;
using Online_Shopping_Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Infrastructure_API.Repopsitory
{
    public class SellerRepository : ISellerRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public SellerRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<SellerViewModel>> GetlSellerList()
        {
            var seller = await _context.Sellers.ToListAsync();
            var data = _mapper.Map<List<SellerViewModel>>(seller);
            return data;
        }
        public Task<SellerViewModel> AddSeller(SellerViewModel model)
        {
            if (model != null)
            {
                _context.Sellers.Add(_mapper.Map<Seller>(model));
                _context.SaveChanges();
            }
            return null;
        }
        public Task<SellerViewModel> UpdateSeller(SellerViewModel model)
        {
            if (model != null)
            {
                _context.Sellers.Update(_mapper.Map<Seller>(model));
                _context.SaveChanges();
            }
            return null;
        }
        public async Task<SellerViewModel> GetSellerById(int SellerId)
        {
            if (SellerId != 0)
            {
                var product = await _context.Sellers.Where(x => x.SellerId == SellerId).FirstOrDefaultAsync();
                var data = _mapper.Map<SellerViewModel>(product);
                return data;
            }
            return null;
        }

        public bool DeleteSeller(int SellerId)
        {
            var catagory = _context.Sellers.Where(x => x.SellerId == SellerId).FirstOrDefault();
            var data = _mapper.Map<Seller>(catagory);
            if (data != null)
            {
                _context.Sellers.Remove(data);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
