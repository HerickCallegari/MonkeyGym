using MonkeyGym.Data;
using MonkeyGym.Models;
using MonkeyGym.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.GUI
    {
    internal class RemoverGUI
        {
        public static void RemoverUsuario ( MonkeyGymContext context )
            {
            PessoaService pessoaService = new PessoaService (context);
            do
                {
                Pessoa? pessoa = null;
                do
                    {
                    try
                        {
                        Utils.Cabecalho (" REMOVER ");
                        Console.WriteLine ("Qual a Matricula ou CPF do Usuario?");
                        Console.Write ("Resposta: ");
                        string chave = Console.ReadLine ();

                        if (pessoaService.FindByMatricula (chave) != null)
                            pessoa = pessoaService.FindByMatricula (chave);
                        else
                            pessoa = pessoaService.FindByCPF (chave);
                        }
                    catch
                        {
                        Console.WriteLine ("Usuario Nao encontrado.");
                        pessoa = null;
                        }
                    if (pessoa != null)
                        {
                        Utils.Cabecalho (" REMOVER ");
                        Console.WriteLine (pessoa);
                        Console.WriteLine ("\n\nEste o Usuario que você deseja Remover?");
                        Console.Write ("Resposta: ");

                        if (Console.ReadKey ().KeyChar != 's')
                            {
                            pessoa = null;
                            }
                        }
                    } while (pessoa == null);

                if (pessoa is Aluno)
                    {

                    Aluno aluno = (Aluno)pessoa;
                    Utils.Cabecalho (" REMOVER ");
                    Console.WriteLine (aluno);
                    Console.WriteLine ("Você tem certeza que deseja Remover o aluno?");
                    Console.Write ("Respota ('s' ou 'n') : ");
                    if (Console.ReadKey ().KeyChar == 's')
                        {
                        AlunoService alunoService = new AlunoService (context);
                        alunoService.Remove (aluno);
                        return;
                        }
                    }

                if (pessoa is Instrutor)
                    {
                    Instrutor instrutor = (Instrutor)pessoa;
                    Utils.Cabecalho (" REMOVER ");
                    Console.WriteLine (instrutor);
                    Console.WriteLine ("Você tem certeza que deseja Remover o instrutor?");
                    Console.Write ("Respota ('s' ou 'n') : ");
                    if (Console.ReadKey ().KeyChar == 's')
                        {
                        InstrutorService alunoService = new InstrutorService (context);
                        alunoService.Remove (instrutor);
                        return;
                        }
                    }

                if (pessoa is Secretaria)
                    {

                    Secretaria secretaria = (Secretaria)pessoa;
                    Utils.Cabecalho (" REMOVER ");
                    Console.WriteLine (secretaria);
                    Console.WriteLine ("Você tem certeza que deseja Remover o secretario?");
                    Console.Write ("Respota ('s' ou 'n') : ");
                    if (Console.ReadKey ().KeyChar == 's')
                        {
                        SecretariaService alunoService = new SecretariaService (context);
                        alunoService.Remove (secretaria);
                        return;
                        }
                    }


                } while (true);
            }
        }
    }
