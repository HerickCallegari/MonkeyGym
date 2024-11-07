using Microsoft.EntityFrameworkCore;
using MonkeyGym.Data;
using MonkeyGym.Entities;
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
    internal class TreinoRepository ( MonkeyGymContext db ) : IRepository<Treino>
        {
        public MonkeyGymContext Db { get; set; } = db;

        public Treino Add ( Treino treino )
            { 
            Db.Treinos.Add (treino);

            Db.SaveChanges ();
            return treino;
            }
        public void Remove ( Treino treino )
            {
            Db.Treinos.Remove (treino);
            Db.SaveChanges ();
            }
        public Treino Update ( Treino treino )
            {
            Db.Treinos.Update (treino);
            Db.SaveChanges ();
            return treino;
            }
        public Treino? Find ( Treino treino )
            {
            return Db.Treinos.Find (treino);
            }
        public Treino? FindById ( int id )
            {
            return Db.Treinos.Find (id);
            }

        public List<Treino> FindAll ( )
            {
            return Db.Treinos.ToList ();
            }
        }
    }
