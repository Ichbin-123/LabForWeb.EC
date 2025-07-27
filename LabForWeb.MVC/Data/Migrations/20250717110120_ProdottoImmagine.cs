using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabForWeb.MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProdottoImmagine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Prodotti",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Prodotti");
        }
    }
}
