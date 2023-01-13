using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites.Breeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseConfiguration
{
    public class BreedsCollectionConfiguration : IEntityTypeConfiguration<Breeds>
    {
        public void Configure(EntityTypeBuilder<Breeds> builder)
        {
            builder.Property(breed => breed.BreedCollectionName).IsRequired();
            builder
                .HasMany(breed => breed.BreedTypesCollection)
                .WithOne(breedType => breedType.BreedsCollection)
                .HasForeignKey(breedType => breedType.BreedsCollectionId);
        }
    }
}
