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
    internal class Login
        {
        public static Pessoa LoginForm ( MonkeyGymContext context )
            {
            
            PessoaService pessoaService = new PessoaService ( context );
            string? login ;
            string?  ERRO ;
            string? senha ;
            Pessoa? pessoa;
            do
                {
                ERRO = null;
                senha = null;
                pessoa = null;
                do
                    {
                    Utils.Cabecalho (" MONKEY GYM ");
                    ERRO = null;
                    Console.Write ("Login (Matricula ou CPF): ");
                    login = Console.ReadLine ()!;

                    try
                        {
                        if (pessoaService.FindByMatricula (login) != null)
                            pessoa = pessoaService.FindByMatricula (login);
                        else
                            pessoa = pessoaService.FindByCPF (login);
                        if (pessoa == null)
                            {
                            ERRO = "Matricula não encontrada";
                            }
                        }
                    catch (Exception e)
                        {
                        ERRO = "A matricula não pode estar vazia.";
                        }

                    if (!string.IsNullOrEmpty (ERRO))
                        {
                        Console.WriteLine (ERRO + " Digite novamente ( Pressione qualquer tecla )");
                        Console.ReadKey ();
                        }
                    } while (pessoa == null);

                Utils.Cabecalho (" MONKEY GYM ");
                Console.WriteLine ("Login (Matricula ou CPF): " + login);
                Console.Write ("Senha : ");
                senha = Console.ReadLine ()!;

                if (string.IsNullOrEmpty(senha))
                    {
                    Console.WriteLine ("A senha esta vazia. ( Aperte qualquer tecla )");
                    Console.Read ();
                    }

                else if (pessoa.Senha != senha)
                    {
                    Console.WriteLine ("Senha incorreta. ( Aperte qualquer tecla )");
                    Console.Read ();
                    }

                } while (pessoa.Senha != senha);
                
                return pessoa;
            }
        }
    }
