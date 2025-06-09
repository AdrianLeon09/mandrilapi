using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MandrilAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MandrilHabilidades_Habilidades_HabilidadId",
                table: "MandrilHabilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_MandrilHabilidades_Mandrils_MandrilId",
                table: "MandrilHabilidades");

            migrationBuilder.RenameColumn(
                name: "MandrilId",
                table: "MandrilHabilidades",
                newName: "Mandrilid");

            migrationBuilder.RenameColumn(
                name: "HabilidadId",
                table: "MandrilHabilidades",
                newName: "Habilidadid");

            migrationBuilder.RenameIndex(
                name: "IX_MandrilHabilidades_MandrilId",
                table: "MandrilHabilidades",
                newName: "IX_MandrilHabilidades_Mandrilid");

            migrationBuilder.RenameIndex(
                name: "IX_MandrilHabilidades_HabilidadId",
                table: "MandrilHabilidades",
                newName: "IX_MandrilHabilidades_Habilidadid");

            migrationBuilder.AddForeignKey(
                name: "FK_MandrilHabilidades_Habilidades_Habilidadid",
                table: "MandrilHabilidades",
                column: "Habilidadid",
                principalTable: "Habilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MandrilHabilidades_Mandrils_Mandrilid",
                table: "MandrilHabilidades",
                column: "Mandrilid",
                principalTable: "Mandrils",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MandrilHabilidades_Habilidades_Habilidadid",
                table: "MandrilHabilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_MandrilHabilidades_Mandrils_Mandrilid",
                table: "MandrilHabilidades");

            migrationBuilder.RenameColumn(
                name: "Mandrilid",
                table: "MandrilHabilidades",
                newName: "MandrilId");

            migrationBuilder.RenameColumn(
                name: "Habilidadid",
                table: "MandrilHabilidades",
                newName: "HabilidadId");

            migrationBuilder.RenameIndex(
                name: "IX_MandrilHabilidades_Mandrilid",
                table: "MandrilHabilidades",
                newName: "IX_MandrilHabilidades_MandrilId");

            migrationBuilder.RenameIndex(
                name: "IX_MandrilHabilidades_Habilidadid",
                table: "MandrilHabilidades",
                newName: "IX_MandrilHabilidades_HabilidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_MandrilHabilidades_Habilidades_HabilidadId",
                table: "MandrilHabilidades",
                column: "HabilidadId",
                principalTable: "Habilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MandrilHabilidades_Mandrils_MandrilId",
                table: "MandrilHabilidades",
                column: "MandrilId",
                principalTable: "Mandrils",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
