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
    internal class SecretariaService ( MonkeyGymContext context ) : IService<Secretaria>
        {

        public SecretariaRepository repository = new SecretariaRepository (context);

        public Secretaria Add ( Secretaria secretaria )
            {


            if (FindAll ().Count == 0)
                {
                context.Secretarias.Add (secretaria);
                }

            ArgumentNullException.ThrowIfNull (secretaria);

            if (secretaria.Matricula == "000")
                return repository.Add (secretaria);

            if (string.IsNullOrEmpty (secretaria.Endereco) || string.IsNullOrEmpty (secretaria.Nome) || string.IsNullOrEmpty (secretaria.CPF) || string.IsNullOrEmpty (secretaria.Senha) || string.IsNullOrEmpty (secretaria.HorarioTrabalho) || string.IsNullOrEmpty (secretaria.PISS) || string.IsNullOrEmpty (secretaria.RG))
                throw new ArgumentException ("Algum Campo não esta completo.");

            PessoaService pessoaService = new PessoaService (context);
            do
                {

                secretaria.Matricula = new Random ().Next (1000000, 10000000).ToString ();
                } while (pessoaService.FindByMatricula (secretaria.Matricula) != null);
            
            return repository.Add (secretaria);
            }
        public Secretaria? FindByMatricula ( string? Matricula )
            {
            if (string.IsNullOrEmpty (Matricula))
                throw new ArgumentNullException ("Matricula nulla ou vazia");

            foreach (var secretaria in repository.FindAll ())
                {
                if (secretaria.Matricula == Matricula)
                    return secretaria;
                }
            return null;
            }
        public Secretaria? FindByCPF ( string cpf )
            {
            if (string.IsNullOrEmpty (cpf))
                throw new ArgumentNullException ("Cpf null ou vazio");

            foreach (var secretaria in repository.FindAll ())
                {
                if (secretaria.CPF == cpf)
                    return secretaria;
                }
            return null;
            }
        public List<Secretaria> FindAll ( )
            {
            return repository.FindAll ();
            }

        public void Remove ( Secretaria secretaria )
            {
            ArgumentNullException.ThrowIfNull (secretaria);

            if (FindBy (secretaria) == null)
                throw new ArgumentException ("secretaria não existe no Banco de dados.");

            repository.Remove (secretaria);
            }

        public Secretaria Updates ( Secretaria secretaria )
            {
            ArgumentNullException.ThrowIfNull (secretaria);

            if (string.IsNullOrEmpty (secretaria.Endereco) || string.IsNullOrEmpty (secretaria.Nome) || string.IsNullOrEmpty (secretaria.Matricula) || string.IsNullOrEmpty (secretaria.CPF) || string.IsNullOrEmpty (secretaria.Senha))
                throw new ArgumentException ("Algum Campo não esta completo.");

            if (FindByMatricula (secretaria.Matricula) != null || FindByCPF (secretaria.CPF) != null)
                throw new ArgumentException ("secretaria já existe.");

            return repository.Update (secretaria);

            }

        public Secretaria? FindBy ( Secretaria secretaria )
            {
            ArgumentNullException.ThrowIfNull (secretaria);

            if (secretaria.Id == null)
                throw new ArgumentException ("Id do Secretaria é NULL");

            return repository.Find (secretaria);
            }

        public Secretaria? FindById ( int id )
            {
            if (id == null)
                throw new ArgumentNullException ("Id NULL");

            return repository.FindById (id);
            }
        }
    }
