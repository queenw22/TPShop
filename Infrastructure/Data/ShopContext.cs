using System.Reflection;
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
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<CommType> CommTypes { get; set; }
        public DbSet<DesignOption> DesignOptions { get; set; }


        //adding custon configurations builder for service entity 
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());
        }
    }
}