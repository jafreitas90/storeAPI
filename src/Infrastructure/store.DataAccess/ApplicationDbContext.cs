using System.Reflection;
using Microsoft.EntityFrameworkCore;
using store.Domain.Entities;
using store.Domain.Entities.OrderAggregate;

namespace store.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "Tenant";
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductItem> ProductItem { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}