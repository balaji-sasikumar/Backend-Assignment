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
            var result = await _orderProductRepository.GetOrderDetail(id);
            if (result == null)
                return null;
            
            return result;

        }

        public async Task<IEnumerable<OrderProduct>> GetOrderDetails()
        {
            var result = await _orderProductRepository.GetOrderDetails();
            if (result == null)
                return null;

            return result;
        }

        public async Task<OrderProduct> PlaceOrder(OrderProductViewModel order)
        {
            var productEntity = new OrderProduct()
            {
                Quantity = order.Quantity,
                InvoiceDate = DateTime.UtcNow,
                DeliveredDate = DateTime.UtcNow.AddDays(2),
                CustomerId =Guid.Parse("15154833-940f-4c5c-a507-f3ec0d23c3ee"),
                ProductId=order.ProductId,
            };

            var result= await _orderProductRepository.PlaceOrder(productEntity);

            if (result == null)
                return null;
            return result;
        }

        public async  Task DeleteOrder(Guid id)
        {
            OrderProduct oldOrder = await _orderProductRepository.GetOrderDetail(id);

            await _orderProductRepository.DeleteOrder(oldOrder);
        }
    }
}
