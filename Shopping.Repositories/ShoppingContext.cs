using Microsoft.EntityFrameworkCore;
using Shopping.Repositories.EntityModels;


namespace Shopping.Repositories
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }



    }
}
