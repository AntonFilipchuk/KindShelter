using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseConfiguration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(l => l.City).IsRequired();
        }
    }
}