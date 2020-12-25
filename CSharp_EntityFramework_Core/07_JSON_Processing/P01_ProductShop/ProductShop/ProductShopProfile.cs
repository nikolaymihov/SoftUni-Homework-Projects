using AutoMapper;
using System.Linq;
using ProductShop.Models;
using ProductShop.DTO.User;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, UserSoldProductsDTO>()
                .ForMember(x => x.BuyerFirstName, y => y.MapFrom(p => p.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName, y => y.MapFrom(p => p.Buyer.LastName));

            this.CreateMap<User, UserWithSoldProductsDTO>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(u => u.ProductsSold.Where(p => p.Buyer != null)));
        }
    }
}
