using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MandrilAPI.Migrations
{
    /// <inheritdoc />
    public partial class reformatNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Skills",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Mandrils",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Mandrils",
                newName: "lastName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Skills",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Mandrils",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Mandrils",
                newName: "Apellido");
        }
    }
}
