using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabForWeb.EC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prodotto",
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
                    table.PrimaryKey("PK_Prodotto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utente",
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
                    table.PrimaryKey("PK_Utente", x => x.Id);
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
                        name: "FK_CategoriaProdotto_Categoria_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaProdotto_Prodotto_ProdottiId",
                        column: x => x.ProdottiId,
                        principalTable: "Prodotto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Indirizzo",
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
                    table.PrimaryKey("PK_Indirizzo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indirizzo_Utente_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartitaIVA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumeroPIVA = table.Column<string>(type: "char(11)", nullable: false),
                    NumeroUnico = table.Column<string>(type: "char(7)", nullable: false),
                    PEC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartitaIVA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartitaIVA_Utente_Id",
                        column: x => x.Id,
                        principalTable: "Utente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordine",
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
                    table.PrimaryKey("PK_Ordine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordine_Indirizzo_IndirizzoId",
                        column: x => x.IndirizzoId,
                        principalTable: "Indirizzo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdineDettaglio",
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
                    table.PrimaryKey("PK_OrdineDettaglio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdineDettaglio_Ordine_OrdineId",
                        column: x => x.OrdineId,
                        principalTable: "Ordine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdineDettaglio_Prodotto_ProdottoId",
                        column: x => x.ProdottoId,
                        principalTable: "Prodotto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Nome",
                table: "Categoria",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaProdotto_ProdottiId",
                table: "CategoriaProdotto",
                column: "ProdottiId");

            migrationBuilder.CreateIndex(
                name: "IX_Indirizzo_CAP",
                table: "Indirizzo",
                column: "CAP");

            migrationBuilder.CreateIndex(
                name: "IX_Indirizzo_UtenteId",
                table: "Indirizzo",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordine_Data",
                table: "Ordine",
                column: "Data");

            migrationBuilder.CreateIndex(
                name: "IX_Ordine_IndirizzoId",
                table: "Ordine",
                column: "IndirizzoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordine_Numero_Anno",
                table: "Ordine",
                columns: new[] { "Numero", "Anno" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordine_Stato",
                table: "Ordine",
                column: "Stato");

            migrationBuilder.CreateIndex(
                name: "IX_OrdineDettaglio_OrdineId_ProdottoId",
                table: "OrdineDettaglio",
                columns: new[] { "OrdineId", "ProdottoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdineDettaglio_ProdottoId",
                table: "OrdineDettaglio",
                column: "ProdottoId");

            migrationBuilder.CreateIndex(
                name: "IX_PartitaIVA_NumeroPIVA",
                table: "PartitaIVA",
                column: "NumeroPIVA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prodotto_Attivo",
                table: "Prodotto",
                column: "Attivo");

            migrationBuilder.CreateIndex(
                name: "IX_Prodotto_Visibile",
                table: "Prodotto",
                column: "Visibile");

            migrationBuilder.CreateIndex(
                name: "IX_Utente_Cognome",
                table: "Utente",
                column: "Cognome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaProdotto");

            migrationBuilder.DropTable(
                name: "OrdineDettaglio");

            migrationBuilder.DropTable(
                name: "PartitaIVA");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Ordine");

            migrationBuilder.DropTable(
                name: "Prodotto");

            migrationBuilder.DropTable(
                name: "Indirizzo");

            migrationBuilder.DropTable(
                name: "Utente");
        }
    }
}
