using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWave.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Usuario_Ativo",
                table: "T_CNWV_USUARIO",
                type: "BOOLEAN",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario_Ativo",
                table: "T_CNWV_USUARIO");
        }
    }
}
