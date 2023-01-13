using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseConfiguration
{
    public class AnimalsSetConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Age).IsRequired();
            builder.Property(a => a.Color).IsRequired();
            builder.Property(a => a.Gender).IsRequired();
            builder.Property(a => a.PictureUrl).IsRequired();
            //builder.HasOne(a => a.Location).WithMany().HasForeignKey(a => a.LocationId);
        }
    }
}
