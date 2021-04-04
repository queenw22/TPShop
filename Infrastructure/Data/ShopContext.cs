using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Service> Services { get; set;}
    }
}