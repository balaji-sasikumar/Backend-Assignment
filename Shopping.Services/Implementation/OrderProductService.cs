using Shopping.Models.View_Models;
using Shopping.Repositories.EntityModels;
using Shopping.Repositories.Interface;
using Shopping.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Services.Implementation
{
    public class OrderProductService : IOrderProductService
    {

        private readonly IOrderProductRepository _orderProductRepository;

        public OrderProductService(IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
        }

        public async Task<OrderProduct> GetOrderDetail(Guid id)
        {
            return await _orderProductRepository.GetOrderDetail(id);

        }

        public async Task<IEnumerable<OrderProduct>> GetOrderDetails()
        {
            return await _orderProductRepository.GetOrderDetails();
        }

        public async Task<OrderProduct> PlaceOrder(OrderProductViewModel order)
        {
            var productEntity = new OrderProduct()
            {
                Quantity = order.Quantity,
                DeliveredDate = order.DeliveredDate,
                InvoiceDate = DateTime.UtcNow,
                CustomerId =Guid.Parse("15154833-940f-4c5c-a507-f3ec0d23c3ee"),
                ProductId=order.ProductId,
            };

            var result= await _orderProductRepository.PlaceOrder(productEntity);
            return result;
        }

        //public async Task UpdateOrderDetail(Guid id,OrderProductViewModel order)
        //{
        //    OrderProduct oldOrder = await _orderProductRepository.GetOrderDetail(id);
        //    oldOrder.Quantity = order.Quantity;
        //    oldOrder.DeliveredDate = order.DeliveredDate;
        //    await _orderProductRepository.UpdateOrderDetail(oldOrder);

        //}
        public async  Task DeleteOrder(Guid id)
        {
            OrderProduct oldOrder = await _orderProductRepository.GetOrderDetail(id);

            await _orderProductRepository.DeleteOrder(oldOrder);
        }
    }
}
