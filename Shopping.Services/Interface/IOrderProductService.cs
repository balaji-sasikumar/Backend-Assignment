using Shopping.Repositories.EntityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopping.Models.View_Models;


namespace Shopping.Services.Interface
{
    public interface IOrderProductService
    {
        /// <summary>
        /// This method is for fetching a Order Details
        /// </summary>
        /// <returns>List of Orders</returns>
        Task<IEnumerable<OrderProduct>> GetOrderDetails();
        /// <summary>
        /// This method is for fetching a particular Order Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Order Detail</returns>
        Task<OrderProduct> GetOrderDetail(Guid id);
        /// <summary>
        /// This method is for posting a Order
        /// </summary>
        /// <param name="Order"></param>
        /// <returns>Added Order</returns>
        Task<OrderProduct> PlaceOrder(OrderProductViewModel Order);
        /// <summary>
        /// This method is for Removing a particular Order Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteOrder(Guid id);
    }
}
