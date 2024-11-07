CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "Pessoas" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Pessoas" PRIMARY KEY AUTOINCREMENT,
    "Matricula" TEXT NOT NULL,
    "Nome" TEXT NOT NULL,
    "CPF" TEXT NOT NULL,
    "RG" TEXT NOT NULL,
    "DataNascimento" TEXT NOT NULL,
    "Endereco" TEXT NOT NULL,
    "Senha" TEXT NOT NULL
);

CREATE TABLE "Alunos" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Alunos" PRIMARY KEY AUTOINCREMENT,
    "DataInicio" TEXT NOT NULL,
    CONSTRAINT "FK_Alunos_Pessoas_Id" FOREIGN KEY ("Id") REFERENCES "Pessoas" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Funcionarios" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Funcionarios" PRIMARY KEY AUTOINCREMENT,
    "PISS" TEXT NOT NULL,
    "DataContratacao" TEXT NOT NULL,
    "HorarioTrabalho" TEXT NOT NULL,
    "Salario" REAL NOT NULL,
    CONSTRAINT "FK_Funcionarios_Pessoas_Id" FOREIGN KEY ("Id") REFERENCES "Pessoas" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Debitos" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Debitos" PRIMARY KEY AUTOINCREMENT,
    "CodigoBarras" TEXT NOT NULL,
    "Descricao" TEXT NOT NULL,
    "Valor" REAL NOT NULL,
    "DataEmissao" TEXT NOT NULL,
    "DataVencimento" TEXT NOT NULL,
    "AlunoId" INTEGER NULL,
    CONSTRAINT "FK_Debitos_Alunos_AlunoId" FOREIGN KEY ("AlunoId") REFERENCES "Alunos" ("Id")
);

CREATE TABLE "Instrutores" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Instrutores" PRIMARY KEY AUTOINCREMENT,
    CONSTRAINT "FK_Instrutores_Funcionarios_Id" FOREIGN KEY ("Id") REFERENCES "Funcionarios" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Limpezas" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Limpezas" PRIMARY KEY AUTOINCREMENT,
    CONSTRAINT "FK_Limpezas_Funcionarios_Id" FOREIGN KEY ("Id") REFERENCES "Funcionarios" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Secretarias" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Secretarias" PRIMARY KEY AUTOINCREMENT,
    CONSTRAINT "FK_Secretarias_Funcionarios_Id" FOREIGN KEY ("Id") REFERENCES "Funcionarios" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Debitos_AlunoId" ON "Debitos" ("AlunoId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240825221659_InitialCreate', '8.0.8');

COMMIT;

