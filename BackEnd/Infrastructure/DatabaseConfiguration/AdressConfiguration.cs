using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DatabaseConfiguration
{
    public class AdressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.Property(adress => adress.Street).IsRequired();
            builder.Property(adress => adress.CityId).IsRequired();
            builder.Property(adress => adress.HouseNumber).IsRequired(false);
            builder.Property(adress => adress.FlatNumber).IsRequired(false);
        }
    }
}
