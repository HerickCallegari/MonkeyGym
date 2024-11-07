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
    internal class AlunoRepository ( MonkeyGymContext db ) : IRepository<Aluno>
        {
        public MonkeyGymContext Db { get; set; } = db;

        public Aluno Add (Aluno aluno )
            {
            Db.Alunos.Add (aluno);

            Db.SaveChanges();
            return aluno;
            }
        public void Remove ( Aluno aluno )
            {
            aluno = FindById (aluno.Id)!;

            Db.Alunos.Remove (aluno);
            Db.SaveChanges();
            }
        public Aluno Update ( Aluno aluno) 
            {
            Db.Alunos.Update (aluno);
            Db.SaveChanges ();
            return aluno; 
            }
        public Aluno? Find ( Aluno aluno )
            {
            return Db.Alunos.Find (aluno.Id);
            }
        public Aluno? FindById ( int id )
            {
            return Db.Alunos.Find (id); 
            }
       
        public List<Aluno> FindAll ()
            {
            return Db.Alunos.ToList ();
            }
        }
    }
