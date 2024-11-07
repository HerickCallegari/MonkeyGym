using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MonkeyGym.Data;
using MonkeyGym.Entities;
using MonkeyGym.Migrations;
using MonkeyGym.Models;
using MonkeyGym.Repositories;
using MonkeyGym.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Services
    {
    internal class TreinoService (MonkeyGymContext context) : IService<Treino>
        {
        public TreinoRepository Repository = new TreinoRepository (context);
        public Treino Add ( Treino treino )
            {
            ArgumentNullException.ThrowIfNull (treino);

            if (String.IsNullOrEmpty (treino.Name) || String.IsNullOrEmpty (treino.Description))
                throw new ArgumentNullException ("Algum Campo esta vazio");
            Repository.Add(treino);
            return treino;
            }

        public List<Treino> FindAll ( )
            {
            return Repository.FindAll ( );
            }

        public Treino? FindBy ( Treino treino )
            {
            if (treino.Id == null)
                throw new ArgumentNullException ("Id esta null");
            return Repository.Find (treino);

            }

        public Treino? FindById ( int id )
            {
            if ( id == null)
                throw (new ArgumentNullException ("id"));
            return Repository.FindById (id!);
            }

        public void Remove ( Treino treino )
            {
            if (treino == null)
                throw new ArgumentNullException ("Treino null");
            Repository.Remove (treino);
            }

        public Treino Updates ( Treino treino )
            {
            ArgumentNullException.ThrowIfNull(treino);
            if (String.IsNullOrEmpty (treino.Name) || String.IsNullOrEmpty (treino.Description))
                throw new ArgumentNullException ("Algum Campo esta vazio");
            Repository.Update (treino);
            return treino;
            }
        }
    }
