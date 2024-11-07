using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Models
    {
    internal class Funcionario : Pessoa
        {
        public string PISS { get; set; }
        public DateTime DataContratacao { get; set; }
        public string HorarioTrabalho { get; set; }
        public double Salario { get; set; } 

        public Funcionario ( ) { }

        public Funcionario ( string matricula, string nome, string cpf, string rg, DateTime dataNascimento, string endereco, string senha, string piss, DateTime dataContratacao, string horarioTrabalho, double salario ) : base ( matricula, nome, cpf, rg, dataNascimento, endereco, senha)
            {
            PISS = piss;
            DataContratacao = dataContratacao;
            HorarioTrabalho = horarioTrabalho;
            Salario = salario;
            }

        public Funcionario ( int id, string matricula, string nome, string cpf, string rg, DateTime dataNascimento, string endereco, string senha, string piss, DateTime dataContratacao, string horarioTrabalho, double salario) : base ( id, matricula, nome, cpf, rg, dataNascimento, endereco, senha)
            {
            PISS = piss;
            DataContratacao = dataContratacao;
            HorarioTrabalho = horarioTrabalho;
            Salario = salario;
            }

        public override string ToString ( )
            {
            return base.ToString () +
                   "\nPISS: " + PISS +
                   "\nData Contratação: " + DataContratacao +
                   "\nHorario de Trabalho: " + HorarioTrabalho +
                   "\nSalario: " + Salario;
            }

        }
    }
