using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabForWeb.MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategorySlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorie",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Categorie",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Categorie");

            migrationBuilder.InsertData(
                table: "Categorie",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Articoli Sportivi" },
                    { 2, "Elettromestici" },
                    { 3, "Abbigliamento per la coppia" }
                });
        }
    }
}
