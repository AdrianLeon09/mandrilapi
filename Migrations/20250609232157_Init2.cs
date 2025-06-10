using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MandrilAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MandrilHabilidadesid",
                table: "MandrilHabilidades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MandrilHabilidadesid",
                table: "MandrilHabilidades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
