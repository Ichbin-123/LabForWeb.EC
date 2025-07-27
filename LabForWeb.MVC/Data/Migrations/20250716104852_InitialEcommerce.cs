using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabForWeb.MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialEcommerce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prodotti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DescrizioneBreve = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Giacenza = table.Column<short>(type: "smallint", nullable: false),
                    Prezzo = table.Column<decimal>(type: "money", nullable: false),
                    Visibile = table.Column<bool>(type: "bit", nullable: false),
                    Attivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CodiceFiscale = table.Column<string>(type: "char(16)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NotificheWA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaProdotto",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    ProdottiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProdotto", x => new { x.CategorieId, x.ProdottiId });
                    table.ForeignKey(
                        name: "FK_CategoriaProdotto_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaProdotto_Prodotti_ProdottiId",
                        column: x => x.ProdottiId,
                        principalTable: "Prodotti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Indirizzi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Via = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    CAP = table.Column<string>(type: "char(5)", nullable: false),
                    Comune = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    ProvinciaSigla = table.Column<string>(type: "char(2)", nullable: false),
                    ScalaInterno = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CognomeCitofono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InfoIndirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indirizzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indirizzi_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartitaIVAs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumeroPIVA = table.Column<string>(type: "char(11)", nullable: false),
                    NumeroUnico = table.Column<string>(type: "char(7)", nullable: false),
                    PEC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartitaIVAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartitaIVAs_Utenti_Id",
                        column: x => x.Id,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordini",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stato = table.Column<short>(type: "smallint", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Anno = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndirizzoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordini", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordini_Indirizzi_IndirizzoId",
                        column: x => x.IndirizzoId,
                        principalTable: "Indirizzi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdineDettagli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantita = table.Column<short>(type: "smallint", nullable: false),
                    OrdineId = table.Column<int>(type: "int", nullable: false),
                    ProdottoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdineDettagli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdineDettagli_Ordini_OrdineId",
                        column: x => x.OrdineId,
                        principalTable: "Ordini",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdineDettagli_Prodotti_ProdottoId",
                        column: x => x.ProdottoId,
                        principalTable: "Prodotti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorie",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Articoli Sportivi" },
                    { 2, "Elettromestici" },
                    { 3, "Abbigliamento per la coppia" }
                });

            migrationBuilder.InsertData(
                table: "Utenti",
                columns: new[] { "Id", "CodiceFiscale", "Cognome", "Email", "Nome", "NotificheWA", "Telefono" },
                values: new object[] { 2, "", "Admin", "admin@admin.com", "Admin", true, "" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProdotto_ProdottiId",
                table: "CategoriaProdotto",
                column: "ProdottiId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorie_Nome",
                table: "Categorie",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Indirizzi_CAP",
                table: "Indirizzi",
                column: "CAP");

            migrationBuilder.CreateIndex(
                name: "IX_Indirizzi_UtenteId",
                table: "Indirizzi",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdineDettagli_OrdineId_ProdottoId",
                table: "OrdineDettagli",
                columns: new[] { "OrdineId", "ProdottoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdineDettagli_ProdottoId",
                table: "OrdineDettagli",
                column: "ProdottoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_Data",
                table: "Ordini",
                column: "Data");

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_IndirizzoId",
                table: "Ordini",
                column: "IndirizzoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_Numero_Anno",
                table: "Ordini",
                columns: new[] { "Numero", "Anno" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_Stato",
                table: "Ordini",
                column: "Stato");

            migrationBuilder.CreateIndex(
                name: "IX_PartitaIVAs_NumeroPIVA",
                table: "PartitaIVAs",
                column: "NumeroPIVA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_Attivo",
                table: "Prodotti",
                column: "Attivo");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotti_Visibile",
                table: "Prodotti",
                column: "Visibile");

            migrationBuilder.CreateIndex(
                name: "IX_Utenti_Cognome",
                table: "Utenti",
                column: "Cognome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaProdotto");

            migrationBuilder.DropTable(
                name: "OrdineDettagli");

            migrationBuilder.DropTable(
                name: "PartitaIVAs");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Ordini");

            migrationBuilder.DropTable(
                name: "Prodotti");

            migrationBuilder.DropTable(
                name: "Indirizzi");

            migrationBuilder.DropTable(
                name: "Utenti");
        }
    }
}
