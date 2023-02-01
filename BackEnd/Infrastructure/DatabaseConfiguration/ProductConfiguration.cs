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

            //For SQlite ro correctly represent decimal values
            //https://learn.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
            builder.Property(product => product.ProductPrice).HasConversion<double>().IsRequired();

            builder
                .HasOne(product => product.ProductType)
                .WithMany(productType => productType.Products)
                .IsRequired();
            builder.HasOne(product => product.Brand).WithMany(brand => brand.Products).IsRequired();

            //Configure many-to-many relationship
            //Important: 1st to configure animal, 2nd - product
            //https://learn.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
            builder
                .HasMany(p => p.Animals)
                .WithMany(a => a.Products)
                .UsingEntity<AnimalProduct>(
                    j =>
                        j.HasOne(animalProduct => animalProduct.Animal)
                            .WithMany(animal => animal.AnimalProducts)
                            .HasForeignKey(animalProduct => animalProduct.AnimalId),
                    j =>
                        j.HasOne(animalProduct => animalProduct.Product)
                            .WithMany(product => product.AnimalProducts)
                            .HasForeignKey(animalProduct => animalProduct.ProductId),
                    j =>
                    {
                        j.HasKey(t => new { t.AnimalId, t.ProductId });
                    }
                );
        }
    }
}
