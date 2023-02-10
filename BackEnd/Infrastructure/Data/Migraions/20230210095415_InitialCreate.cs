using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migraions
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalName = table.Column<string>(type: "TEXT", nullable: false),
                    PluralAnimalName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrandName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BreedName = table.Column<string>(type: "TEXT", nullable: false),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeds_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: true),
                    ProductPrice = table.Column<double>(type: "REAL", nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ProductTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    HasVaccines = table.Column<bool>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BreedId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalProduct",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalProduct", x => new { x.AnimalId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_AnimalProduct_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "AnimalName", "PluralAnimalName" },
                values: new object[,]
                {
                    { 1, "Cat", "Cats" },
                    { 2, "Dog", "Dogs" },
                    { 3, "Parrot", "Parrots" },
                    { 4, "Fish", "Fish" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[,]
                {
                    { 1, "AniHal" },
                    { 2, "MultiPed" },
                    { 3, "Corwell" },
                    { 4, "Rescuer" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "ProductTypeName" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Accessories" },
                    { 3, "Medicine" },
                    { 4, "Toys" }
                });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "AnimalId", "BreedName" },
                values: new object[,]
                {
                    { 1, 1, "Cool cat" },
                    { 2, 2, "Great dog" },
                    { 3, 3, "Colorful parrot" },
                    { 4, 4, "Small fish" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "PictureUrl", "ProductDescription", "ProductName", "ProductPrice", "ProductQuantity", "ProductTypeId" },
                values: new object[,]
                {
                    { 1, 1, "images/products/dogFood.jpg", "Food for dogs", "Healthy Dog Food", 120.0, 100, 1 },
                    { 2, 2, "images/products/colorfulBall.jpg", "A toy for cats and dogs", "Colorful Ball", 100.0, 50, 4 },
                    { 3, 3, "images/products/wormaKill.jpg", "A medicine for cats and dogs", "WormaKill", 500.99000000000001, 150, 3 },
                    { 4, 4, "images/products/woodenHouse.jpg", "A wooden house for a parrot cage", "Wooden house", 1000.0, 15, 2 },
                    { 5, 2, "images/products/fishTank.jpg", "A fish tank for 100 lites", "Fish Tank", 4999.9899999999998, 8, 2 },
                    { 6, 1, "images/products/dryFood.jpg", "A dry food for both cats and dogs", "Dry food", 200.0, 500, 1 }
                });

            migrationBuilder.InsertData(
                table: "AnimalProduct",
                columns: new[] { "AnimalId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 6 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 6 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "BreedId", "Color", "Description", "Gender", "HasVaccines", "Name", "PictureUrl", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, "white", "Cat descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "female", true, "Lucy", "images/pets/whiteCat.jpg", 2000.0 },
                    { 2, 3, 1, "black", "Cat descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "male", false, "Snowflake", "images/pets/blackCat.jpg", 5000.0 },
                    { 3, 5, 1, "orange", "Cat descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "male", true, "Bobby", "images/pets/orangeCat.jpg", 1500.0 },
                    { 4, 2, 2, "black", "Dog descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "male", true, "Shelton", "images/pets/blackDog.jpg", 500.0 },
                    { 5, 1, 2, "white", "Dog descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "female", false, "Tess", "images/pets/whiteDog.jpg", 200.0 },
                    { 6, 3, 2, "yellow", "Dog descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "female", false, "Carina", "images/pets/yellowDog.jpg", 2400.0 },
                    { 7, 3, 3, "yellow", "Parrot descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "male", true, "Wendell", "images/pets/yellowParrot.jpg", 7000.0 },
                    { 8, 6, 3, "white", "Parrot descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "female", true, "Dianna", "images/pets/whiteParrot.jpg", 6500.0 },
                    { 9, 7, 3, "orange", "Parrot descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "female", false, "Kendra", "images/pets/orangeParrot.jpg", 3000.0 },
                    { 10, 1, 4, "yellow", "Fish descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "female", null, "Delia", "images/pets/yellowFish.jpg", 300.0 },
                    { 11, 2, 4, "black", "Fish descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "male", null, "Bennie", "images/pets/blackFish.jpg", 500.0 },
                    { 12, 1, 4, "black", "Fish descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "female", null, "Delia", "images/pets/blackFish2.jpg", 1000.0 },
                    { 13, 4, 3, "green", "Parrot descriptionMaecenas fermentum tellus mauris. Vestibulum egestas euismod lorem, in euismod quam pharetra at. Integer sollicitudin tellus lectus, in semper dui molestie ac. Donec placerat, elit non sollicitudin tempus, justo elit condimentum neque, id porta tellus ligula at nunc. In semper, risus et sodales interdum, quam metus eleifend turpis, eget condimentum nunc sem sit amet mauris. Integer volutpat pulvinar sem, eu tempus dolor vehicula in. Etiam pharetra faucibus neque ac pulvinar. Proin iaculis pharetra purus eu auctor. Proin nec tristique sem. Curabitur turpis libero, vestibulum et semper vitae, fermentum sed orci. Aliquam lectus sapien, varius nec nisi eget, convallis rutrum mauris. Suspendisse hendrerit pellentesque risus vel auctor. Pellentesque sed feugiat odio, et bibendum odio.", "female", true, "Marcy", "images/pets/greenParrot.jpg", 2000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalProduct_ProductId",
                table: "AnimalProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_AnimalId",
                table: "Breeds",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_BreedId",
                table: "Pets",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalProduct");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
