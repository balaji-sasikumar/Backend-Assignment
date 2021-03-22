using Shopping.Repositories.EntityModels;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Shopping.Repositories.Interface
{
    public interface IProductRepository
    {
        /// <summary>
        /// This method is for fetching the products data from api 
        /// </summary>
        /// <returns>
        /// List of Products
        /// </returns>
        Task<IEnumerable<Product>> GetProducts();
        /// <summary>
        /// This method is for fetching one particular product data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Product
        /// </returns>
        Task<Product> GetProduct(Guid id);
        /// <summary>
        /// This method is for posting a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>
        /// Added Product
        /// </returns>
        Task<Product> AddProduct(Product product);
        /// <summary>
        /// This method is for updating a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task UpdateProduct(Product product);
        /// <summary>
        /// This method is for deleting a product
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        Task DeleteProduct(Product Product);
    }
}
