using System;
using Shopping.Repositories.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Models.View_Models;

namespace Shopping.Services.Interface
{
    public interface IProductService
    {
        /// <summary>
        /// This method is for fetching the products data from api
        /// </summary>
        /// <returns>List of Products</returns>
        Task<IEnumerable<Product>> GetProducts();
        /// <summary>
        /// This method is for fetching one particular product data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Product</returns>
        Task<Product> GetProduct(Guid id);
        /// <summary>
        /// This method is for posting a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Added Product</returns>
        Task<Product> AddProduct(ProductViewModel product);
        /// <summary>
        /// This method is for updating a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns>True if Updated</returns>
        Task<bool> UpdateProduct(Guid id, ProductViewModel product);
        /// <summary>
        /// This method is for removing a product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if Deleted</returns>
        Task<bool> DeleteProduct(Guid id);
    }
}
