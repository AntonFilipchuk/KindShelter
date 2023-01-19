using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Enitites;
using Infrastructure.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShelterContext : DbContext
    {
        public ShelterContext() : base() { }

        public ShelterContext(DbContextOptions<ShelterContext> options) : base(options) { }

        public DbSet<Pet> Pets => Set<Pet>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Adress> Adresses => Set<Adress>();
        public DbSet<Animals> Animals => Set<Animals>();
        public DbSet<Breed> Breeds => Set<Breed>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PetConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new BreedConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new AdressConfiguration());
        }
    }
}
