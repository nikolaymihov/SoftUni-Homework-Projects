using System.Collections.Generic;

using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;

namespace PetStore.Services.Contracts
{
    public interface IProductService
    {
        void AddProduct(AddProductInputServiceModel model);
        
        void EditProduct(string id, EditProductInputServiceModel model);

        ICollection<ListAllProductsServiceModel> GetAll();

        ICollection<ListAllProductsByNameServiceModel> ListAllByName(string name, bool caseSensitive);
       
        ICollection<ListAllProductsByProductTypeServiceModel> ListAllByProductType(string type);

        bool RemoveById(string id);

        bool RemoveByName(string name);
    }
}
