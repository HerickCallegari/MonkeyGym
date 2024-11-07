using MonkeyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Repositories.Interfaces
    {
    internal interface IRepository<T>
        {
        public T Add    ( T item );
        public  void Remove   ( T item);
        public  T? Find ( T item );
        public  T? FindById ( int id );
        public  List<T> FindAll ( );
        }
    }
