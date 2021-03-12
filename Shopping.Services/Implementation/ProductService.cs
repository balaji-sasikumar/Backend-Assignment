using Shopping.Models.View_Models;
using Shopping.Repositories.EntityModels;
using Shopping.Repositories.Interface;
using Shopping.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Services.Implementation
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {            
            return await _productRepository.GetProducts();
        }
        public async Task<Product> GetProduct(Guid id)
        {
            return await _productRepository.GetProduct(id);
        }
        public async Task<Product> AddProduct(ProductViewModel product)
        {
            var productEntity = new Product() { 
                ProductName=product.ProductName,
                AvailableQuantity=product.AvailableQuantity,
                Date =DateTime.UtcNow,
                Price=product.Price
            };            

            return await _productRepository.AddProduct(productEntity);
        }

        public async Task DeleteProduct(Guid id)
        {
           
            Product product = await _productRepository.GetProduct(id);
            await _productRepository.DeleteProduct(product);
            

        }


        public async Task UpdateProduct(Guid id, ProductViewModel product)
        {
            Product oldProduct= await _productRepository.GetProduct(id);
            oldProduct.ProductName = product.ProductName;
            oldProduct.AvailableQuantity = product.AvailableQuantity;
            oldProduct.Price = product.Price;
            oldProduct.Date = DateTime.UtcNow;
            await _productRepository.UpdateProduct(oldProduct);
        }
    }
}
