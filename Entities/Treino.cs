using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.Entities
    {
    internal class Treino
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AlunoTreino> Alunos { get; set; } = new List<AlunoTreino> ();
        public Treino () { }
        public Treino (int id, string name, string descripiton) 
            {
            Id = id;
            Name = name;
            Description = descripiton;
            }
        public Treino ( string name, string descripiton )
            {
            Name = name;
            Description = descripiton;
            }

        public override string ToString ( )
            {
            return "ID: " + Id + " Nome: " + Name + " Descrição: " + Description;
            }
        }
    }
