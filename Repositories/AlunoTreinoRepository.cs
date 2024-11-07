using MonkeyGym.Data;
using MonkeyGym.Entities;
using MonkeyGym.Models;
using MonkeyGym.Repositories.Interfaces;
using MonkeyGym.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Repositories
    {
    internal class AlunoTreinoRepository ( MonkeyGymContext db ) : IRelational<AlunoTreino, Aluno, Treino>
        {
        public AlunoTreino Add ( AlunoTreino alunoTreino )
            {
            db.AlunoTreino.Add ( alunoTreino);
            db.SaveChanges();
            return alunoTreino;
            }
        public AlunoTreino? Find ( Aluno aluno, Treino treino )
            {
            return db.AlunoTreino.Find (aluno.Id, treino.Id);
            }

        public List<AlunoTreino> FindAll ( )
            {
            return db.AlunoTreino.ToList ();
            }

        public AlunoTreino? FindById ( int idAluno, int idTreino )
            {
            return db.AlunoTreino.Find(idAluno, idTreino);
            }

        public void Remove ( AlunoTreino alunoTreino )
            {
            db.AlunoTreino.Remove (alunoTreino);
            db.SaveChanges();
            }
        }
    }
