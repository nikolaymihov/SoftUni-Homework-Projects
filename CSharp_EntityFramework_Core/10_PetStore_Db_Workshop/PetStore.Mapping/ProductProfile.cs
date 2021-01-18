using System;

using AutoMapper;

using PetStore.Models;
using PetStore.Models.Enums;
using PetStore.ViewModels.Product;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.ViewModels.Product.InputModels;
using PetStore.ViewModels.Product.OutputModels;

namespace PetStore.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<AddProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(p => (ProductType) p.ProductType));

            this.CreateMap<Product, ProductDetailsServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom(p => p.ProductType.ToString()));

            this.CreateMap<Product, ListAllProductsByProductTypeServiceModel>();

            this.CreateMap<Product, ListAllProductsServiceModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(p => p.Id))
                .ForMember(x => x.ProductType, y => y.MapFrom(p => p.ProductType.ToString()));

            this.CreateMap<Product, ListAllProductsByNameServiceModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(p => p.Id))
                .ForMember(x => x.ProductType, y => y.MapFrom(p => p.ProductType.ToString()));

            this.CreateMap<EditProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom(p => Enum.Parse(typeof(ProductType), p.ProductType)));

            this.CreateMap<ListAllProductsServiceModel, ListAllProductsViewModel>();

            this.CreateMap<CreateProductInputModel, AddProductInputServiceModel>();

            this.CreateMap<ProductDetailsServiceModel, ProductDetailsViewModel>()
                .ForMember(x => x.Price, y => y.MapFrom(p => p.Price.ToString("f2")));

            this.CreateMap<ListAllProductsByNameServiceModel, ListAllProductsViewModel>();
        }
    }
}
