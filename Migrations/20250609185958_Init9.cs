using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MandrilAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habilidades_Mandrils_Mandrilid",
                table: "Habilidades");

            migrationBuilder.DropIndex(
                name: "IX_Habilidades_Mandrilid",
                table: "Habilidades");

            migrationBuilder.DropColumn(
                name: "Mandrilid",
                table: "Habilidades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mandrilid",
                table: "Habilidades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_Mandrilid",
                table: "Habilidades",
                column: "Mandrilid");

            migrationBuilder.AddForeignKey(
                name: "FK_Habilidades_Mandrils_Mandrilid",
                table: "Habilidades",
                column: "Mandrilid",
                principalTable: "Mandrils",
                principalColumn: "id");
        }
    }
}
