using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Repositories.Interfaces
    {
    interface IRelational<T, U, V>
        {
        public T Add (T t);
        public T? FindById ( int u, int v);
        public T? Find ( U u, V v);
        public void Remove (T t);
        public List<T> FindAll ();
        }
    }
