using Shopping.Repositories.EntityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Repositories.Interface
{
    public interface IOrderProductRepository
    {
        Task<IEnumerable<OrderProduct>> GetOrderDetails();
        Task<OrderProduct> GetOrderDetail(Guid id);
        Task<OrderProduct> PlaceOrder(OrderProduct Order);
        //Task UpdateOrderDetail(OrderProduct Order);
        Task DeleteOrder(OrderProduct Order);
    }
}
