using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using store.Domain.Entities;

namespace store.DataAccess
{
    public class ApplicationContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!await context.ProductType.AnyAsync())
            {
                await context.ProductType.AddRangeAsync(
                    GetPreconfiguredProductTypes());

                await context.SaveChangesAsync();
            }

            if (!await context.ProductItem.AnyAsync())
            {
                var productTypes = await context.ProductType.ToListAsync();
                await context.ProductItem.AddRangeAsync(
                     GetPreconfiguredProductItems(productTypes));

                await context.SaveChangesAsync();
            }
        }

        static IEnumerable<ProductType> GetPreconfiguredProductTypes()
        {
            return new List<ProductType>()
            {
                new ProductType("photoBook", 19, 1),
                new ProductType("calendar", 10, 1),
                new ProductType("canvas", 16, 1),
                new ProductType("cards", 4.7f, 1),
                new ProductType("mug", 94, 4)
            };
        }

        static IEnumerable<ProductItem> GetPreconfiguredProductItems(IEnumerable<ProductType> productTypes)
        {
            return new List<ProductItem>()
            {
                new ProductItem(productTypes.FirstOrDefault(x=>x.Type == "mug").Id, 123),
                new ProductItem(productTypes.FirstOrDefault(x=>x.Type == "mug").Id, 124),
                new ProductItem(productTypes.FirstOrDefault(x=>x.Type == "mug").Id, 125),
                new ProductItem(productTypes.FirstOrDefault(x=>x.Type == "cards").Id, 126),
                new ProductItem(productTypes.FirstOrDefault(x=>x.Type == "canvas").Id, 127),
                new ProductItem(productTypes.FirstOrDefault(x=>x.Type == "calendar").Id, 128),
                new ProductItem(productTypes.FirstOrDefault(x=>x.Type == "photoBook").Id, 129)
            };
        }
    }
}
