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
            if(product.ProductName == null) {
                throw new Exception("Product Name is Empty");
            }
            var productEntity = new Product() { 
                ProductName=product.ProductName,
                AvailableQuantity=product.AvailableQuantity,
                Date =DateTime.UtcNow,
                Price=product.Price
            };

            return await _productRepository.AddProduct(productEntity);
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
           
            Product product = await _productRepository.GetProduct(id);
            if (product == null)
            {
                throw new Exception("Invalid Product ID");
            }
            await _productRepository.DeleteProduct(product);
            return true;
            
        }


        public async Task<bool> UpdateProduct(Guid id, ProductViewModel product)
        {
            if (product.ProductName == null)
            {
                throw new Exception("Product Name is Empty");
            }
            Product oldProduct= await _productRepository.GetProduct(id);
            if (oldProduct == null) throw new Exception("Invalid Product ID");      
            oldProduct.ProductName = product.ProductName;
            oldProduct.AvailableQuantity = product.AvailableQuantity;
            oldProduct.Price = product.Price;
            oldProduct.Date = DateTime.UtcNow;

            await _productRepository.UpdateProduct(oldProduct);
            return true;
        }
    }
}
