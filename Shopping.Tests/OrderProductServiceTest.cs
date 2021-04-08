using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping.Models.View_Models;
using Shopping.Services.Interface;
using System;
using System.Threading.Tasks;

namespace Shopping.Tests
{
    [TestClass]
    public class OrderProductServiceTest
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IOrderProductService _orderProductService;
        public OrderProductServiceTest()
        {
            _serviceProvider = new ContainerResolver().ServiceProvider;

            _orderProductService = _serviceProvider.GetRequiredService<IOrderProductService>();
        }

        [TestMethod]
        public async Task GetOrderDetails_Check_ReturnsTrue()
        {
            var order = await _orderProductService.GetOrderDetails();
            Assert.IsTrue(order != null);
        }
        [TestMethod]
        public async Task GetProduct_WrongId_ReturnsTrue()
        {
            var id = Guid.NewGuid();
            var order = await _orderProductService.GetOrderDetail(id);
            Assert.IsFalse(order != null);
        }
        [TestMethod]
        public async Task GetProduct_CorrectId_ReturnsTrue()
        {
            var id = Guid.Parse("81d5018a-ec12-4012-da42-08d8eaba1239");
            var order = await _orderProductService.GetOrderDetail(id);
            Assert.IsTrue(order != null);
        }

        [TestMethod]
        public async Task PlaceOrder_WithoutProductID_ReturnsTrue()
        {
            var order = new OrderProductViewModel();
            await Assert.ThrowsExceptionAsync<Exception>(() => _orderProductService.PlaceOrder(order));
        }
        [TestMethod]
        public async Task PlaceOrder_WithProperInput_ReturnsTrue()
        {
            var order = new OrderProductViewModel()
            {
                ProductId = Guid.Parse("ad21cc19-3b7e-4ba8-fe2c-08d8eab84682"),
                Quantity= 1
            };
            var result = await _orderProductService.PlaceOrder(order);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public async Task DeleteProduct_WithWrongID_ReturnsTrue()
        {
            var id = Guid.NewGuid();
            await Assert.ThrowsExceptionAsync<Exception>(() => _orderProductService.DeleteOrder(id));
        }
        //[TestMethod]
        //public async Task DeleteProduct_WithCorrectID_ReturnsTrue()
        //{
        //    var id = Guid.Parse("81d5018a-ec12-4012-da42-08d8eaba1239");
        //    var result = await _orderProductService.DeleteOrder(id);
        //    Assert.IsTrue(result);
        //}
    }
}
