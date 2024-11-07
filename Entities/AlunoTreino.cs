using MonkeyGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Entities
    {
    internal class AlunoTreino
        {
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int TreinoId { get; set;}
        public Treino Treino { get; set;}

        public Char GrupoTreino { get; set; }

        public AlunoTreino() { }
        public AlunoTreino(Aluno aluno, Treino treino, Char grupoTreino )
            {
            Aluno = aluno;
            Treino = treino;
            AlunoId = aluno.Id;
            TreinoId = treino.Id;
            GrupoTreino = char.ToUpper (grupoTreino);
            }
        }
    }
