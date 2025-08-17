using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabForWeb.MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Indirizzi_Utenti_UtenteId",
                table: "Indirizzi");

            migrationBuilder.DropTable(
                name: "PartitaIVAs");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.AlterColumn<string>(
                name: "UtenteId",
                table: "Indirizzi",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CodiceFiscale",
                table: "AspNetUsers",
                type: "char(16)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cognome",
                table: "AspNetUsers",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NotificheWA",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Indirizzi_AspNetUsers_UtenteId",
                table: "Indirizzi",
                column: "UtenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Indirizzi_AspNetUsers_UtenteId",
                table: "Indirizzi");

            migrationBuilder.DropColumn(
                name: "CodiceFiscale",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cognome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NotificheWA",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UtenteId",
                table: "Indirizzi",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodiceFiscale = table.Column<string>(type: "char(16)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    NotificheWA = table.Column<bool>(type: "bit", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "Utenti",
                columns: new[] { "Id", "CodiceFiscale", "Cognome", "Email", "Nome", "NotificheWA", "Telefono" },
                values: new object[] { 2, "", "Admin", "admin@admin.com", "Admin", true, "" });

            migrationBuilder.CreateIndex(
                name: "IX_PartitaIVAs_NumeroPIVA",
                table: "PartitaIVAs",
                column: "NumeroPIVA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utenti_Cognome",
                table: "Utenti",
                column: "Cognome");

            migrationBuilder.AddForeignKey(
                name: "FK_Indirizzi_Utenti_UtenteId",
                table: "Indirizzi",
                column: "UtenteId",
                principalTable: "Utenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
