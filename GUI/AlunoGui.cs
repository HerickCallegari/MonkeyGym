using MonkeyGym.Data;
using MonkeyGym.Entities;
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
    internal class AlunoGUI ( )
        {
        public static void Inicio ( MonkeyGymContext contexto, Aluno aluno )
            {
            int? op = -1;
            do
                {
                op = -1;
                do
                    {
                    Utils.Cabecalho (" ALUNO ");
                    Console.WriteLine ("1. Ver Treinos.");
                    Console.WriteLine ("2. Ver Debitos.");
                    Console.WriteLine ("3. Ver Dados.");
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

                    } while (op != 0 && op != 1 && op != 2 && op != 3);

                switch (op)
                    {
                    case 1:
                        ReadGUI.VerTreinosAluno (contexto, aluno);
                        break;
                    case 2:
                        ReadGUI.VerDebitosAluno (contexto, aluno);
                        break;
                    case 3:
                        VerDados (contexto, aluno);
                        break;
                    }
                } while (op != 0);
            }
        public static void VerDados ( MonkeyGymContext context, Aluno aluno )
            {
            Utils.Cabecalho (" Perfil ");
            Console.WriteLine ("\n" + aluno);
            Console.WriteLine ("\n\nPressione qualquer tecla para sair.\n\n");
            Console.Read ();
            }
        public static Aluno FormularioAluno ( MonkeyGymContext context, Aluno aluno )
            {
            do
                {
                try
                    {
                    Utils.Cabecalho (" FORMULARIO ALUNO ");
                    Console.Write ("Nome: ");
                    aluno.Nome = Console.ReadLine ().ToString ();
                    Console.Write ("CPF: ");
                    aluno.CPF = Console.ReadLine ().ToString ();
                    Console.Write ("RG: ");
                    aluno.RG = Console.ReadLine ().ToString ();
                    Console.Write ("Endereco: ");
                    aluno.Endereco = Console.ReadLine ().ToString ();
                    Console.Write ("Data Nascimento (dd/MM/yyyy): ");
                    aluno.DataNascimento = DateTime.Parse (Console.ReadLine ().ToString ());
                    aluno.DataInicio = DateTime.Now;

                    Console.Write ("Senha: ");
                    aluno.Senha = Console.ReadLine ().ToString ();
                    return aluno;
                    }
                catch
                    {
                    throw;
                    }
                } while (true);
            }

        public static Aluno? ProcurarAluno ( MonkeyGymContext context )
            {
            AlunoService alunoService = new AlunoService (context);
            Aluno? aluno = null;
            try
                {
                Console.WriteLine ("Qual a Matricula ou CPF do Aluno?");
                Console.Write ("Resposta: ");
                string chave = Console.ReadLine ();

                if (alunoService.FindByMatricula (chave) != null)
                    aluno = alunoService.FindByMatricula (chave);
                else
                    aluno = alunoService.FindByCPF (chave);
                }
            catch
                {
                throw new Exception ("Campo digitado errado.");
                }
            return aluno;
            }
        }
    }


