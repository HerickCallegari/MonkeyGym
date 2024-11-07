using MonkeyGym.Data;
using MonkeyGym.Models;
using MonkeyGym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Services
    {
    internal class PessoaService ( MonkeyGymContext context )
        {
        public PessoaRepository repository = new PessoaRepository(context);

        public Pessoa? Find ( Pessoa pessoa )
            {
            return repository.Find (pessoa);
            }

        public List<Pessoa> FindAll ( )
            {
            return repository.FindAll ();
            }

        public Pessoa? FindById ( int id )
            {
            return repository.FindById (id);
            }

        public Pessoa? FindByMatricula ( string? matricula )
            {

            if (string.IsNullOrEmpty (matricula))
                throw new ArgumentNullException ("Matricula não encontrada");

            foreach(var pessoa  in repository.FindAll() ) 
                {
                if ( pessoa.Matricula == matricula )
                    return pessoa;
                }
            return null;
            }
        public Pessoa? FindByCPF ( string? CPF )
            {

            if (string.IsNullOrEmpty (CPF))
                throw new ArgumentNullException ("CPF não encontrada");

            foreach (var pessoa in repository.FindAll ())
                {
                if (pessoa.CPF == CPF)
                    return pessoa;
                }
            return null;
            }

        }
    }
