using MonkeyGym.Data;
using MonkeyGym.Entities;
using MonkeyGym.Models;
using MonkeyGym.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace MonkeyGym.GUI
    {
    internal class ReadGUI
        {
        public static void VerUsuarios ( MonkeyGymContext context )
            {
            PessoaService pessoaService = new PessoaService(context);
            List<Pessoa> pessoas = pessoaService.FindAll ();
            Paginacao<Pessoa> (pessoas, " LISTA USUARIOS ");
            }
        public static void VerTreinosAluno ( MonkeyGymContext context, Aluno aluno )
            {
            AlunoService alunoService = new AlunoService (context);

            List<AlunoTreino> alunoTreinos = alunoService.VerTreinos (aluno);
            List<Char> grupoTreinos = new List<Char> ();
            foreach (AlunoTreino at in alunoTreinos)
                {
                grupoTreinos.Add (at.GrupoTreino);
                }


            grupoTreinos.Distinct ();
            if (grupoTreinos.Count == 0)
                return;
            char op;
            do
                {
                op = '.';
                Utils.Cabecalho (" Treinos ");
                Console.WriteLine ("Selecione o Grupo de Treinos:");
                foreach (char c in grupoTreinos)
                    {
                    Console.WriteLine ("Grupo " + c);
                    }
                try
                    {
                    Console.Write ("Opção: ");
                    op = char.ToUpper (Console.ReadKey ().KeyChar);
                    }
                catch (Exception e)
                    {
                    op = '.';
                    }
                if (op == '=')
                    return;
                } while (op != '=' && !grupoTreinos.Contains (op));

            Utils.Cabecalho (" Grupo " + op + " ");
            TreinoService treinoService = new TreinoService (context);
            List<Treino> treinosDoGrupo = new List<Treino> ();
            foreach (var item in alunoTreinos)
                {
                if (item.GrupoTreino == op)
                    {
                    treinosDoGrupo.Add (treinoService.FindById (item.TreinoId)!);
                    }
                }
            int? op2;
            int tamanhoLista = treinosDoGrupo.Count ();
            Paginacao (treinosDoGrupo, " LISTA TREINOS ");

            }
        public static void VerDebitosAluno ( MonkeyGymContext context, Aluno aluno )
            {
            char op;
            int? opc = -1;

            AlunoService service = new AlunoService (context);
            do
                {
                opc = -1;
                do
                    {
                    try
                        {
                        Utils.Cabecalho (" DEBITOS ");
                        Console.WriteLine ("1. Todos.");
                        Console.WriteLine ("2. Abertos.");
                        Console.WriteLine ("3. Pagos.");
                        Console.WriteLine ("0. Sair.");
                        Console.Write ("Opção: ");
                        opc = int.Parse (Console.ReadLine ()!);
                        }catch
                        {
                        opc = -1;
                        }

                    if (opc == null)
                        opc = -1;

                    if (opc == 0)
                        return;

                    } while (opc != 3 && opc != 1 && opc != 2);
                List<Debito> debitos;
                if (opc == 1)
                    debitos = service.FindAllDebito (aluno);
                else if (opc == 2)
                    debitos = service.FindAllDebito (aluno).Where (d => d.Pago == false).ToList ();
                else
                    debitos = service.FindAllDebito (aluno).Where (d => d.Pago == true).ToList ();

                Paginacao<Debito> (debitos, " LISTA DEBITOS ");
                
                } while (opc != 0);
            }
        public static void Paginacao<T> ( List<T> lista, string cabecalho)
            {
            Utils.Cabecalho(cabecalho);
            int tamanhoLista = lista.Count;
            int? op;
            for (int i = 0; i < tamanhoLista; i++)
                {
                if (i < 0)
                    i = 0;

                    
                Console.WriteLine ("\n---------- " + (i + 1) + " ---------------");
                Console.WriteLine (lista[i]);
                Console.WriteLine ("--------------------------------");

                if ((i + 1) % 3 == 0 && i + 1 < tamanhoLista)
                    {
                    if (i >= 5)
                        Console.WriteLine ("(-) Voltar");
                    Console.WriteLine ("(+) Ver Mais");
                    Console.WriteLine ("(=) sair");
                    op = Console.ReadKey ().KeyChar;
                    if (op == '-' && i >= 5)
                        i = i - 6;
                    else if (op == '=')
                        break;
                    else if (op != '+')
                        i = i - 3;
                    Console.Clear ();
                    Utils.Cabecalho (cabecalho);
                    }
                else if (i + 1 == tamanhoLista && i > 2)
                    {
                    Console.WriteLine ("(-) Voltar");
                    Console.WriteLine ("(=) sair");
                    op = Console.ReadKey ().KeyChar;
                    if (op == '-')
                        i = i - (6 - ((i + 1) % 3));
                    else if (op == '=')
                        break;
                    else if (op != '-')
                        {
                        if ((i + 1) % 3 == 0)
                            i = i - 3;
                        else if ((i + 1) % 3 == 1)
                            i = i - 1;
                        else
                            i = i - 2;
                        }
                    Console.Clear ();
                    Utils.Cabecalho (cabecalho);
                    }
                else if (tamanhoLista <= 2)
                    {
                    Console.WriteLine ("(=) sair");
                    op = Console.ReadKey ().KeyChar;
                    if (op == '=')
                        break;
                    else if (op != '=')
                        i = -1;
                    Console.Clear ();
                    Utils.Cabecalho (cabecalho);
                    }
                }
            Console.Clear ();
            }
        public static void VerDebitos ( MonkeyGymContext context )
            {
            DebitoService debitoService = new DebitoService (context);
            List<Debito> Debitos = debitoService.FindAll ();
            ReadGUI.Paginacao<Debito> (Debitos, " Debitos ");
            }
        }
    }