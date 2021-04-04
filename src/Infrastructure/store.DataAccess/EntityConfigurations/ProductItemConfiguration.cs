using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using store.Domain.Entities;

namespace store.DataAccess.EntityConfigurations
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(ProductItem.ProductType));

            // to access the OrderItem collection property through its field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
