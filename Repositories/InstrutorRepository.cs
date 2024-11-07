using Microsoft.EntityFrameworkCore;
using MonkeyGym.Data;
using MonkeyGym.Models;
using MonkeyGym.Repositories;
using MonkeyGym.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Services
    {
    internal class InstrutorRepository ( MonkeyGymContext Db ) : IRepository<Instrutor>
        {
        public MonkeyGymContext Db { get; set; } = Db;

        public Instrutor Add ( Instrutor instrutor )
            {
            Db.Instrutores.Add (instrutor);

            Db.SaveChanges ();
            return instrutor;
            }
        public void Remove ( Instrutor instrutor )
            {
            instrutor = FindById (instrutor.Id)!;

            Db.Instrutores.Remove (instrutor);
            Db.SaveChanges ();
            }
        public Instrutor Update ( Instrutor instrutor )
            {
            Db.Instrutores.Update (instrutor);
            Db.SaveChanges ();
            return instrutor;
            }
        public Instrutor? Find ( Instrutor instrutor )
            {
            return Db.Instrutores.Find (instrutor);
            }
        public Instrutor? FindById ( int id )
            {
            return Db.Instrutores.Find (id);
            }

        public List<Instrutor> FindAll ( )
            {
            return Db.Instrutores.ToList ();
            }
        }
    }
