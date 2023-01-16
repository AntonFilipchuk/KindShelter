using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migraions
{
    /// <inheritdoc />
    public partial class ChangedNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Animals_AnimalId",
                table: "Breeds");

            migrationBuilder.RenameColumn(
                name: "AnimalId",
                table: "Breeds",
                newName: "AnimalsId");

            migrationBuilder.RenameIndex(
                name: "IX_Breeds_AnimalId",
                table: "Breeds",
                newName: "IX_Breeds_AnimalsId");

            migrationBuilder.RenameColumn(
                name: "AnimalName",
                table: "Animals",
                newName: "CollectionNAme");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Animals_AnimalsId",
                table: "Breeds",
                column: "AnimalsId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Animals_AnimalsId",
                table: "Breeds");

            migrationBuilder.RenameColumn(
                name: "AnimalsId",
                table: "Breeds",
                newName: "AnimalId");

            migrationBuilder.RenameIndex(
                name: "IX_Breeds_AnimalsId",
                table: "Breeds",
                newName: "IX_Breeds_AnimalId");

            migrationBuilder.RenameColumn(
                name: "CollectionNAme",
                table: "Animals",
                newName: "AnimalName");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Animals_AnimalId",
                table: "Breeds",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
