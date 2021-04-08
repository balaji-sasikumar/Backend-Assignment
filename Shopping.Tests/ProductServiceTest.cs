using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping.Models.View_Models;
using Shopping.Services.Interface;
using System;
using System.Threading.Tasks;

namespace Shopping.Tests
{
    [TestClass]
    public class ProductServiceTest
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IProductService _productService;
        public ProductServiceTest()
        {
            _serviceProvider = new ContainerResolver().ServiceProvider;

            _productService = _serviceProvider.GetRequiredService<IProductService>();
        }
        [TestMethod]
        public async Task AddProduct_WithoutName_ReturnsTrue()
        {
            var product = new ProductViewModel()
            {
                AvailableQuantity = 10,
                Price=1000
            
            };
            await Assert.ThrowsExceptionAsync<Exception>(() => _productService.AddProduct(product));

        }
        [TestMethod]
        public async Task AddProduct_WithProperInput_ReturnsTrue()
        {
            var product = new ProductViewModel()
            {
                AvailableQuantity = 10,
                Price = 1000,
                ProductName = "Samsung i2"

            };
            var result = await _productService.AddProduct(product);
            Assert.IsNotNull(result.ProductId);

        }
        [TestMethod]
        public async Task GetProducts_Check_ReturnsTrue()
        {
            var product = await _productService.GetProducts();
            Assert.IsNotNull(product);
        }
        [TestMethod]
        public async Task GetProduct_WithWrongId_ReturnsTrue()
        {
            var id = Guid.NewGuid();
            var product = await _productService.GetProduct(id);
            Assert.IsNull(product);

        }
        [TestMethod]
        public async Task GetProduct_WithCorrectId_ReturnsTrue()
        {
            var id = Guid.Parse("7cf73bd5-ba49-4944-9a44-08d8eaac32fc");
            var product = await _productService.GetProduct(id);
            Assert.IsNotNull(product);

        }
        [TestMethod]
        public async Task DeleteProduct_WithWrongId_ReturnsTrue()
        {
            var id = Guid.NewGuid();
            await Assert.ThrowsExceptionAsync<Exception>(() => _productService.DeleteProduct(id));

        }
        //[TestMethod]
        //public async Task DeleteProduct_WithCorrectId_ReturnsTrue()
        //{
        //    var id = Guid.Parse("7cf73bd5-ba49-4944-9a44-08d8eaac32fc");
        //    var result = await _productService.DeleteProduct(id);
        //    Assert.IsTrue(result);

        //}
        [TestMethod]
        public async Task UpdateProduct_WithWrongId_ReturnsTrue()
        {
            var id = Guid.NewGuid();
            var product = new ProductViewModel()
            {
                AvailableQuantity = 10,
                Price = 1000,
                ProductName = "Samsung i2"

            };
            await Assert.ThrowsExceptionAsync<Exception>(() => _productService.UpdateProduct(id,product));

        }
        [TestMethod]
        public async Task UpdateProduct_WithoutName_ReturnsTrue()
        {
            var id = Guid.NewGuid();
            var product = new ProductViewModel()
            {
                AvailableQuantity = 10,
                Price = 1000,

            };
            await Assert.ThrowsExceptionAsync<Exception>(() => _productService.UpdateProduct(id, product));

        }
        //[TestMethod]
        //public async Task UpdateProduct_WithCorrectId_ReturnsTrue()
        //{
        //    var id = Guid.Parse("a8db4b52-d79a-48c9-fe2f-08d8eab84682");
        //    var product = new ProductViewModel()
        //    {
        //        AvailableQuantity = 10,
        //        Price = 1000,
        //        ProductName = "Samsung i2"

        //    };
        //    var result = await _productService.UpdateProduct(id, product);
        //    Assert.IsTrue(result);

        //}
    }
}
