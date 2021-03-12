using Shopping.Repositories.EntityModels;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Shopping.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(Guid id);
        Task<Product> AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product Product);
    }
}
