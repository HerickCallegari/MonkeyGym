using Microsoft.EntityFrameworkCore;
using MonkeyGym.Entities;
using MonkeyGym.Models;
using System;

namespace MonkeyGym.Data
    {
    internal class MonkeyGymContext : DbContext
        {
        public DbSet<Debito> Debitos { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Instrutor> Instrutores { get; set; }
        public DbSet<Secretaria> Secretarias { get; set; }
        public DbSet<AlunoTreino> AlunoTreino { get; set; }

        protected override void OnModelCreating ( ModelBuilder modelBuilder )
            {
            // Configurar a chave primária na classe base 'Pessoa'
            modelBuilder.Entity<Pessoa> ()
                .HasKey (p => p.Id);

            // Mapeando a classe base 'Pessoa' para a tabela 'Pessoas'
            modelBuilder.Entity<Pessoa> ()
                .ToTable ("Pessoas");

            // Mapeando a classe derivada 'Aluno' para a tabela 'Alunos'
            modelBuilder.Entity<Aluno> ()
                .ToTable ("Alunos");

            // Configurar a herança de Funcionario e suas subclasses
            modelBuilder.Entity<Funcionario> ()
                .ToTable ("Funcionarios"); // Tabela para a classe abstrata 'Funcionario'

            modelBuilder.Entity<Instrutor> ()
                .ToTable ("Instrutores");

            modelBuilder.Entity<Secretaria> ()
                .ToTable ("Secretarias");

            modelBuilder.Entity<Treino> ()
                .ToTable ("Treinos")
                .HasKey (t => t.Id);

            // Configurar relacionamento entre 'Aluno' e 'Debito'
            modelBuilder.Entity<Aluno> (entity =>
            {
                entity.HasMany (a => a.Debitos)
                      .WithOne (d => d.Aluno)
                      .HasForeignKey (d => d.AlunoId)
                      .OnDelete (DeleteBehavior.Cascade);
            });

            // Configurar a entidade 'Debito'
            modelBuilder.Entity<Debito> (entity =>
            {
                entity.ToTable ("Debitos");
                entity.HasKey (d => d.Id);
                entity.Property (d => d.Valor).HasColumnType ("decimal(18,2)");
            });

            // Configurar a relação Aluno <-> Treino (AlunoTreino)
            modelBuilder.Entity<AlunoTreino> ()
                .HasKey (at => new { at.AlunoId, at.TreinoId });

            modelBuilder.Entity<AlunoTreino> ()
                .HasOne (at => at.Aluno)
                .WithMany (a => a.Treinos)
                .HasForeignKey (at => at.AlunoId)
                .OnDelete (DeleteBehavior.Cascade); // Exclusão em cascata quando um Aluno é excluído

            modelBuilder.Entity<AlunoTreino> ()
                .HasOne (at => at.Treino)
                .WithMany (t => t.Alunos)
                .HasForeignKey (at => at.TreinoId)
                .OnDelete (DeleteBehavior.Cascade); // Exclusão em cascata quando um Treino é excluído

            // Configuração da propriedade 'GrupoDeTreino' para char
            modelBuilder.Entity<AlunoTreino> ()
                .Property (at => at.GrupoTreino)
                .HasMaxLength (1) // Define o tamanho máximo como 1 caractere
                .IsRequired (); // Torna o campo obrigatório

            base.OnModelCreating (modelBuilder);
            }

        public string DbPath { get; }

        public MonkeyGymContext ( )
            {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath (folder);
            DbPath = System.IO.Path.Join (path, "MonkeyGym.db");
            }

        protected override void OnConfiguring ( DbContextOptionsBuilder options )
            => options.UseSqlite ($"Data Source={DbPath}");
        }
    }
