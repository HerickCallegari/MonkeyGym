using Azure.Identity;
using MonkeyGym.Data;
using MonkeyGym.Entities;
using MonkeyGym.GUI;
using MonkeyGym.Models;
using MonkeyGym.Repositories;
using MonkeyGym.Services;

namespace MonkeyGym
    {
    internal class Program
        {
        static void Main ( string[] args )
            {
            MonkeyGymContext context = new MonkeyGymContext ();
            if (context.Secretarias.ToList().Count == 0)
                {
                SecretariaService secretariaService = new SecretariaService(context);
                Secretaria Master = new Secretaria (0, "000", "Master", "---", "---", DateTime.Now, "---", "123", "---", DateTime.Now, "---", 0);
                secretariaService.Add (Master);
                }
            var pessoa = Login.LoginForm (context);



            if (pessoa is Aluno)
                {
                Aluno aluno = (Aluno)pessoa;

                AlunoGUI.Inicio (context, aluno);
                }
            if ( pessoa is Secretaria) 
                { 
                Secretaria secretaria = (Secretaria)pessoa;

                SecretarioGUI.Inicio (context, secretaria);
                }
            if ( pessoa is Instrutor)
                {
                Instrutor instrutor = (Instrutor)pessoa;
                
                InstrutorGUI.Inicio (context, instrutor);
                }
            
            
            }
        }
    }
