using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonkeyGym.Migrations
{
    /// <inheritdoc />
    public partial class porfavordacerto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debitos_Alunos_AlunoId",
                table: "Debitos");

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Debitos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "Debitos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Pago",
                table: "Debitos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Debitos_Alunos_AlunoId",
                table: "Debitos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Debitos_Alunos_AlunoId",
                table: "Debitos");

            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Debitos");

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Debitos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "AlunoId",
                table: "Debitos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Debitos_Alunos_AlunoId",
                table: "Debitos",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");
        }
    }
}
