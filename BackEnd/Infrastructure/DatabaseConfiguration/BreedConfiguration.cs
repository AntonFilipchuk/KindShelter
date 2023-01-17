using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseConfiguration
{
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.Property(breed => breed.BreedName).IsRequired();
            builder.Property(breed => breed.AnimalsId).IsRequired();
            builder
                .HasMany(breed => breed.Pets)
                .WithOne(pet => pet.Breed)
                .HasForeignKey(pet => pet.BreedId);
        }
    }
}
