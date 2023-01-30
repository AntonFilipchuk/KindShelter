using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseConfiguration
{
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.Property(breed => breed.BreedName).IsRequired();
            builder
                .HasOne(breed => breed.Animal)
                .WithMany(animal => animal.Breeds)
                .IsRequired();
        }
    }
}
