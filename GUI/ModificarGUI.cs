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
    internal class ModificarGUI
        {
        public static void ModificarUsuario(MonkeyGymContext context)
            {
            PessoaService pessoaService = new PessoaService (context);
            do
                {
                Pessoa? pessoa = null;
                do
                    {
                    try
                        {
                        Utils.Cabecalho (" Modificar ");
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
                    if ( pessoa != null)
                        {
                        Utils.Cabecalho (" MODIFICAR ");
                        Console.WriteLine (pessoa);
                        Console.WriteLine ("\n\nEste o Usuario que você deseja modificar?");
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
                    aluno = AlunoGUI.FormularioAluno(context, aluno);
                    Utils.Cabecalho (" MODIFICAR ");
                    Console.WriteLine (aluno);
                    Console.WriteLine ("Você tem certeza que deseja Modificar o aluno?");
                    Console.Write ("Respota ('s' ou 'n') : ");
                    if ( Console.ReadKey().KeyChar == 's')
                        {
                        AlunoService alunoService = new AlunoService (context);
                        alunoService.Updates(aluno);
                        return;
                        }
                    }

                if (pessoa is Instrutor)
                    {
                    Instrutor instrutor = (Instrutor)pessoa;
                    instrutor = InstrutorGUI.FormularioInstrutor(context, instrutor);
                    Utils.Cabecalho (" MODIFICAR ");
                    Console.WriteLine (instrutor);
                    Console.WriteLine ("Você tem certeza que deseja Modificar o instrutor?");
                    Console.Write ("Respota ('s' ou 'n') : ");
                    if (Console.ReadKey ().KeyChar == 's')
                        {
                        InstrutorService alunoService = new InstrutorService (context);
                        alunoService.Updates (instrutor);
                        return;
                        }
                    }

                if (pessoa is Secretaria)
                    {

                    Secretaria secretaria = (Secretaria)pessoa;
                    secretaria = SecretarioGUI.FormularioSecretaria (context, secretaria);
                    Utils.Cabecalho (" MODIFICAR ");
                    Console.WriteLine (secretaria);
                    Console.WriteLine ("Você tem certeza que deseja Modificar o secretario?");
                    Console.Write ("Respota ('s' ou 'n') : ");
                    if (Console.ReadKey ().KeyChar == 's')
                        {
                        SecretariaService alunoService = new SecretariaService (context);
                        alunoService.Updates (secretaria);
                        return;
                        }
                    }


                } while (true);
            }
        }
    }
