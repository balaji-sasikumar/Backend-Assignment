using System;
using Shopping.Repositories.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Models.View_Models;

namespace Shopping.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(Guid id);
        Task<Product> AddProduct(ProductViewModel product);
        Task UpdateProduct(Guid id, ProductViewModel product);
        Task DeleteProduct(Guid id);
    }
}
