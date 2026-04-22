using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorApostasLotofacil.Migrations
{
    /// <inheritdoc />
    public partial class TabelaAposta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apostas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataApuracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apostas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JogoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiroNumero = table.Column<int>(type: "int", nullable: false),
                    SegundoNumero = table.Column<int>(type: "int", nullable: false),
                    TerceiroNumero = table.Column<int>(type: "int", nullable: false),
                    QuartoNumero = table.Column<int>(type: "int", nullable: false),
                    QuintoNumero = table.Column<int>(type: "int", nullable: false),
                    SextoNumero = table.Column<int>(type: "int", nullable: false),
                    SetimoNumero = table.Column<int>(type: "int", nullable: false),
                    OitavoNumero = table.Column<int>(type: "int", nullable: false),
                    NonoNumero = table.Column<int>(type: "int", nullable: false),
                    DecimoNumero = table.Column<int>(type: "int", nullable: false),
                    DecimoPrimeiroNumero = table.Column<int>(type: "int", nullable: false),
                    DecimoSegundoNumero = table.Column<int>(type: "int", nullable: false),
                    DecimoTerceiroNumero = table.Column<int>(type: "int", nullable: false),
                    DecimoQuartoNumero = table.Column<int>(type: "int", nullable: false),
                    DecimoQuintoNumero = table.Column<int>(type: "int", nullable: false),
                    ApostaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JogoModel_Apostas_ApostaId",
                        column: x => x.ApostaId,
                        principalTable: "Apostas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JogoModel_ApostaId",
                table: "JogoModel",
                column: "ApostaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogoModel");

            migrationBuilder.DropTable(
                name: "Apostas");
        }
    }
}
