using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MandrilAPI.Migrations
{
    /// <inheritdoc />
    public partial class refactor2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CK_MandrilPower_Power_Max4 , PowerMS <= 4_Mandrils_MandrilId",
                table: "CK_MandrilPower_Power_Max4 , PowerMS <= 4");

            migrationBuilder.DropForeignKey(
                name: "FK_CK_MandrilPower_Power_Max4 , PowerMS <= 4_Skills_SkillId",
                table: "CK_MandrilPower_Power_Max4 , PowerMS <= 4");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CK_MandrilPower_Power_Max4 , PowerMS <= 4",
                table: "CK_MandrilPower_Power_Max4 , PowerMS <= 4");

            migrationBuilder.RenameTable(
                name: "CK_MandrilPower_Power_Max4 , PowerMS <= 4",
                newName: "MandrilWithSkills");

            migrationBuilder.RenameIndex(
                name: "IX_CK_MandrilPower_Power_Max4 , PowerMS <= 4_SkillId",
                table: "MandrilWithSkills",
                newName: "IX_MandrilWithSkills_SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MandrilWithSkills",
                table: "MandrilWithSkills",
                columns: new[] { "MandrilId", "SkillId" });

            migrationBuilder.AddCheckConstraint(
                name: "power_limit_4",
                table: "MandrilWithSkills",
                sql: "PowerMS <= 4");

            migrationBuilder.AddForeignKey(
                name: "FK_MandrilWithSkills_Mandrils_MandrilId",
                table: "MandrilWithSkills",
                column: "MandrilId",
                principalTable: "Mandrils",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MandrilWithSkills_Skills_SkillId",
                table: "MandrilWithSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MandrilWithSkills_Mandrils_MandrilId",
                table: "MandrilWithSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_MandrilWithSkills_Skills_SkillId",
                table: "MandrilWithSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MandrilWithSkills",
                table: "MandrilWithSkills");

            migrationBuilder.DropCheckConstraint(
                name: "power_limit_4",
                table: "MandrilWithSkills");

            migrationBuilder.RenameTable(
                name: "MandrilWithSkills",
                newName: "CK_MandrilPower_Power_Max4 , PowerMS <= 4");

            migrationBuilder.RenameIndex(
                name: "IX_MandrilWithSkills_SkillId",
                table: "CK_MandrilPower_Power_Max4 , PowerMS <= 4",
                newName: "IX_CK_MandrilPower_Power_Max4 , PowerMS <= 4_SkillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CK_MandrilPower_Power_Max4 , PowerMS <= 4",
                table: "CK_MandrilPower_Power_Max4 , PowerMS <= 4",
                columns: new[] { "MandrilId", "SkillId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CK_MandrilPower_Power_Max4 , PowerMS <= 4_Mandrils_MandrilId",
                table: "CK_MandrilPower_Power_Max4 , PowerMS <= 4",
                column: "MandrilId",
                principalTable: "Mandrils",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CK_MandrilPower_Power_Max4 , PowerMS <= 4_Skills_SkillId",
                table: "CK_MandrilPower_Power_Max4 , PowerMS <= 4",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
