using Microsoft.EntityFrameworkCore;
using Shopping.Repositories.EntityModels;
using Shopping.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingContext _shoppingContext;

        public ProductRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _shoppingContext.Products.ToListAsync();
           
        }
        public async Task<Product> GetProduct(Guid id)
        {
            return await _shoppingContext.Products.FindAsync(id);
        }
        public async Task<Product> AddProduct(Product product)
        {
            _shoppingContext.Products.Add(product);
            await _shoppingContext.SaveChangesAsync();
            
            return product;
        }
        
        public async Task DeleteProduct(Product Product)
        {
            _shoppingContext.Products.Remove(Product);
            await _shoppingContext.SaveChangesAsync();


        }

        public async Task UpdateProduct(Product product)
        {
            await _shoppingContext.SaveChangesAsync();            
        }
    }
}
