using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;
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
            builder.Property(pet => pet.Age).IsRequired();
            builder.Property(pet => pet.Color).IsRequired();
            builder.Property(pet => pet.Gender).IsRequired();
            builder.Property(pet => pet.PictureUrl).IsRequired();
            builder.HasOne(pet => pet.City).WithOne().HasForeignKey<Pet>(p => p.CityId);
            builder.HasOne(pet => pet.Adress).WithOne().HasForeignKey<Pet>(p => p.AdressId);
        }
    }
}
