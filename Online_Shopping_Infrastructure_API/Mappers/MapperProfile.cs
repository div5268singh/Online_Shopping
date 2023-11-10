using AutoMapper;
using Online_Shopping_Domain_API.Models;
using Online_Shopping_Model.ViewModel;

namespace Online_Shopping_Infrastructure_API.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<User, UserViewModel>()
            //.ForMember(dest =>
            //dest.UserId,
            //opt => opt.MapFrom(src => src.UserId))
            //.ForMember(dest =>
            //dest.RoleId,
            //opt => opt.MapFrom(src => src.RoleId))
            //.ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Customer, LoginViewModel>().ReverseMap();
            
            CreateMap<Order, OrderViewModel>().ReverseMap();
            
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Role,RoleViewModel>().ReverseMap();
            CreateMap<Seller,SellerViewModel>().ReverseMap();
            
        }
    }
}
