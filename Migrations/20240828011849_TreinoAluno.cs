using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonkeyGym.Migrations
{
    /// <inheritdoc />
    public partial class TreinoAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunoTreino",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TreinoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoTreino", x => new { x.AlunoId, x.TreinoId });
                    table.ForeignKey(
                        name: "FK_AlunoTreino_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoTreino_Treinos_TreinoId",
                        column: x => x.TreinoId,
                        principalTable: "Treinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTreino_TreinoId",
                table: "AlunoTreino",
                column: "TreinoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoTreino");

            migrationBuilder.DropTable(
                name: "Treinos");
        }
    }
}
