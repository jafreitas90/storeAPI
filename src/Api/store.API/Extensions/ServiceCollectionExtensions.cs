using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using store.DataAccess;
using store.DataAccess.Data;
using store.Domain.Contracts.Repository;
using store.Service.Contracts;
using store.Service.Services;

namespace store.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureInMemoryDatabases(this IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<ApplicationDbContext>(c =>
                c.UseInMemoryDatabase("Catalog"));
        }

        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductItemRepository, ProductItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPackageService, PackageService>();
        }
    }
}
