using MonkeyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Repositories.Interfaces
    {
    internal interface IFinder
        {
        public abstract List<Pessoa> FindAll ( );
        public abstract Pessoa? Find ( Pessoa pessoa );
        public abstract Pessoa? FindById ( int id );

        }
    }
