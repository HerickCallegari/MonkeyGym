using MonkeyGym.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Models
    {
    internal class Aluno : Pessoa
        {
        public DateTime DataInicio { get; set; }

        public ICollection<Debito> Debitos { get; set; } = new List<Debito> ();
        public ICollection<AlunoTreino> Treinos { get; set; } = new List<AlunoTreino> ();

        public Aluno ( ) { }
        public Aluno ( int id, string matricula, string nome, string cpf, string rg, DateTime dataNascimento, string endereco, string senha, DateTime dataInicio ) : base (id, matricula, nome, cpf, rg, dataNascimento, endereco, senha)
            {
            DataInicio = dataInicio;
            }
        public Aluno ( string matricula, string nome, string cpf, string rg, DateTime dataNascimento, string endereco, string senha, DateTime dataInicio ) : base ( matricula, nome, cpf, rg, dataNascimento, endereco, senha)
            {
            DataInicio = dataInicio;
            }
        public override string ToString ( )
            {
            return base.ToString () + "\nData Inicio: " + DataInicio; 
            }
        }
    }
