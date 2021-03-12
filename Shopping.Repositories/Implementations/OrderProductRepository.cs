using Microsoft.EntityFrameworkCore;
using Shopping.Repositories.EntityModels;
using Shopping.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Repositories.Implementations
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly ShoppingContext _shoppingContext;

        public OrderProductRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }
        public async Task<IEnumerable<OrderProduct>> GetOrderDetails()
        {
            var result = await _shoppingContext.OrderProducts.Include(x => x.Product).ToListAsync();
            return result;
        }
        public async Task<OrderProduct> GetOrderDetail(Guid id)
        {
            return await _shoppingContext.OrderProducts.FindAsync(id);

        }
        public async Task<OrderProduct> PlaceOrder(OrderProduct Order)
        {
            var result =_shoppingContext.OrderProducts.Add(Order);
            await _shoppingContext.SaveChangesAsync();
            return Order;
        }

        public async Task DeleteOrder(OrderProduct Order)
        {
            _shoppingContext.OrderProducts.Remove(Order);
            await _shoppingContext.SaveChangesAsync();           
        }
        
    }
}
