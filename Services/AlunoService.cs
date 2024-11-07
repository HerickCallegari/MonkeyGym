using MonkeyGym.Data;
using MonkeyGym.Entities;
using MonkeyGym.Models;
using MonkeyGym.Repositories;
using MonkeyGym.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Services
    {
    internal class AlunoService ( MonkeyGymContext context) : IService<Aluno>
        {
        public AlunoRepository Repository { get; set; } = new AlunoRepository(context);

        public Aluno Add (Aluno aluno)
            {
            ArgumentNullException.ThrowIfNull (aluno);

            if (string.IsNullOrEmpty (aluno.Endereco) || string.IsNullOrEmpty (aluno.Nome) || string.IsNullOrEmpty (aluno.CPF) || string.IsNullOrEmpty (aluno.Senha) || string.IsNullOrEmpty (aluno.RG))
                throw new ArgumentException ("Algum Campo não esta completo.");

            PessoaService pessoaService = new PessoaService (context);
            do
                {
                aluno.Matricula = new Random ().Next (1000000, 10000000).ToString ();
                } while (pessoaService.FindByMatricula (aluno.Matricula) != null);

            if (FindByCPF (aluno.CPF) != null)
                throw new ArgumentException ("Aluno já existe.");

            return Repository.Add (aluno);
            }

        public Aluno? FindByMatricula ( string? Matricula )
            {
            if (string.IsNullOrEmpty(Matricula) )
                throw new ArgumentNullException ("Matricula nulla ou vazia");

            foreach (var aluno in Repository.FindAll())
                {
                if (aluno.Matricula == Matricula)
                    return aluno;
                }
            return null; 
            }
        public Aluno? FindByCPF( string cpf )
            {
            if (string.IsNullOrEmpty (cpf))
                throw new ArgumentNullException ("Cpf null ou vazio");

            foreach (var aluno in Repository.FindAll ())
                {
                if (aluno.CPF == cpf)
                    return aluno;
                }
            return null;
            }
        public List<Aluno> FindAll()
            {
            return Repository.FindAll ();
            }
        
        public List<Debito> FindAllDebito(Aluno aluno)
            {
            DebitoService debitoService = new DebitoService(context);

            if (aluno == null || aluno.Id == null)
                throw new ArgumentNullException ("Aluno NULL");
                
            return debitoService.FindAllIfAluno (aluno);
            }

        public void Remove ( Aluno aluno )
            {
            ArgumentNullException.ThrowIfNull (aluno);
            Repository.Remove (aluno);
            }

        public Aluno Updates ( Aluno aluno )
            {
            ArgumentNullException.ThrowIfNull (aluno);

            if (string.IsNullOrEmpty (aluno.Endereco) || string.IsNullOrEmpty (aluno.Nome) || string.IsNullOrEmpty (aluno.Matricula) || string.IsNullOrEmpty (aluno.CPF) || string.IsNullOrEmpty (aluno.Senha))
                throw new ArgumentException ("Algum Campo não esta completo.");

            return Repository.Update (aluno);

            }

        public Aluno? FindBy ( Aluno aluno )
            {
            ArgumentNullException.ThrowIfNull (aluno);

            if (aluno.Id == null)
                throw new ArgumentNullException ("Id do aluno é NULL.");

            return Repository.Find (aluno);  
            }

        public Aluno? FindById ( int id )
            {
            if ( id == null)
                throw new ArgumentNullException ("id NULL");
            return Repository.FindById (id);
            }
        public List<AlunoTreino> VerTreinos ( Aluno aluno )
            {
            ArgumentNullException.ThrowIfNull (aluno);

            if (FindBy (aluno) == null)
                throw new ArgumentException ("Aluno nao existe.");
            AlunoTreinoService alunoTreinoService = new AlunoTreinoService (context);

            List<AlunoTreino> alunosTreinos = alunoTreinoService.FindAll ().Where(at => at.AlunoId == aluno.Id).ToList();

            return alunosTreinos;
            }
        }
    }
