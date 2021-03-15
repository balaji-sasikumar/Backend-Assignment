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
            var result = await _shoppingContext.OrderProducts.Include(obj => obj.Product).ToListAsync();
            if (result == null)
                return null;
            return result;
        }
        public async Task<OrderProduct> GetOrderDetail(Guid id)
        {
            var result= await _shoppingContext.OrderProducts.FindAsync(id);
            if (result == null)
                return null;
            
            return result;

        }
        public async Task<OrderProduct> PlaceOrder(OrderProduct Order)
        {
            var product = await _shoppingContext.Products.FindAsync(Order.ProductId);
            if (Order.Quantity<=product.AvailableQuantity)
            {
                var result = _shoppingContext.OrderProducts.Add(Order);
                product.AvailableQuantity -= Order.Quantity ;
                await _shoppingContext.SaveChangesAsync();
                return Order;

            }
            return null;

        }

        public async Task DeleteOrder(OrderProduct Order)
        {
            _shoppingContext.OrderProducts.Remove(Order);
            await _shoppingContext.SaveChangesAsync();           
        }
        
    }
}
