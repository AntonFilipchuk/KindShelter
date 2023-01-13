using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Enitites;
using Core.Enitites.Breeds;
using Infrastructure.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShelterContext : DbContext
    {
        public ShelterContext() : base() { }

        public ShelterContext(DbContextOptions<ShelterContext> options) : base(options) { }

        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Location>? Locations { get; set; }
        public DbSet<Breeds>? BreedsCollection { get; set; }
        public DbSet<BreedType>? BreedTypes {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AnimalsSetConfiguration());
            modelBuilder.ApplyConfiguration(new BreedsCollectionConfiguration());
            modelBuilder.ApplyConfiguration(new BreedTypesConfiguration());

            //modelBuilder.ApplyConfiguration(new LocationSetConfiguration());
        }
    }
}
