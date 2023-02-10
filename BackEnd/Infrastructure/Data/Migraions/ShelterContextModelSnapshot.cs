﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migraions
{
    [DbContext(typeof(ShelterContext))]
    partial class ShelterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Core.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnimalName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PluralAnimalName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalName = "Cat",
                            PluralAnimalName = "Cats"
                        },
                        new
                        {
                            Id = 2,
                            AnimalName = "Dog",
                            PluralAnimalName = "Dogs"
                        },
                        new
                        {
                            Id = 3,
                            AnimalName = "Parrot",
                            PluralAnimalName = "Parrots"
                        },
                        new
                        {
                            Id = 4,
                            AnimalName = "Fish",
                            PluralAnimalName = "Fish"
                        });
                });

            modelBuilder.Entity("Core.Entities.AnimalProduct", b =>
                {
                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnimalId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("AnimalProduct");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            AnimalId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            AnimalId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            AnimalId = 1,
                            ProductId = 3
                        },
                        new
                        {
                            AnimalId = 2,
                            ProductId = 3
                        },
                        new
                        {
                            AnimalId = 3,
                            ProductId = 4
                        },
                        new
                        {
                            AnimalId = 1,
                            ProductId = 6
                        },
                        new
                        {
                            AnimalId = 2,
                            ProductId = 6
                        });
                });

            modelBuilder.Entity("Core.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandName = "AniHal"
                        },
                        new
                        {
                            Id = 2,
                            BrandName = "MultiPed"
                        },
                        new
                        {
                            Id = 3,
                            BrandName = "Corwell"
                        },
                        new
                        {
                            Id = 4,
                            BrandName = "Rescuer"
                        });
                });

            modelBuilder.Entity("Core.Entities.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BreedName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("Breeds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimalId = 1,
                            BreedName = "Cool cat"
                        },
                        new
                        {
                            Id = 2,
                            AnimalId = 2,
                            BreedName = "Great dog"
                        },
                        new
                        {
                            Id = 3,
                            AnimalId = 3,
                            BreedName = "Colorful parrot"
                        },
                        new
                        {
                            Id = 4,
                            AnimalId = 4,
                            BreedName = "Small fish"
                        });
                });

            modelBuilder.Entity("Core.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BreedId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("HasVaccines")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.ToTable("Pets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 1,
                            BreedId = 1,
                            Color = "white",
                            Description = "Cat descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "female",
                            HasVaccines = true,
                            Name = "Lucy",
                            PictureUrl = "images/pets/whiteCat.jpg",
                            Price = 2000.0
                        },
                        new
                        {
                            Id = 2,
                            Age = 3,
                            BreedId = 1,
                            Color = "black",
                            Description = "Cat descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "male",
                            HasVaccines = false,
                            Name = "Snowflake",
                            PictureUrl = "images/pets/blackCat.jpg",
                            Price = 5000.0
                        },
                        new
                        {
                            Id = 3,
                            Age = 5,
                            BreedId = 1,
                            Color = "orange",
                            Description = "Cat descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "male",
                            HasVaccines = true,
                            Name = "Bobby",
                            PictureUrl = "images/pets/orangeCat.jpg",
                            Price = 1500.0
                        },
                        new
                        {
                            Id = 4,
                            Age = 2,
                            BreedId = 2,
                            Color = "black",
                            Description = "Dog descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "male",
                            HasVaccines = true,
                            Name = "Shelton",
                            PictureUrl = "images/pets/blackDog.jpg",
                            Price = 500.0
                        },
                        new
                        {
                            Id = 5,
                            Age = 1,
                            BreedId = 2,
                            Color = "white",
                            Description = "Dog descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "female",
                            HasVaccines = false,
                            Name = "Tess",
                            PictureUrl = "images/pets/whiteDog.jpg",
                            Price = 200.0
                        },
                        new
                        {
                            Id = 6,
                            Age = 3,
                            BreedId = 2,
                            Color = "yellow",
                            Description = "Dog descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "female",
                            HasVaccines = false,
                            Name = "Carina",
                            PictureUrl = "images/pets/yellowDog.jpg",
                            Price = 2400.0
                        },
                        new
                        {
                            Id = 7,
                            Age = 3,
                            BreedId = 3,
                            Color = "yellow",
                            Description = "Parrot descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "male",
                            HasVaccines = true,
                            Name = "Wendell",
                            PictureUrl = "images/pets/yellowParrot.jpg",
                            Price = 7000.0
                        },
                        new
                        {
                            Id = 8,
                            Age = 6,
                            BreedId = 3,
                            Color = "white",
                            Description = "Parrot descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "female",
                            HasVaccines = true,
                            Name = "Dianna",
                            PictureUrl = "images/pets/whiteParrot.jpg",
                            Price = 6500.0
                        },
                        new
                        {
                            Id = 9,
                            Age = 7,
                            BreedId = 3,
                            Color = "orange",
                            Description = "Parrot descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "female",
                            HasVaccines = false,
                            Name = "Kendra",
                            PictureUrl = "images/pets/orangeParrot.jpg",
                            Price = 3000.0
                        },
                        new
                        {
                            Id = 10,
                            Age = 1,
                            BreedId = 4,
                            Color = "yellow",
                            Description = "Fish descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "female",
                            Name = "Delia",
                            PictureUrl = "images/pets/yellowFish.jpg",
                            Price = 300.0
                        },
                        new
                        {
                            Id = 11,
                            Age = 2,
                            BreedId = 4,
                            Color = "black",
                            Description = "Fish descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "male",
                            Name = "Bennie",
                            PictureUrl = "images/pets/blackFish.jpg",
                            Price = 500.0
                        },
                        new
                        {
                            Id = 12,
                            Age = 1,
                            BreedId = 4,
                            Color = "black",
                            Description = "Fish descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "female",
                            Name = "Delia",
                            PictureUrl = "images/pets/blackFish2.jpg",
                            Price = 1000.0
                        },
                        new
                        {
                            Id = 13,
                            Age = 4,
                            BreedId = 3,
                            Color = "green",
                            Description = "Parrot descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.",
                            Gender = "female",
                            HasVaccines = true,
                            Name = "Marcy",
                            PictureUrl = "images/pets/greenParrot.jpg",
                            Price = 2000.0
                        });
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            PictureUrl = "images/products/dogFood.jpg",
                            ProductDescription = "Food for dogs",
                            ProductName = "Healthy Dog Food",
                            ProductPrice = 120.0,
                            ProductQuantity = 100,
                            ProductTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            PictureUrl = "images/products/colorfulBall.jpg",
                            ProductDescription = "A toy for cats and dogs",
                            ProductName = "Colorful Ball",
                            ProductPrice = 100.0,
                            ProductQuantity = 50,
                            ProductTypeId = 4
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            PictureUrl = "images/products/wormaKill.jpg",
                            ProductDescription = "A medicine for cats and dogs",
                            ProductName = "WormaKill",
                            ProductPrice = 500.99000000000001,
                            ProductQuantity = 150,
                            ProductTypeId = 3
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 4,
                            PictureUrl = "images/products/woodenHouse.jpg",
                            ProductDescription = "A wooden house for a parrot cage",
                            ProductName = "Wooden house",
                            ProductPrice = 1000.0,
                            ProductQuantity = 15,
                            ProductTypeId = 2
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 2,
                            PictureUrl = "images/products/fishTank.jpg",
                            ProductDescription = "A fish tank for 100 lites",
                            ProductName = "Fish Tank",
                            ProductPrice = 4999.9899999999998,
                            ProductQuantity = 8,
                            ProductTypeId = 2
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 1,
                            PictureUrl = "images/products/dryFood.jpg",
                            ProductDescription = "A dry food for both cats and dogs",
                            ProductName = "Dry food",
                            ProductPrice = 200.0,
                            ProductQuantity = 500,
                            ProductTypeId = 1
                        });
                });

            modelBuilder.Entity("Core.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductTypeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductTypeName = "Food"
                        },
                        new
                        {
                            Id = 2,
                            ProductTypeName = "Accessories"
                        },
                        new
                        {
                            Id = 3,
                            ProductTypeName = "Medicine"
                        },
                        new
                        {
                            Id = 4,
                            ProductTypeName = "Toys"
                        });
                });

            modelBuilder.Entity("Core.Entities.AnimalProduct", b =>
                {
                    b.HasOne("Core.Entities.Animal", "Animal")
                        .WithMany("AnimalProducts")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Product", "Product")
                        .WithMany("AnimalProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Core.Entities.Breed", b =>
                {
                    b.HasOne("Core.Entities.Animal", "Animal")
                        .WithMany("Breeds")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("Core.Entities.Pet", b =>
                {
                    b.HasOne("Core.Entities.Breed", "Breed")
                        .WithMany("Pets")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breed");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.HasOne("Core.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Core.Entities.Animal", b =>
                {
                    b.Navigation("AnimalProducts");

                    b.Navigation("Breeds");
                });

            modelBuilder.Entity("Core.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Core.Entities.Breed", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("Core.Entities.Product", b =>
                {
                    b.Navigation("AnimalProducts");
                });

            modelBuilder.Entity("Core.Entities.ProductType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
