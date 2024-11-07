using MonkeyGym.Data;
using MonkeyGym.Entities;
using MonkeyGym.Models;
using MonkeyGym.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.GUI
    {
    internal class CadastroGui
        {
        public static void Cadastro ( MonkeyGymContext context )
            {
            int? op = -1;
            do
                {
                op = -1;
                do
                    {
                    Utils.Cabecalho (" CADASTRO ");
                    Console.WriteLine ("1. Aluno.");
                    Console.WriteLine ("2. Instrutor.");
                    Console.WriteLine ("3. Secretario.");
                    Console.WriteLine ("0. Sair.");
                    Console.Write ("Opção: ");
                    try
                        {
                        op = int.Parse (Console.ReadLine ()!);
                        }
                    catch (Exception e)
                        {
                        op = -1;
                        }

                    if (op == null)
                        op = -1;
                    if (op == 0)
                        return;

                    } while (op != 0 && op != 1 && op != 2 && op != 3 && op != 4);

                switch (op)
                    {
                    case 1:
                        CadastroAluno (context);
                        break;
                    case 2:
                        CadastroInstrutor (context);
                        break;
                    case 3:
                        CadastroSecretario (context);
                        break;
                    }
                } while (op != 0);

            }
        public static void CadastroAluno ( MonkeyGymContext context )
            {
            AlunoService alunoService = new AlunoService (context);
            do
                {
                try
                    {

                    Aluno aluno = new Aluno ();
                    aluno = AlunoGUI.FormularioAluno (context, aluno);
                    aluno = alunoService.Add (aluno);
                    Console.WriteLine ("\n-------------------------\n");
                    Console.WriteLine (aluno);
                    Console.WriteLine ("Pressione qualquer tecla para continuar.");
                    Console.ReadKey ();
                    return;

                    }
                catch (Exception ex)
                    {
                    Console.WriteLine (ex.ToString ());
                    Console.WriteLine ("Algum campo foi preenchido de maneira incorreta ou este aluno ja existe.");
                    }
                Console.Read ();

                } while (true);
            }
        public static void CadastroInstrutor ( MonkeyGymContext context )
            {
            InstrutorService InstrutorService = new InstrutorService (context);
            do
                {
                try
                    {
                    Utils.Cabecalho (" CADASTRO ");
                    Instrutor Instrutor = new Instrutor ();
                    Instrutor = InstrutorGUI.FormularioInstrutor (context, Instrutor);
                    Instrutor = InstrutorService.Add (Instrutor);
                    Console.WriteLine ("\n-------------------------\n");
                    Console.WriteLine (Instrutor);
                    Console.WriteLine ("Pressione qualquer tecla para continuar.");
                    Console.ReadKey ();
                    return;

                    }
                catch
                    {
                    //Console.WriteLine (ex.ToString ());
                    Console.WriteLine ("Algum campo foi preenchido de maneira incorreta ou este aluno ja existe.");
                    }
                Console.Read ();

                } while (true);
            }

        public static void CadastroSecretario ( MonkeyGymContext context )
            {
            SecretariaService SecretariaService = new SecretariaService (context);
            do
                {
                try
                    {
                    Utils.Cabecalho (" CADASTRO ");
                    Secretaria Secretaria = new Secretaria ();

                    Secretaria = SecretarioGUI.FormularioSecretaria (context, Secretaria);

                    Secretaria = SecretariaService.Add (Secretaria);
                    Console.WriteLine ("\n-------------------------\n");
                    Console.WriteLine (Secretaria);
                    Console.WriteLine ("Pressione qualquer tecla para continuar.");
                    Console.ReadKey ();
                    return;

                    }
                catch
                    {
                    Console.WriteLine ("Algum campo foi preenchido de maneira incorreta ou este aluno ja existe.");
                    }
                Console.ReadKey ();

                } while (true);

            }
        }
    }
