using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseConfiguration
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.Property(pet => pet.Id).IsRequired();
            builder.Property(pet => pet.Name).IsRequired();
            
            //For SQlite ro correctly represent decimal values
            //https://learn.microsoft.com/en-us/ef/core/providers/sqlite/limitations#query-limitations
            builder.Property(pet => pet.Price).HasConversion<double>().IsRequired();
            
            builder.Property(pet => pet.Age).IsRequired();
            builder.Property(pet => pet.Color).IsRequired();
            builder.Property(pet => pet.Gender).IsRequired();
            builder.Property(pet => pet.PictureUrl).IsRequired();
            builder.Property(pet => pet.HasVaccines).IsRequired(false);
            builder.Property(pet => pet.Description).IsRequired(false);

            builder.HasOne(pet => pet.Breed).WithMany(breed => breed.Pets).IsRequired();
        }
    }
}
