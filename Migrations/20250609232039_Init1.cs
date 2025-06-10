using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MandrilAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Potencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mandrils",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mandrils", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MandrilHabilidades",
                columns: table => new
                {
                    Mandrilid = table.Column<int>(type: "int", nullable: false),
                    Habilidadid = table.Column<int>(type: "int", nullable: false),
                    MandrilHabilidadesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MandrilHabilidades", x => new { x.Mandrilid, x.Habilidadid });
                    table.ForeignKey(
                        name: "FK_MandrilHabilidades_Habilidades_Habilidadid",
                        column: x => x.Habilidadid,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MandrilHabilidades_Mandrils_Mandrilid",
                        column: x => x.Mandrilid,
                        principalTable: "Mandrils",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MandrilHabilidades_Habilidadid",
                table: "MandrilHabilidades",
                column: "Habilidadid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MandrilHabilidades");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "Mandrils");
        }
    }
}
