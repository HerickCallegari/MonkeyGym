using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonkeyGym.Migrations
{
    /// <inheritdoc />
    public partial class migrationFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Limpezas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Limpezas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limpezas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Limpezas_Funcionarios_Id",
                        column: x => x.Id,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
