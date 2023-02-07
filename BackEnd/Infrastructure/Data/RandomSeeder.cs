using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RandomSeeder
    {
        ModelBuilder _modelBuilder;
        private List<Animal> AnimalList = new();

        public RandomSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            AddAnimals();
            AddBreeds();
            AddPets();
            AddBrands();
            AddProductTypes();
            AddProducts();
            AddAnimalProducts();
        }

        private void AddAnimals()
        {
            Animal cat = new Animal { AnimalName = "Cat", Id = 1 };
            Animal dog = new Animal { AnimalName = "Dog", Id = 2 };
            Animal parrot = new Animal { AnimalName = "Parrot", Id = 3 };
            Animal fish = new Animal { AnimalName = "Fish", Id = 4 };

            AnimalList.Add(cat);
            AnimalList.Add(dog);
            AnimalList.Add(parrot);
            AnimalList.Add(fish);

            _modelBuilder.Entity<Animal>().HasData(cat);
            _modelBuilder.Entity<Animal>().HasData(dog);
            _modelBuilder.Entity<Animal>().HasData(parrot);
            _modelBuilder.Entity<Animal>().HasData(fish);
        }

        private void AddBreeds()
        {
            _modelBuilder
                .Entity<Breed>()
                .HasData(
                    new Breed
                    {
                        Id = 1,
                        AnimalId = 1,
                        BreedName = "Cool cat"
                    }
                );
            _modelBuilder
                .Entity<Breed>()
                .HasData(
                    new Breed
                    {
                        Id = 2,
                        AnimalId = 2,
                        BreedName = "Great dog"
                    }
                );
            _modelBuilder
                .Entity<Breed>()
                .HasData(
                    new Breed
                    {
                        Id = 3,
                        AnimalId = 3,
                        BreedName = "Colorful parrot"
                    }
                );
            _modelBuilder
                .Entity<Breed>()
                .HasData(
                    new Breed
                    {
                        Id = 4,
                        AnimalId = 4,
                        BreedName = "Small fish"
                    }
                );
        }

        private void AddPets()
        {
            //Cats
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 1,
                        Age = 1,
                        BreedId = 1,
                        Color = "white",
                        Gender = "female",
                        Name = "Lucy",
                        PictureUrl = "images/pets/whiteCat.jpg",
                        Description = "Cat description",
                        HasVaccines = true,
                        Price = 2000,
                    }
                );
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 2,
                        Age = 3,
                        BreedId = 1,
                        Color = "black",
                        Gender = "male",
                        Name = "Snowflake",
                        PictureUrl = "images/pets/blackCat.jpg",
                        Description = "Cat description",
                        HasVaccines = false,
                        Price = 5000,
                    }
                );
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 3,
                        Age = 5,
                        BreedId = 1,
                        Color = "orange",
                        Gender = "male",
                        Name = "Bobby",
                        PictureUrl = "images/pets/orangeCat.jpg",
                        Description = "Cat description",
                        HasVaccines = true,
                        Price = 1500,
                    }
                );

            //Dogs
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 4,
                        Age = 2,
                        BreedId = 2,
                        Color = "black",
                        Gender = "male",
                        Name = "Shelton",
                        PictureUrl = "images/pets/blackDog.jpg",
                        Description = "Dog description",
                        HasVaccines = true,
                        Price = 500,
                    }
                );
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 5,
                        Age = 1,
                        BreedId = 2,
                        Color = "white",
                        Gender = "female",
                        Name = "Tess",
                        PictureUrl = "images/pets/whiteDog.jpg",
                        Description = "Dog description",
                        HasVaccines = false,
                        Price = 200,
                    }
                );
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 6,
                        Age = 3,
                        BreedId = 2,
                        Color = "yellow",
                        Gender = "female",
                        Name = "Carina",
                        PictureUrl = "images/pets/yellowDog.jpg",
                        Description = "Dog description",
                        HasVaccines = false,
                        Price = 2400,
                    }
                );

            //Parrots
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 7,
                        Age = 3,
                        BreedId = 3,
                        Color = "yellow",
                        Gender = "male",
                        Name = "Wendell",
                        PictureUrl = "images/pets/yellowParrot.jpg",
                        Description = "Parrot description",
                        HasVaccines = true,
                        Price = 7000,
                    }
                );
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 8,
                        Age = 6,
                        BreedId = 3,
                        Color = "white",
                        Gender = "female",
                        Name = "Dianna",
                        PictureUrl = "images/pets/whiteParrot.jpg",
                        Description = "Parrot description",
                        HasVaccines = true,
                        Price = 6500,
                    }
                );
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 9,
                        Age = 7,
                        BreedId = 3,
                        Color = "orange",
                        Gender = "female",
                        Name = "Kendra",
                        PictureUrl = "images/pets/orangeParrot.jpg",
                        Description = "Parrot description",
                        HasVaccines = false,
                        Price = 3000,
                    }
                );
            //Fish
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 10,
                        Age = 1,
                        BreedId = 4,
                        Color = "yellow",
                        Gender = "female",
                        Name = "Delia",
                        PictureUrl = "images/pets/yellowFish.jpg",
                        Description = "Fish description",
                        HasVaccines = null,
                        Price = 300,
                    }
                );
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 11,
                        Age = 2,
                        BreedId = 4,
                        Color = "black",
                        Gender = "male",
                        Name = "Bennie",
                        PictureUrl = "images/pets/blackFish.jpg",
                        Description = "Fish description",
                        HasVaccines = null,
                        Price = 500,
                    }
                );
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 12,
                        Age = 1,
                        BreedId = 4,
                        Color = "black",
                        Gender = "female",
                        Name = "Delia",
                        PictureUrl = "images/pets/blackFish2.jpg",
                        Description = "Fish description",
                        HasVaccines = null,
                        Price = 1000,
                    }
                );
            _modelBuilder
                .Entity<Pet>()
                .HasData(
                    new Pet
                    {
                        Id = 13,
                        Age = 4,
                        BreedId = 3,
                        Color = "green",
                        Gender = "female",
                        Name = "Marcy",
                        PictureUrl = "images/pets/greenParrot.jpg",
                        Description = "Parrot description Parrot description Parrot description Parrot description Parrot description Parrot description Parrot description",
                        HasVaccines = true,
                        Price = 2000,
                    }
                );
        }

        private void AddBrands()
        {
            _modelBuilder.Entity<Brand>().HasData(new Brand { Id = 1, BrandName = "AniHal", });
            _modelBuilder.Entity<Brand>().HasData(new Brand { Id = 2, BrandName = "MultiPed", });
            _modelBuilder.Entity<Brand>().HasData(new Brand { Id = 3, BrandName = "Corwell", });
            _modelBuilder.Entity<Brand>().HasData(new Brand { Id = 4, BrandName = "Rescuer", });
        }

        private void AddProductTypes()
        {
            _modelBuilder
                .Entity<ProductType>()
                .HasData(new ProductType { Id = 1, ProductTypeName = "Food" });
            _modelBuilder
                .Entity<ProductType>()
                .HasData(new ProductType { Id = 2, ProductTypeName = "Accessories" });
            _modelBuilder
                .Entity<ProductType>()
                .HasData(new ProductType { Id = 3, ProductTypeName = "Medicine" });
            _modelBuilder
                .Entity<ProductType>()
                .HasData(new ProductType { Id = 4, ProductTypeName = "Toys" });
        }

        private void AddProducts()
        {
            _modelBuilder
                .Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 1,
                        BrandId = 1,
                        ProductTypeId = 1,
                        ProductName = "Healthy Dog Food",
                        PictureUrl = "images/products/dogFood.jpg",
                        ProductDescription = "Food for dogs",
                        ProductQuantity = 100,
                        ProductPrice = 120m
                    }
                );
            _modelBuilder
                .Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 2,
                        BrandId = 2,
                        ProductTypeId = 4,
                        ProductName = "Colorful Ball",
                        PictureUrl = "images/products/colorfulBall.jpg",
                        ProductDescription = "A toy for cats and dogs",
                        ProductQuantity = 50,
                        ProductPrice = 100m
                    }
                );
            _modelBuilder
                .Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 3,
                        BrandId = 3,
                        ProductTypeId = 3,
                        ProductName = "WormaKill",
                        PictureUrl = "images/products/wormaKill.jpg",
                        ProductDescription = "A medicine for cats and dogs",
                        ProductQuantity = 150,
                        ProductPrice = 500.99M
                    }
                );
            _modelBuilder
                .Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 4,
                        BrandId = 4,
                        ProductTypeId = 2,
                        ProductName = "Wooden house",
                        PictureUrl = "images/products/woodenHouse.jpg",
                        ProductDescription = "A wooden house for a parrot cage",
                        ProductQuantity = 15,
                        ProductPrice = 1000
                    }
                );
            _modelBuilder
                .Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 5,
                        BrandId = 2,
                        ProductTypeId = 2,
                        ProductName = "Fish Tank",
                        PictureUrl = "images/products/fishTank.jpg",
                        ProductDescription = "A fish tank for 100 lites",
                        ProductQuantity = 8,
                        ProductPrice = 4999.99m
                    }
                );
            _modelBuilder
                .Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 6,
                        BrandId = 1,
                        ProductTypeId = 1,
                        ProductName = "Dry food",
                        PictureUrl = "images/products/dryFood.jpg",
                        ProductDescription = "A dry food for both cats and dogs",
                        ProductQuantity = 500,
                        ProductPrice = 200
                    }
                );
        }

        private void AddAnimalProducts()
        {
            _modelBuilder
                .Entity<AnimalProduct>()
                .HasData(new AnimalProduct { AnimalId = 1, ProductId = 1 });
            _modelBuilder
                .Entity<AnimalProduct>()
                .HasData(new AnimalProduct { AnimalId = 1, ProductId = 2 });
            _modelBuilder
                .Entity<AnimalProduct>()
                .HasData(new AnimalProduct { AnimalId = 2, ProductId = 2 });
            _modelBuilder
                .Entity<AnimalProduct>()
                .HasData(new AnimalProduct { AnimalId = 1, ProductId = 3 });
            _modelBuilder
                .Entity<AnimalProduct>()
                .HasData(new AnimalProduct { AnimalId = 2, ProductId = 3 });
            _modelBuilder
                .Entity<AnimalProduct>()
                .HasData(new AnimalProduct { AnimalId = 3, ProductId = 4 });
            _modelBuilder
                .Entity<AnimalProduct>()
                .HasData(new AnimalProduct { AnimalId = 1, ProductId = 6 });
            _modelBuilder
                .Entity<AnimalProduct>()
                .HasData(new AnimalProduct { AnimalId = 2, ProductId = 6 });
        }
    }
}
