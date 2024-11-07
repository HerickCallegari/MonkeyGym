using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonkeyGym.Migrations
{
    /// <inheritdoc />
    public partial class GrupoTreino : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GrupoTreino",
                table: "AlunoTreino",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrupoTreino",
                table: "AlunoTreino");
        }
    }
}
