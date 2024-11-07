using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Models
    {
    internal class Pessoa 
        {
        public int Id { get; set; } 

        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; } 
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; } 
        public string Senha { get; set;}

        public Pessoa ( ) { }
        public Pessoa ( int id, string matricula, string nome, string cpf, string rg, DateTime dataNascimento, string endereco, string senha )
            {
            Id = id;
            Senha = senha;
            Matricula = matricula;
            Nome = nome;
            CPF = cpf;
            RG = rg;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            Senha = senha;
            }
        public Pessoa (  string matricula, string nome, string cpf, string rg, DateTime dataNascimento, string endereco, string senha )
            {
            Senha = senha;
            Matricula = matricula;
            Nome = nome;
            CPF = cpf;
            RG = rg;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            Senha = senha;
            }
        

        public void AlteraSenha ( string senha )
            {
            Senha = senha;
            }

        public override string ToString ( )
            {
            return "Id: " + Id +
                   "\nMatricula: " + Matricula +
                   "\nNome: " + Nome +
                   "\nCPF: " + CPF +
                   "\nRG: " + RG +
                   "\nData Nascimento: " + DataNascimento.ToString("dd/MM/yyyy") +
                   "\nEndereco: " + Endereco;
            }

        }
    }
