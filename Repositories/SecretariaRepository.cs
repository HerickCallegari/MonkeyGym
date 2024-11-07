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
    internal class SecretariaRepository ( MonkeyGymContext db ) : IRepository<Secretaria>
        {
        public MonkeyGymContext Db { get; set; } = db;

        public Secretaria Add ( Secretaria secretaria )
            {
            Db.Secretarias.Add (secretaria);

            Db.SaveChanges ();
            return secretaria;
            }
        public void Remove ( Secretaria secretaria )
            {
            secretaria = FindById (secretaria.Id)!;

            Db.Secretarias.Remove (secretaria);
            Db.SaveChanges ();
            }
        public Secretaria Update ( Secretaria secretaria )
            {
            Db.Secretarias.Update (secretaria);
            Db.SaveChanges ();
            return secretaria;
            }
        public Secretaria? Find ( Secretaria secretaria )
            {
            return Db.Secretarias.Find (secretaria);
            }
        public Secretaria? FindById ( int id )
            {
            return Db.Secretarias.Find (id);
            }

        public List<Secretaria> FindAll ( )
            {
            return Db.Secretarias.ToList ();
            }
        }
    }
