using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites.Breeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseConfiguration
{
    public class BreedTypesConfiguration : IEntityTypeConfiguration<BreedType>
    {
        public void Configure(EntityTypeBuilder<BreedType> builder)
        {
            builder.Property(breedType => breedType.BreedName).IsRequired();
            builder
                .HasMany(breedType => breedType.Animals)
                .WithOne(animal => animal.BreedType)
                .HasForeignKey(animal => animal.BreedTypeId);
        }
    }
}
