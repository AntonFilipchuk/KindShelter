using Core.Entities;
using Infrastructure.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ShelterContext : DbContext
    {
        public ShelterContext() : base() { }

        public ShelterContext(DbContextOptions<ShelterContext> options) : base(options) { }

        public DbSet<Pet> Pets => Set<Pet>();
        public DbSet<Animal> Animals => Set<Animal>();
        public DbSet<Breed> Breeds => Set<Breed>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductType> ProductTypes => Set<ProductType>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //All this will run on dotnet ef migrations add
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PetConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new BreedConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            

            RandomSeeder seeder = new RandomSeeder(modelBuilder);
            
            //For configuring decimal values in DB
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType
                        .GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));
                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }    
                }
            }
        }
    }
}
