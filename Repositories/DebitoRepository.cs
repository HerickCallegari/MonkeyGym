using MonkeyGym.Data;
using MonkeyGym.Models;
using MonkeyGym.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Services
    {
    internal class DebitoRepository ( MonkeyGymContext db ) : IRepository<Debito>
        {
        private readonly MonkeyGymContext Db = db;

        public void Remove ( Debito debito )
            {
            Db.Debitos.Remove (debito);
            Db.SaveChanges ();
            }
        public Debito Update ( Debito debito )
            {
            Db.Debitos.Update (debito);
            Db.SaveChanges ();

            return debito;
            }
        public Debito? Find ( Debito debito )
            {
            return Db.Debitos.Find (debito);
            }
        public Debito? FindById ( int id )
            {
            return Db.Debitos.Find (id); ;
            }
        public List<Debito> FindAll ( )
            {
            return Db.Debitos.ToList ();
            }


        public Debito Add ( Debito debito )
            {
            if (FindById (debito.Id) != null)
                {
                throw new Exception("Debito ja existente.");
                }
                Db.Debitos.Add (debito);
                Db.SaveChanges ();
                return debito;
                }
            }
        }

