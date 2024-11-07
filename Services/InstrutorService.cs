using MonkeyGym.Data;
using MonkeyGym.Models;
using MonkeyGym.Repositories.Interfaces;
using MonkeyGym.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Services
    {
    internal class InstrutorService ( MonkeyGymContext context ) : IService<Instrutor>
        {

        public InstrutorRepository repository = new InstrutorRepository (context);

        public Instrutor Add ( Instrutor instrutor )
            {

            ArgumentNullException.ThrowIfNull (instrutor);

            if (string.IsNullOrEmpty (instrutor.Endereco) || string.IsNullOrEmpty (instrutor.Nome) ||  string.IsNullOrEmpty (instrutor.CPF) || string.IsNullOrEmpty (instrutor.Senha) || string.IsNullOrEmpty (instrutor.HorarioTrabalho) || string.IsNullOrEmpty (instrutor.PISS) || string.IsNullOrEmpty (instrutor.RG))
                throw new ArgumentException ("Algum Campo não esta completo.");

            PessoaService pessoaService = new PessoaService (context);
            do
                {
                
                instrutor.Matricula = new Random ().Next (1000000, 10000000).ToString ();
                } while (pessoaService.FindByMatricula (instrutor.Matricula) != null);

            return repository.Add (instrutor);
            }
        public Instrutor? FindByMatricula ( string? Matricula )
            {
            if (string.IsNullOrEmpty (Matricula))
                throw new ArgumentNullException ("Matricula nulla ou vazia");

            foreach (var instrutor in repository.FindAll ())
                {
                if (instrutor.Matricula == Matricula)
                    return instrutor;
                }
            return null;
            }
        public Instrutor? FindByCPF ( string cpf )
            {
            if (string.IsNullOrEmpty (cpf))
                throw new ArgumentNullException ("Cpf null ou vazio");

            foreach (var instrutor in repository.FindAll ())
                {
                if (instrutor.CPF == cpf)
                    return instrutor;
                }
            return null;
            }
        public List<Instrutor> FindAll ( )
            {
            return repository.FindAll ();
            }

        public void Remove ( Instrutor instrutor )
            {
            ArgumentNullException.ThrowIfNull (instrutor);

            if (FindBy (instrutor) == null)
                throw new ArgumentException ("instrutor não existe no Banco de dados.");

            repository.Remove (instrutor);
            }

        public Instrutor Updates ( Instrutor instrutor )
            {
            ArgumentNullException.ThrowIfNull (instrutor);

            if (string.IsNullOrEmpty (instrutor.Endereco) || string.IsNullOrEmpty (instrutor.Nome) || string.IsNullOrEmpty (instrutor.Matricula) || string.IsNullOrEmpty (instrutor.CPF) || string.IsNullOrEmpty (instrutor.Senha))
                throw new ArgumentException ("Algum Campo não esta completo.");

            if (FindByMatricula (instrutor.Matricula) != null || FindByCPF (instrutor.CPF) != null)
                throw new ArgumentException ("instrutor já existe.");

            return repository.Update (instrutor);

            }

        public Instrutor? FindBy ( Instrutor instrutor )
            {
            ArgumentNullException.ThrowIfNull (instrutor);

            if (instrutor.Id == null)
                throw new ArgumentException ("Id do Instrutor é NULL");

            return repository.Find (instrutor);
            }

        public Instrutor? FindById ( int id )
            {
            if (id == null)
                throw new ArgumentNullException ("Id NULL");

            return repository.FindById (id);
            }
        }
    }
