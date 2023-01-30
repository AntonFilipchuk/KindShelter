using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseConfiguration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(product => product.ProductName).IsRequired();
            builder.Property(product => product.ProductQuantity).IsRequired();
            builder.Property(product => product.ProductPrice).IsRequired();

            builder.HasOne(product => product.ProductType)
                .WithMany(productType => productType.Products)
                .IsRequired();
            builder.HasOne(product => product.Brand)
                .WithMany(brand => brand.Products)
                .IsRequired();
        }
    }
}
