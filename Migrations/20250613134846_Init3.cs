using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MandrilAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PotenciaMH",
                table: "MandrilHabilidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_MandrilHabilidad_Potencia_Max4",
                table: "MandrilHabilidades",
                sql: "[PotenciaMH] <= 4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_MandrilHabilidad_Potencia_Max4",
                table: "MandrilHabilidades");

            migrationBuilder.DropColumn(
                name: "PotenciaMH",
                table: "MandrilHabilidades");
        }
    }
}
