using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorApostasLotofacil.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentoUsuarioAposta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Apostas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apostas_UsuarioId",
                table: "Apostas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostas_Usuarios_UsuarioId",
                table: "Apostas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostas_Usuarios_UsuarioId",
                table: "Apostas");

            migrationBuilder.DropIndex(
                name: "IX_Apostas_UsuarioId",
                table: "Apostas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Apostas");
        }
    }
}
