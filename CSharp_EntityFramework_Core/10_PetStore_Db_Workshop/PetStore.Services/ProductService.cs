using System;
using System.Linq;
using System.Collections.Generic;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Data;
using PetStore.Models;
using PetStore.Common;
using PetStore.Models.Enums;
using PetStore.Services.Contracts;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;

namespace PetStore.Services
{
    public class ProductService : IProductService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            try
            {
                Product product = this.mapper.Map<Product>(model);

                this.dbContext.Products.Add(product);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }
        }

        public void EditProduct(string id, EditProductInputServiceModel model)
        {
            try
            {
                Product product = this.mapper.Map<Product>(model);

                Product productToUpdate = this.dbContext.Products.Find(id);

                if (productToUpdate == null)
                {
                    throw new ArgumentException(ExceptionMessages.ProductNotFound);
                }

                productToUpdate.Name = product.Name;
                productToUpdate.ProductType = product.ProductType;
                productToUpdate.Price = product.Price;

                this.dbContext.SaveChanges();
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }
        }

        public ProductDetailsServiceModel GetById(string id)
        {
            Product product = this.dbContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            ProductDetailsServiceModel serviceModel = this.mapper.Map<ProductDetailsServiceModel>(product);

            return serviceModel;
        }

        public ICollection<ListAllProductsServiceModel> GetAll()
        {
            var products = this.dbContext.Products
                                         .ProjectTo<ListAllProductsServiceModel>(this.mapper.ConfigurationProvider)
                                         .ToList();

            return products;
        }

        public ICollection<ListAllProductsByNameServiceModel> ListAllByName(string searchStr, bool caseSensitive)
        {
            ICollection<ListAllProductsByNameServiceModel> products;

            if (caseSensitive)
            {
                products = this.dbContext.Products
                                         .Where(p => p.Name.Contains(searchStr))
                                         .ProjectTo<ListAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
                                         .ToList();
            }
            else
            {
                products = this.dbContext.Products
                                         .Where(p => p.Name.ToLower().Contains(searchStr.ToLower()))
                                         .ProjectTo<ListAllProductsByNameServiceModel>(this.mapper.ConfigurationProvider)
                                         .ToList();
            }

            return products;
        }

        public ICollection<ListAllProductsByProductTypeServiceModel> ListAllByProductType(string type)
        {
            ProductType productType;

            bool hasParsed = Enum.TryParse(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            var productsServiceModels = this.dbContext.Products
                                                      .Where(p => p.ProductType == productType)
                                                      .ProjectTo<ListAllProductsByProductTypeServiceModel>(this.mapper.ConfigurationProvider)
                                                      .ToList();

            return productsServiceModels;
        }

        public bool RemoveById(string id)
        {
            Product productToRemove = this.dbContext.Products.Find(id);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            return rowsAffected == 1;
        }

        public bool RemoveByName(string name)
        {
            Product productToRemove = this.dbContext.Products.FirstOrDefault(p => p.Name == name);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            return rowsAffected == 1;
        }
    }
}
