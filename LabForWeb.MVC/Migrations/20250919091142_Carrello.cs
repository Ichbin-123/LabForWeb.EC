using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabForWeb.MVC.Migrations
{
    /// <inheritdoc />
    public partial class Carrello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrelli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCreazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataChiusura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sconto = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    UtenteId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrelli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrelli_AspNetUsers_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrelloDettagli",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantita = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CarrelloId = table.Column<long>(type: "bigint", nullable: false),
                    ProdotttoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrelloDettagli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrelloDettagli_Carrelli_CarrelloId",
                        column: x => x.CarrelloId,
                        principalTable: "Carrelli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrelloDettagli_Prodotti_ProdotttoId",
                        column: x => x.ProdotttoId,
                        principalTable: "Prodotti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrelli_UtenteId",
                table: "Carrelli",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrelloDettagli_CarrelloId",
                table: "CarrelloDettagli",
                column: "CarrelloId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrelloDettagli_ProdotttoId",
                table: "CarrelloDettagli",
                column: "ProdotttoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrelloDettagli");

            migrationBuilder.DropTable(
                name: "Carrelli");
        }
    }
}
