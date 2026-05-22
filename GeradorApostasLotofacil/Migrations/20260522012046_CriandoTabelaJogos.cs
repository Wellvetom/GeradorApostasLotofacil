using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorApostasLotofacil.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaJogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JogoModel_Apostas_ApostaId",
                table: "JogoModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JogoModel",
                table: "JogoModel");

            migrationBuilder.RenameTable(
                name: "JogoModel",
                newName: "Jogos");

            migrationBuilder.RenameIndex(
                name: "IX_JogoModel_ApostaId",
                table: "Jogos",
                newName: "IX_Jogos_ApostaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jogos",
                table: "Jogos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Apostas_ApostaId",
                table: "Jogos",
                column: "ApostaId",
                principalTable: "Apostas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Apostas_ApostaId",
                table: "Jogos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jogos",
                table: "Jogos");

            migrationBuilder.RenameTable(
                name: "Jogos",
                newName: "JogoModel");

            migrationBuilder.RenameIndex(
                name: "IX_Jogos_ApostaId",
                table: "JogoModel",
                newName: "IX_JogoModel_ApostaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JogoModel",
                table: "JogoModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JogoModel_Apostas_ApostaId",
                table: "JogoModel",
                column: "ApostaId",
                principalTable: "Apostas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
