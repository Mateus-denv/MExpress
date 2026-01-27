using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mexpressapp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cilindrada = table.Column<int>(type: "int", nullable: false),
                    Cavalos = table.Column<int>(type: "int", nullable: false),
                    CapacidadeLitros = table.Column<double>(type: "float", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    KmRodados = table.Column<int>(type: "int", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    PrecoDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
