using MonkeyGym.Data;
using MonkeyGym.Entities;
using MonkeyGym.Models;
using MonkeyGym.Repositories;
using MonkeyGym.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Services
    {
    internal class AlunoTreinoService ( MonkeyGymContext context) : IRelationalService<AlunoTreino, Treino, Aluno>
        {
        public AlunoTreinoRepository Repository = new AlunoTreinoRepository (context);
        public AlunoService AlunoService = new AlunoService (context);
        public TreinoService TreinoService = new TreinoService (context);
        public AlunoTreino Add ( AlunoTreino alunoTreino )
            {
            ArgumentNullException.ThrowIfNull (alunoTreino.Treino);
            ArgumentNullException.ThrowIfNull (alunoTreino.Aluno);
            ArgumentNullException.ThrowIfNull (alunoTreino.GrupoTreino);

            alunoTreino.GrupoTreino = char.ToUpper (alunoTreino.GrupoTreino);

            Repository.Add (alunoTreino);
            return alunoTreino;
            }

        public List<AlunoTreino> FindAll ( )
            {
            return Repository.FindAll ( );
            }

        public AlunoTreino? FindBy ( Aluno u, Treino v )
            {
            if (AlunoService.FindById (u.Id) == null || TreinoService.FindById (v.Id) == null)
                throw new ArgumentNullException ("Aluno ou treino nao existem");
            return Repository.Find (u, v);
            }

        public AlunoTreino? FindById ( int idU, int idV )
            {
            if ( idU == null || idV == null)
                throw new ArgumentNullException ("id");
            if (AlunoService.FindById (idU) == null || TreinoService.FindById (idV) == null)
                throw new ArgumentNullException ("Aluno ou treino nao existem");
            return Repository.FindById (idU, idV);
           
            }

        public void Remove ( AlunoTreino alunoTreino )
            {
            ArgumentNullException.ThrowIfNull (alunoTreino);
            ArgumentNullException.ThrowIfNull (alunoTreino.Aluno);
            ArgumentNullException.ThrowIfNull (alunoTreino.Treino);
            Repository.Remove (alunoTreino);
            }
        }
    }
