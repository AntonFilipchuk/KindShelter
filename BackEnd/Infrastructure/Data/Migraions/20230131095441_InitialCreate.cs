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
                    AnimalName = table.Column<string>(type: "TEXT", nullable: false)
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
                    ProductPrice = table.Column<decimal>(type: "TEXT", nullable: false),
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
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
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
                columns: new[] { "Id", "AnimalName" },
                values: new object[,]
                {
                    { 1, "Cat" },
                    { 2, "Dog" },
                    { 3, "Parrot" },
                    { 4, "Fish" }
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
                columns: new[] { "Id", "BrandId", "ProductDescription", "ProductName", "ProductPrice", "ProductQuantity", "ProductTypeId" },
                values: new object[,]
                {
                    { 1, 1, "Food for dogs", "Healthy Dog Food", 120m, 100, 1 },
                    { 2, 2, "A toy for cats and dogs", "Colorful Ball", 100m, 50, 4 },
                    { 3, 3, "A medicine for cats and dogs", "WormaKill", 500m, 150, 3 },
                    { 4, 4, "A wooden house for a parrot cage", "Wooden house", 1000m, 15, 2 },
                    { 5, 2, "A fish tank for 100 lites", "Fish Tank", 5000m, 8, 2 },
                    { 6, 1, "A dry food for both cats and dogs", "Dry food", 200m, 500, 1 }
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
                    { 1, 1, 1, "white", "Cat description", "female", true, "Lucy", "1", 2000m },
                    { 2, 3, 1, "black", "Cat description", "male", false, "Snowflake", "2", 5000m },
                    { 3, 5, 1, "orange", "Cat description", "male", true, "Bobby", "3", 1500m },
                    { 4, 2, 2, "black", "Dog description", "male", true, "Shelton", "4", 500m },
                    { 5, 1, 2, "white", "Dog description", "female", false, "Tess", "5", 200m },
                    { 6, 3, 2, "yellow", "Dog description", "female", false, "Carina", "6", 2400m },
                    { 7, 3, 3, "yellow", "Parrot description", "male", true, "Wendell", "7", 7000m },
                    { 8, 6, 3, "white", "Parrot description", "female", true, "Dianna", "8", 6500m },
                    { 9, 7, 3, "orange", "Parrot description", "female", false, "Kendra", "9", 3000m },
                    { 10, 1, 4, "yellow", "Fish description", "female", null, "Delia", "10", 300m },
                    { 11, 2, 4, "black", "Fish description", "male", null, "Bennie", "11", 500m },
                    { 12, 1, 4, "black", "Fish description", "female", null, "Delia", "12", 1000m }
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
