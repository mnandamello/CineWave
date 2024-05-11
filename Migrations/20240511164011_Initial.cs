using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineWave.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_CNWV_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email_Usuario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Hash_Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CNWV_USUARIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_CNWV_CAMPANHA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Titulo_Filme = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Genero_Filme = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Faxa_Etaria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Budget = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    Expectativa_De_Alcance = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CNWV_CAMPANHA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_CNWV_CAMPANHA_T_CNWV_USUARIO_UserId",
                        column: x => x.UserId,
                        principalTable: "T_CNWV_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_CNWV_INSIGHTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Titulo_Filme = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Previsao_De_Roi = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Canal_De_Marketing = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Custo_Medio_Click = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    Previsao_De_Conversao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CNWV_INSIGHTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_CNWV_INSIGHTS_T_CNWV_USUARIO_UserId",
                        column: x => x.UserId,
                        principalTable: "T_CNWV_USUARIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_CNWV_CAMPANHA_UserId",
                table: "T_CNWV_CAMPANHA",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_T_CNWV_INSIGHTS_UserId",
                table: "T_CNWV_INSIGHTS",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CNWV_CAMPANHA");

            migrationBuilder.DropTable(
                name: "T_CNWV_INSIGHTS");

            migrationBuilder.DropTable(
                name: "T_CNWV_USUARIO");
        }
    }
}
