using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseConfiguration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animals>
    {
        public void Configure(EntityTypeBuilder<Animals> builder)
        {
            builder.Property(animal => animal.CollectionName).IsRequired();
            builder
                .HasMany(animal => animal.Breeds)
                .WithOne(breed => breed.Animals)
                .HasForeignKey(breed => breed.AnimalsId);
        }
    }
}
