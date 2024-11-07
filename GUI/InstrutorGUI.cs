using MonkeyGym.Data;
using MonkeyGym.Entities;
using MonkeyGym.Migrations;
using MonkeyGym.Models;
using MonkeyGym.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.GUI
    {
    internal class InstrutorGUI
        {
        public static void Inicio ( MonkeyGymContext context, Instrutor instrutor )
            {
            int? op = -1;
            do
                {
                op = -1;
                do
                    {
                    Utils.Cabecalho (" INSTRUTOR ");
                    Console.WriteLine ("1. Cadastrar Treino.");
                    Console.WriteLine ("2. Treinos de Alunos.");
                    Console.WriteLine ("3. Ver Treinos.");
                    Console.WriteLine ("4. Deletar Treino.");
                    Console.WriteLine ("5. Modificar Treino.");
                    Console.WriteLine ("0. Sair.");
                    Console.Write ("Opção: ");
                    try
                        {
                        op = int.Parse (Console.ReadLine ()!);
                        }
                    catch
                        {
                        op = -1;
                        }

                    if (op == null)
                        op = -1;
                    if (op == 0)
                        return;

                    } while (op != 0 && op != 1 && op != 2 && op != 3 && op != 4 && op != 5);

                switch (op)
                    {
                    case 1:
                        CadastrarTreino (context);
                        break;
                    case 2:
                        AlunoTreinoOperacoes (context);
                        break;
                    case 3:
                        VerTreinos (context);
                        break;
                    case 4:
                        DeletarTreino (context);
                        break;
                    case 5:
                        ModificaTreino (context);
                        break;
                    }
                } while (op != 0);
            }
        public static Instrutor FormularioInstrutor ( MonkeyGymContext context, Instrutor Instrutor )
            {
            do
                {
                try
                    {
                    Utils.Cabecalho (" CADASTRO ");
                    Console.Write ("Nome: ");
                    Instrutor.Nome = Console.ReadLine ().ToString ();
                    Console.Write ("CPF: ");
                    Instrutor.CPF = Console.ReadLine ().ToString ();
                    Console.Write ("RG: ");
                    Instrutor.RG = Console.ReadLine ().ToString ();
                    Console.Write ("Endereco: ");
                    Instrutor.Endereco = Console.ReadLine ().ToString ();
                    Console.Write ("Data Nascimento (dd/MM/yyy): ");
                    Instrutor.DataNascimento = DateTime.Parse (Console.ReadLine ().ToString ());
                    Instrutor.DataContratacao = DateTime.Now;
                    Console.Write ("PISS: ");
                    Instrutor.PISS = Console.ReadLine ().ToString ();
                    Console.Write ("Horario de Trabalho ( 8:00 - 17:30 ): ");
                    Instrutor.HorarioTrabalho = Console.ReadLine ().ToString ();
                    Console.Write ("Salario: ");
                    Instrutor.Salario = double.Parse (Console.ReadLine ());


                    Console.Write ("Senha: ");
                    Instrutor.Senha = Console.ReadLine ().ToString ();

                    return Instrutor;
                    }
                catch
                    {
                    throw;
                    }
                } while (true);
            }
        public static void CadastrarTreino ( MonkeyGymContext context )
            {
            Utils.Cabecalho (" TREINO ");
            Treino treino = new Treino ();
            char c;
            try
                {

                Utils.Cabecalho (" TREINO ");
                Console.Write ("Nome do Treino: ");
                treino.Name = Console.ReadLine ();
                Console.Write ("Descrição do treino: ");
                treino.Description = Console.ReadLine ();
                }

            catch
                {
                Console.WriteLine ("Erro na digitação de algum campo. Pressione qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            do
                {
                Utils.Cabecalho (" TREINO ");
                Console.WriteLine (treino);
                Console.Write ("Resposta ('s' sim ou 'n' não): ");
                c = char.ToUpper (Console.ReadKey ().KeyChar);
                if (c == 'S')
                    {
                    TreinoService treinoService = new TreinoService (context);
                    treino = treinoService.Add (treino);
                    return;
                    }
                else if (c == 'N')
                    {
                    return;
                    }
                } while (true);

            }
        public static void VerTreinos ( MonkeyGymContext context )
            {
            TreinoService treinoService = new TreinoService (context);
            ReadGUI.Paginacao (treinoService.FindAll (), " TREINOS ");

            }
        public static void DeletarTreino ( MonkeyGymContext context )
            {
            Utils.Cabecalho (" Treinos ");
            int id;
            do
                {
                try
                    {
                    Console.WriteLine ("Qual o ID do Treino que voce deseja excluir?");
                    Console.Write ("ID: ");
                    id = int.Parse (Console.ReadLine ());
                    break;
                    }
                catch
                    {
                    return;
                    }
                } while (true);

            TreinoService treinoService = new TreinoService (context);
            Treino treino;
            try
                {
                treino = treinoService.FindById (id);
                }
            catch
                {
                Console.WriteLine ("Treino não existe.");
                Console.WriteLine ("Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            if (treino == null)
                {
                Console.WriteLine ("Treino não existe.");
                Console.WriteLine ("Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            do
                {
                Utils.Cabecalho (" TREINO ");
                Console.WriteLine (treino);
                Console.WriteLine ("\nTem certeza que deseja excluir este Treino?");
                Console.Write ("Resposta ('s' sim ou 'n' não):");
                char c;
                c = char.ToUpper (Console.ReadKey ().KeyChar);
                if (c == 'S')
                    {
                    treinoService.Remove (treino);
                    return;
                    }
                else if (c == 'N')
                    return;
                } while (true);
            }
        public static void ModificaTreino ( MonkeyGymContext context )
            {
            Utils.Cabecalho (" Treinos ");
            int id;
            char c;
            do
                {
                try
                    {
                    Console.WriteLine ("Qual o ID do Treino que voce deseja Modificar?");
                    Console.Write ("ID: ");
                    id = int.Parse (Console.ReadLine ());
                    break;
                    }
                catch
                    {
                    return;
                    }
                } while (true);

            TreinoService treinoService = new TreinoService (context);
            Treino treino;
            try
                {
                treino = treinoService.FindById (id);
                }
            catch
                {
                Console.WriteLine ("Treino não existe.");
                Console.WriteLine ("Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            if (treino == null)
                {
                Console.WriteLine ("Treino não existe.");
                Console.WriteLine ("Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            do
                {
                Utils.Cabecalho (" TREINO ");
                Console.WriteLine (treino);
                Console.WriteLine ("Este é o Treino que voce deseja modificar?");
                Console.Write ("Resposta: ");
                c = char.ToUpper (Console.ReadKey ().KeyChar);
                if (c == 'N')
                    return;
                else if (c == 'S')
                    break;
                } while (true);
            string nome;
            string descricao;
            try
                {

                Utils.Cabecalho (" TREINO ");
                Console.Write ("Nome do Treino: ");
                nome = Console.ReadLine ();
                Console.Write ("Descrição do treino: ");
                descricao = Console.ReadLine ();
                }

            catch
                {
                Console.WriteLine ("Erro na digitação de algum campo. Pressione qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }

            do
                {
                Utils.Cabecalho (" TREINO ");
                Console.WriteLine (treino);
                Console.WriteLine ("--------------------------------------------");
                Console.WriteLine ("Nome: " + nome + " Descrição: " + descricao);
                Console.WriteLine ("\nTem certeza que deseja modificar este treino?");
                Console.Write ("Resposta: ");
                c = char.ToUpper (Console.ReadKey ().KeyChar);
                if (c == 'S')
                    {
                    treino.Name = nome;
                    treino.Description = descricao;
                    treinoService.Updates (treino);
                    return;
                    }
                else if (c == 'N')
                    return;
                } while (true);

            }
        public static void AlunoTreinoOperacoes ( MonkeyGymContext context )
            {

            Aluno? aluno;
            char c;

            Utils.Cabecalho (" TREINO ALUNO ");
            try
                {
                aluno = AlunoGUI.ProcurarAluno (context);
                }
            catch
                {
                Console.WriteLine ("Campo digitado errado.");
                return;
                }
            if (aluno == null)
                {
                Console.WriteLine ("Aluno não encontrado. Pressione qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            do
                {
                Utils.Cabecalho (" TREINO ALUNO ");
                Console.WriteLine (aluno);
                Console.WriteLine ("Este é o Aluno que você deseja?");
                Console.Write ("Resposta ('s' sim ou 'n' não): ");
                c = char.ToUpper (Console.ReadKey ().KeyChar);
                if (c == 'S')
                    break;
                else if (c == 'N')
                    {
                    return;
                    }
                } while (true);
            int? op = -1;
            do
                {
                op = -1;
                do
                    {
                    Utils.Cabecalho (" ALUNO TREINO ");
                    if (aluno != null)
                        Console.WriteLine ("Aluno: " + aluno.Nome);
                    Console.WriteLine ("1. Cadastrar Treino.");
                    Console.WriteLine ("2. Treinos de Alunos.");
                    Console.WriteLine ("3. Remover Treino.");
                    Console.WriteLine ("4. Ver Treinos.");
                    Console.WriteLine ("0. Sair.");
                    Console.Write ("Opção: ");
                    try
                        {
                        op = int.Parse (Console.ReadLine ()!);
                        }
                    catch
                        {
                        op = -1;
                        }

                    if (op == null)
                        op = -1;
                    if (op == 0)
                        return;

                    } while (op != 0 && op != 1 && op != 2 && op != 3 && op != 4 && op != 5);

                switch (op)
                    {
                    case 1:
                        GerarAlunoTreino (context, aluno);
                        break;
                    case 2:
                        ReadGUI.VerTreinosAluno (context, aluno);
                        break;
                    case 3:
                        RemoverTreino (context, aluno);
                        break;
                    case 4:
                        VerTreinos (context);
                        break;
                    }
                } while (op != 0);
            }

        private static void RemoverTreino ( MonkeyGymContext context, Aluno? aluno )
            {

            int id;
            do
                {
                Utils.Cabecalho (" REMOVE TREINO ");
                try
                    {
                    Console.WriteLine ("Qual o ID do Treino que voce deseja remover?");
                    Console.Write ("ID: ");
                    id = int.Parse (Console.ReadLine ());
                    break;
                    }
                catch
                    {
                    return;
                    }
                } while (true);

            TreinoService treinoService = new TreinoService (context);
            Treino treino;
            try
                {
                treino = treinoService.FindById (id);
                }
            catch
                {
                Console.WriteLine ("Treino não existe.");
                Console.WriteLine ("Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            if (treino == null)
                {
                Console.WriteLine ("Treino não existe.");
                Console.WriteLine ("Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            AlunoTreinoService alunoTreinoService = new AlunoTreinoService (context);
            AlunoTreino alunoTreino;
            try
                {
                alunoTreino = alunoTreinoService.FindBy (aluno, treino);
                }
            catch
                {
                Console.WriteLine ("Este aluno não tem este treino.");
                Console.WriteLine ("Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            if (alunoTreino == null)
                {
                Console.WriteLine ("Este aluno não tem este treino.");
                Console.WriteLine ("Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }

            do
                {
                Utils.Cabecalho (" REMOVER TREINO");
                Console.WriteLine ("Grupo: " + alunoTreino.GrupoTreino + " Nome: " + treino.Name + " Descrição: " + treino.Description);
                char c;
                Console.WriteLine ("Tem certeza que deseja remover este treino?");
                Console.Write ("Resposta ('s' sim ou 'n' não): ");
                c = char.ToUpper (Console.ReadKey ().KeyChar);
                if (c == 'S')
                    {
                    alunoTreinoService.Remove (alunoTreino);
                    return;
                    }
                else if (c == 'N')
                    return;
                } while (true);



            }

        private static void GerarAlunoTreino ( MonkeyGymContext context, Aluno aluno )
            {

            int id;
            do
                {
                Utils.Cabecalho (" TREINO ALUNO ");
                try
                    {
                    Console.WriteLine ("Qual o ID do Treino que voce deseja adcionar?");
                    Console.Write ("ID: ");
                    id = int.Parse (Console.ReadLine ());
                    break;
                    }
                catch
                    {
                    return;
                    }
                } while (true);

            TreinoService treinoService = new TreinoService (context);
            Treino treino;
            try
                {
                treino = treinoService.FindById (id);
                }
            catch
                {
                Console.WriteLine ("Treino não existe.");
                Console.WriteLine ("Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            if (treino == null)
                {
                Console.WriteLine ("Treino não existe.");
                Console.WriteLine ("Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            AlunoTreinoService alunoTreinoService = new AlunoTreinoService (context);
            AlunoTreino alunoTreino = new AlunoTreino ();


            if (alunoTreinoService.FindBy (aluno, treino) != null)
                {
                Console.WriteLine ("Este aluno ja tem este treino.");
                Console.WriteLine ("Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            alunoTreino.Treino = treino;
            alunoTreino.Aluno = aluno;
            do
                {
                Utils.Cabecalho (" ALUNO TREINO ");
                Console.WriteLine ("Aluno: " + aluno.Nome);
                Console.WriteLine ("Treino: " + treino.Name + " Descrição: " + treino.Description);
                Console.WriteLine ("Qual o grupo deste Treino? ( digite qualquer letra ou numero)");
                Console.Write ("Resposta (Exemplo: 'A'): ");
                char grupoTreino;
                grupoTreino = Console.ReadKey ().KeyChar;
                if (grupoTreino == ' ')
                    {
                    Console.WriteLine ("Digite qualquer letra ou numero.");
                    Console.WriteLine ("Pressione qualquer tecla para continuar.");
                    Console.ReadKey ();
                    }
                else
                    {
                    alunoTreino.GrupoTreino = grupoTreino;
                    alunoTreinoService.Add (alunoTreino);
                    break;
                    }
                } while (true);
            }
        }
    }
