using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mexpressapp.Migrations
{
    /// <inheritdoc />
    public partial class addcamposusario2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                table: "AspNetUsers");
        }
    }
}
