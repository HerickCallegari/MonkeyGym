using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Models
    {
    internal class Instrutor : Funcionario
        {

        public Instrutor() { }
        public Instrutor ( string matricula, string nome, string cpf, string rg, DateTime dataNascimento, string endereco, string senha, string piss, DateTime dataContratacao, string horarioTrabalho, double salario ) : base ( matricula, nome, cpf, rg, dataNascimento, endereco, senha, piss, dataContratacao, horarioTrabalho, salario)
            {

            }
        public Instrutor ( int id, string matricula, string nome, string cpf, string rg, DateTime dataNascimento, string endereco, string senha, string piss, DateTime dataContratacao, string horarioTrabalho, double salario ) : base ( id, matricula, nome, cpf, rg, dataNascimento, endereco, senha, piss, dataContratacao, horarioTrabalho, salario)
            {

            }
        }
    }
