using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites.Breeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseConfiguration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(animal => animal.AnimalName).IsRequired();
            builder
                .HasMany(animal => animal.Breeds)
                .WithOne(breed => breed.Animal)
                .HasForeignKey(breed => breed.AnimalId);
        }
    }
}
