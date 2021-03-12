using Shopping.Repositories.EntityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Models.View_Models;


namespace Shopping.Services.Interface
{
    public interface IOrderProductService
    {

        Task<IEnumerable<OrderProduct>> GetOrderDetails();
        Task<OrderProduct> GetOrderDetail(Guid id);
        Task<OrderProduct> PlaceOrder(OrderProductViewModel Order);
        //Task UpdateOrderDetail(Guid id,OrderProductViewModel Order);
        Task DeleteOrder(Guid id);
    }
}
