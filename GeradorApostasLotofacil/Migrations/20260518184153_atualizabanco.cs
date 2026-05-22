using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorApostasLotofacil.Migrations
{
    /// <inheritdoc />
    public partial class atualizabanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NuSorteio",
                table: "Apostas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NuSorteio",
                table: "Apostas");
        }
    }
}
