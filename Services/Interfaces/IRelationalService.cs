using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Services.Interfaces
    {
    internal interface IRelationalService< T, V, U>
        {
        public T Add ( T t);
        public void Remove ( T t );
        public T? FindBy (U u, V V );
        public T? FindById (int idU, int idV );
        public List<T> FindAll ();

        }
    }
