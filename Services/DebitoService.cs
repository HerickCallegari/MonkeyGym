using MonkeyGym.Data;
using MonkeyGym.Models;
using MonkeyGym.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Services
    {
    internal class DebitoService ( MonkeyGymContext context ) : IService<Debito>
        {

        public DebitoRepository repository = new DebitoRepository (context);

        public Debito Add (Debito debito)
            {

            ArgumentNullException.ThrowIfNull (debito);

            if (debito.DataVencimento == null || debito.DataEmissao == null || debito.Aluno == null || debito.Pago == null || debito.Valor == null)
                throw new ArgumentException ("Algum campo não foi preenchido corretamente.");

            do
                {
                debito.CodigoBarras = new Random ().Next (100000000, 999999999).ToString ();
                } while (FindByCodigoBarras (debito.CodigoBarras) != null);
            return repository.Add (debito);
            }
        public Debito? FindByCodigoBarras ( string codigoBarras )
            {

            if (string.IsNullOrEmpty (codigoBarras))
                throw new ArgumentNullException ("Codigo de barras nullo ou vazio.");

            List<Debito> Debitos = repository.FindAll ();
            foreach (Debito debito in Debitos)
                {
                if (debito.CodigoBarras == codigoBarras)
                    return debito;
                }
            return null;
            }
        public List<Debito> FindAll ()
            {
            return repository.FindAll (); 
            }
        public List<Debito> FindAllIfAluno ( Aluno aluno)
            {

            if (aluno == null  || aluno.Id == null)
                throw new NullReferenceException ("Aluno não existe no contexto.");

            List<Debito> debitos = new List<Debito> ();
            foreach ( var debito in repository.FindAll())
                {
                if ( debito.AlunoId == aluno.Id )
                    debitos.Add (debito);
                }
            return debitos;
            }

        public void Remove ( Debito debito )
            {
            ArgumentNullException.ThrowIfNull (debito);

            if ( FindById (debito.Id) == null )
                throw new ArgumentException ("Debito não existe no Banco de dados.");

            repository.Remove (debito);
            }

        public Debito Updates ( Debito debito )
            {
            ArgumentNullException.ThrowIfNull (debito);

            if (debito.DataVencimento == null || debito.DataEmissao == null || debito.Aluno == null || debito.Pago == null || debito.Valor == null)
                throw new ArgumentException ("Algum campo não foi preenchido corretamente.");

            if (FindById (debito.Id) == null)
                throw new ArgumentException ("Debito não existe no contexto atual");

            return repository.Update(debito);

            }

        public Debito? FindBy ( Debito debito )
            {
            ArgumentNullException.ThrowIfNull (debito);

            if (debito.Id == null)
                throw new ArgumentException ("Id do Debito é NULL");

            return repository.Find (debito);
            }

        public Debito? FindById ( int id )
            {
            if ( id == null)
                throw new ArgumentNullException ("Id NULL");

            return repository.FindById (id); 
            }
        }
    }
