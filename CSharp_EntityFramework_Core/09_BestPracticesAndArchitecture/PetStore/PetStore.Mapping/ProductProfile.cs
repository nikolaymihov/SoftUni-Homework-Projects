using System;

using AutoMapper;

using PetStore.Models;
using PetStore.Models.Enums;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;

namespace PetStore.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<AddProductInputServiceModel, Product>();

            this.CreateMap<Product, ListAllProductsByProductTypeServiceModel>();

            this.CreateMap<Product, ListAllProductsServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(p => p.ProductType.ToString()));

            this.CreateMap<Product, ListAllProductsByNameServiceModel>()
               .ForMember(x => x.ProductType, y => y.MapFrom(p => p.ProductType.ToString()));

            this.CreateMap<EditProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(p => Enum.Parse(typeof(ProductType), p.ProductType)));

        }
    }
}
