using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mexpressapp.Migrations
{
    /// <inheritdoc />
    public partial class addcamposusario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CdsCNH",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CodigoValidacaoCNH",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoValidacaoCNH",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CdsCNH",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
