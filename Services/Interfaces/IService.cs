using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Services.Interfaces
    {
    interface IService <T>
        {
        public abstract T Add ( T item );
        public abstract void Remove ( T item );
        public abstract T Updates ( T item );
        public abstract T? FindBy( T item );
        public abstract T? FindById( int id);
        public abstract List<T> FindAll();

        }
    }
