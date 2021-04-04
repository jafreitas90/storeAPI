using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using store.DataAccess;

namespace store.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void Seed(this IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder
                .ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                ApplicationContextSeed.SeedAsync(context).GetAwaiter().GetResult();
            }
        }
    }
}
