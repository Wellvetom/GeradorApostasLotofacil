using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeradorApostasLotofacil.Migrations
{
    /// <inheritdoc />
    public partial class RefatoraJogoModelParaListaJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Add new JSON column
            migrationBuilder.AddColumn<string>(
                name: "Numeros",
                table: "Jogos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            // 2. Migrate data from 15 columns to JSON
            migrationBuilder.Sql(@"
                UPDATE Jogos
                SET Numeros = '[' + 
                    CAST(PrimeiroNumero AS NVARCHAR) + ',' +
                    CAST(SegundoNumero AS NVARCHAR) + ',' +
                    CAST(TerceiroNumero AS NVARCHAR) + ',' +
                    CAST(QuartoNumero AS NVARCHAR) + ',' +
                    CAST(QuintoNumero AS NVARCHAR) + ',' +
                    CAST(SextoNumero AS NVARCHAR) + ',' +
                    CAST(SetimoNumero AS NVARCHAR) + ',' +
                    CAST(OitavoNumero AS NVARCHAR) + ',' +
                    CAST(NonoNumero AS NVARCHAR) + ',' +
                    CAST(DecimoNumero AS NVARCHAR) + ',' +
                    CAST(DecimoPrimeiroNumero AS NVARCHAR) + ',' +
                    CAST(DecimoSegundoNumero AS NVARCHAR) + ',' +
                    CAST(DecimoTerceiroNumero AS NVARCHAR) + ',' +
                    CAST(DecimoQuartoNumero AS NVARCHAR) + ',' +
                    CAST(DecimoQuintoNumero AS NVARCHAR) + ']'
            ");

            // 3. Drop old columns
            migrationBuilder.DropColumn(name: "PrimeiroNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "SegundoNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "TerceiroNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "QuartoNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "QuintoNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "SextoNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "SetimoNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "OitavoNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "NonoNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "DecimoNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "DecimoPrimeiroNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "DecimoSegundoNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "DecimoTerceiroNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "DecimoQuartoNumero", table: "Jogos");
            migrationBuilder.DropColumn(name: "DecimoQuintoNumero", table: "Jogos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Re-add old columns
            migrationBuilder.AddColumn<int>(name: "PrimeiroNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "SegundoNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "TerceiroNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "QuartoNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "QuintoNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "SextoNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "SetimoNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "OitavoNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "NonoNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "DecimoNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "DecimoPrimeiroNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "DecimoSegundoNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "DecimoTerceiroNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "DecimoQuartoNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<int>(name: "DecimoQuintoNumero", table: "Jogos", type: "int", nullable: false, defaultValue: 0);

            // Migrate data back from JSON to columns
            migrationBuilder.Sql(@"
                UPDATE Jogos
                SET PrimeiroNumero = JSON_VALUE(Numeros, '$[0]'),
                    SegundoNumero = JSON_VALUE(Numeros, '$[1]'),
                    TerceiroNumero = JSON_VALUE(Numeros, '$[2]'),
                    QuartoNumero = JSON_VALUE(Numeros, '$[3]'),
                    QuintoNumero = JSON_VALUE(Numeros, '$[4]'),
                    SextoNumero = JSON_VALUE(Numeros, '$[5]'),
                    SetimoNumero = JSON_VALUE(Numeros, '$[6]'),
                    OitavoNumero = JSON_VALUE(Numeros, '$[7]'),
                    NonoNumero = JSON_VALUE(Numeros, '$[8]'),
                    DecimoNumero = JSON_VALUE(Numeros, '$[9]'),
                    DecimoPrimeiroNumero = JSON_VALUE(Numeros, '$[10]'),
                    DecimoSegundoNumero = JSON_VALUE(Numeros, '$[11]'),
                    DecimoTerceiroNumero = JSON_VALUE(Numeros, '$[12]'),
                    DecimoQuartoNumero = JSON_VALUE(Numeros, '$[13]'),
                    DecimoQuintoNumero = JSON_VALUE(Numeros, '$[14]')
            ");

            // Drop JSON column
            migrationBuilder.DropColumn(name: "Numeros", table: "Jogos");
        }
    }
}
