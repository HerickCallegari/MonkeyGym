using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using MonkeyGym.Data;
using MonkeyGym.Models;
using MonkeyGym.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Repositories
    {
    internal class PessoaRepository ( MonkeyGymContext db ) : IFinder
        {
        public Pessoa? Find ( Pessoa pessoa )
            {
            return db.Pessoas.Find ( pessoa );
            }

        public List<Pessoa> FindAll ( )
            {
            return db.Pessoas.ToList ();
            }

        public Pessoa? FindById ( int id )
            {
            return db.Pessoas.Find (id);
            }

        }
    }
