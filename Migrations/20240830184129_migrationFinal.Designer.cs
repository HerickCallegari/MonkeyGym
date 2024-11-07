﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonkeyGym.Data;

#nullable disable

namespace MonkeyGym.Migrations
{
    [DbContext(typeof(MonkeyGymContext))]
    [Migration("20240830184129_migrationFinal")]
    partial class migrationFinal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("MonkeyGym.Entities.AlunoTreino", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TreinoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlunoId", "TreinoId");

                    b.HasIndex("TreinoId");

                    b.ToTable("AlunoTreino");
                });

            modelBuilder.Entity("MonkeyGym.Entities.Treino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Treinos", (string)null);
                });

            modelBuilder.Entity("MonkeyGym.Models.Debito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodigoBarras")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Pago")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Debitos", (string)null);
                });

            modelBuilder.Entity("MonkeyGym.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pessoas", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MonkeyGym.Models.Aluno", b =>
                {
                    b.HasBaseType("MonkeyGym.Models.Pessoa");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.ToTable("Alunos", (string)null);
                });

            modelBuilder.Entity("MonkeyGym.Models.Funcionario", b =>
                {
                    b.HasBaseType("MonkeyGym.Models.Pessoa");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("HorarioTrabalho")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PISS")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Salario")
                        .HasColumnType("REAL");

                    b.ToTable("Funcionarios", (string)null);
                });

            modelBuilder.Entity("MonkeyGym.Models.Instrutor", b =>
                {
                    b.HasBaseType("MonkeyGym.Models.Funcionario");

                    b.ToTable("Instrutores", (string)null);
                });

            modelBuilder.Entity("MonkeyGym.Models.Secretaria", b =>
                {
                    b.HasBaseType("MonkeyGym.Models.Funcionario");

                    b.ToTable("Secretarias", (string)null);
                });

            modelBuilder.Entity("MonkeyGym.Entities.AlunoTreino", b =>
                {
                    b.HasOne("MonkeyGym.Models.Aluno", "Aluno")
                        .WithMany("Treinos")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MonkeyGym.Entities.Treino", "Treino")
                        .WithMany("Alunos")
                        .HasForeignKey("TreinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Treino");
                });

            modelBuilder.Entity("MonkeyGym.Models.Debito", b =>
                {
                    b.HasOne("MonkeyGym.Models.Aluno", "Aluno")
                        .WithMany("Debitos")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("MonkeyGym.Models.Aluno", b =>
                {
                    b.HasOne("MonkeyGym.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("MonkeyGym.Models.Aluno", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MonkeyGym.Models.Funcionario", b =>
                {
                    b.HasOne("MonkeyGym.Models.Pessoa", null)
                        .WithOne()
                        .HasForeignKey("MonkeyGym.Models.Funcionario", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MonkeyGym.Models.Instrutor", b =>
                {
                    b.HasOne("MonkeyGym.Models.Funcionario", null)
                        .WithOne()
                        .HasForeignKey("MonkeyGym.Models.Instrutor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MonkeyGym.Models.Secretaria", b =>
                {
                    b.HasOne("MonkeyGym.Models.Funcionario", null)
                        .WithOne()
                        .HasForeignKey("MonkeyGym.Models.Secretaria", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MonkeyGym.Entities.Treino", b =>
                {
                    b.Navigation("Alunos");
                });

            modelBuilder.Entity("MonkeyGym.Models.Aluno", b =>
                {
                    b.Navigation("Debitos");

                    b.Navigation("Treinos");
                });
#pragma warning restore 612, 618
        }
    }
}
