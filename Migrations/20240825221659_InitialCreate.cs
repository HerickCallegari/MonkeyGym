using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonkeyGym.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    RG = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Pessoas_Id",
                        column: x => x.Id,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PISS = table.Column<string>(type: "TEXT", nullable: false),
                    DataContratacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HorarioTrabalho = table.Column<string>(type: "TEXT", nullable: false),
                    Salario = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Pessoas_Id",
                        column: x => x.Id,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoBarras = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debitos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Instrutores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrutores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instrutores_Funcionarios_Id",
                        column: x => x.Id,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Secretarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secretarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secretarias_Funcionarios_Id",
                        column: x => x.Id,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Debitos_AlunoId",
                table: "Debitos",
                column: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debitos");

            migrationBuilder.DropTable(
                name: "Instrutores");

            migrationBuilder.DropTable(
                name: "Limpezas");

            migrationBuilder.DropTable(
                name: "Secretarias");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
