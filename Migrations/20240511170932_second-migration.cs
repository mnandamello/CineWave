using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWave.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_CNWV_INSIGHTS_T_CNWV_USUARIO_UserId",
                table: "T_CNWV_INSIGHTS");

            migrationBuilder.DropIndex(
                name: "IX_T_CNWV_INSIGHTS_UserId",
                table: "T_CNWV_INSIGHTS");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "T_CNWV_INSIGHTS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "T_CNWV_INSIGHTS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_T_CNWV_INSIGHTS_UserId",
                table: "T_CNWV_INSIGHTS",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_CNWV_INSIGHTS_T_CNWV_USUARIO_UserId",
                table: "T_CNWV_INSIGHTS",
                column: "UserId",
                principalTable: "T_CNWV_USUARIO",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
