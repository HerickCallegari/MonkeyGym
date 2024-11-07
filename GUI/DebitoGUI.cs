using MonkeyGym.Data;
using MonkeyGym.Models;
using MonkeyGym.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MonkeyGym.GUI
    {
    internal class DebitoGUI
        {
        public static void Debitos ( MonkeyGymContext context )
            {
            Utils.Cabecalho (" DEBITOS ");
            int? op = -1;
            do
                {
                op = -1;
                do
                    {
                    Utils.Cabecalho (" DEBITOS ");
                    Console.WriteLine ("1. Ver todos.");
                    Console.WriteLine ("2. Ver Debito aluno.");
                    Console.WriteLine ("3. Mudar Status Debito.");
                    Console.WriteLine ("4. Gerar Debito.");
                    Console.WriteLine ("5. Modificar Debito.");
                    Console.WriteLine ("6. Remover Debito.");
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

                    } while (op != 0 && op != 1 && op != 2 && op != 3 && op != 4 && op != 5 && op != 6);

                switch (op)
                    {
                    case 1:
                        ReadGUI.VerDebitos (context);
                        break;
                    case 2:
                        VerDebitosAlunosSecretaria (context);
                        break;
                    case 3:
                        MudarStatusDebito (context);
                        break;
                    case 4:
                        CadastraDebito (context);
                        break;
                    case 5:
                        ModificarDebito (context);
                        break;
                    case 6:
                        RemoverDebitos (context);
                        break;
                    }
                } while (op != 0);

            }
        public static void MudarStatusDebito ( MonkeyGymContext context )
            {
            Utils.Cabecalho (" DEBITOS ");
            Debito debito;
            do
                {
                try
                    {
                    debito = EncontraDebito (context);
                    if (debito == null)
                        {
                        Console.WriteLine ("Debito Não encontrado.");
                        break;
                        }
                    }
                catch
                    {
                    Console.WriteLine ("Erro dedigitação.");
                    Console.WriteLine ("Pressine qualquer tecla para continuar.");
                    Console.ReadKey ();
                    break;
                    }
                Utils.Cabecalho (" DEBITOS ");
                Console.WriteLine (debito);
                Console.WriteLine ("Tem certeza que deseja Mudar o status deste debito?");
                Console.Write ("Resposta ('s' ou 'n'): ");
                if (Console.ReadKey ().KeyChar == 's')
                    {
                    if (debito!.Pago == true)
                        debito.Pago = false;
                    else
                        debito.Pago = true;
                    Console.WriteLine ("\nStatus modificado com sucesso.");
                    }
                Console.WriteLine ("\nPressione qualquer tecla para continuar.");
                Console.ReadKey ();
                return;

                } while (true);
            }
        public static Debito? EncontraDebito ( MonkeyGymContext context )
            {
            string codigo;
            DebitoService debitoService = new DebitoService (context);
            try
                {
                Utils.Cabecalho (" DEBITOS ");
                Console.WriteLine ("Qual o Codigo de barras do debito?");
                Console.Write ("Codigo: ");
                codigo = Console.ReadLine ();

                return debitoService.FindByCodigoBarras (codigo);
                }
            catch
                {
                throw;
                }
            }
        public static void CadastraDebito ( MonkeyGymContext context )
            {
            Aluno? aluno = null;
            char c;

            Utils.Cabecalho (" Debitos ");
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
                Console.WriteLine ("Aluno não encontrado. Pressino qualquer tecla para continuar.");
                Console.ReadKey ();
                return;
                }
            do
                {
                Utils.Cabecalho (" Debitos ");
                Console.WriteLine (aluno);
                Console.WriteLine ("Este é o Debito que você deseja?");
                Console.Write ("Resposta ('s' sim ou 'n' não): ");
                c = char.ToUpper (Console.ReadKey ().KeyChar);
                if (c == 'S')
                    break;
                else if (c == 'N')
                    {
                    return;
                    }
                } while (true);
            int quantidadeParcelas = 0;
            int datavencimento;
            double valor;
            string descricao;
            do
                {
                try
                    {
                    Utils.Cabecalho (" DEBITO ");
                    Console.Write ("Descrição: ");
                    descricao = Console.ReadLine ();
                    Console.Write ("Valor: ");
                    valor = double.Parse (Console.ReadLine ());
                    Console.Write ("Quantidade de Parcelas: ");
                    quantidadeParcelas = int.Parse (Console.ReadLine ());
                    Console.Write ("Dia Vencimento ('15' por exemplo): ");
                    datavencimento = int.Parse (Console.ReadLine ());
                    if (datavencimento < 1 || datavencimento > 31)
                        throw new Exception ("Dia Vencimento incorreto");
                    break;
                    }
                catch
                    {
                    Console.WriteLine ("Algum Campo não foi preenchido corretamnete.");
                    Console.ReadKey ();
                    }
                } while (true);
            do
                {
                Utils.Cabecalho (" DEBITO ");
                Console.WriteLine ("Descricao: " + descricao);
                Console.WriteLine ("Valor: " + valor);
                Console.WriteLine ("quantidade de parcelas: " + quantidadeParcelas);
                Console.WriteLine ("Dia Vencimento: " + datavencimento);
                Console.WriteLine ("As informações estao corretas?");
                Console.Write ("Resposta ('s' sim ou 'n' não): ");
                char esc = char.ToUpper (Console.ReadKey ().KeyChar);
                if (esc == 'S')
                    break;
                else if (esc == 'N')
                    return;
                } while (true);

            DateTime diaHoje = DateTime.Now;
            DateTime diaVencimento = diaHoje.AddDays (-diaHoje.Day + datavencimento);
            DebitoService debitoService = new DebitoService (context);
            Utils.Cabecalho (" DEBITOS ");
            for (int i = 0; i < quantidadeParcelas; i++)
                {
                diaVencimento = diaVencimento.AddMonths (1);
                Debito debito = new Debito ();
                debito.Descricao = descricao + " " + (i + 1) + "/" + quantidadeParcelas;
                debito.Valor = valor;
                debito.DataVencimento = diaVencimento;
                debito.DataEmissao = diaHoje;
                Console.WriteLine (debito);
                debito.Aluno = aluno;
                debitoService.Add (debito);
                Console.ReadKey ();
                }

            }
        public static void VerDebitosAlunosSecretaria ( MonkeyGymContext context )
            {
            Aluno? aluno = null;
            char c;

            Utils.Cabecalho (" Debitos ");
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
                Utils.Cabecalho (" Debitos ");
                Console.WriteLine (aluno);
                Console.WriteLine ("Este é o Debito que você deseja?");
                Console.Write ("Resposta ('s' sim ou 'n' não): ");
                c = char.ToUpper (Console.ReadKey ().KeyChar);
                if (c == 'S')
                    break;
                else if (c == 'N')
                    {
                    return;
                    }
                } while (true);

            ReadGUI.VerDebitosAluno (context, aluno);
            return;
            }
        public static void ModificarDebito ( MonkeyGymContext context )
            {
            Utils.Cabecalho (" DEBITOS ");
            Debito debito;
            do
                {
                try
                    {
                    debito = EncontraDebito (context);
                    if (debito == null)
                        {
                        Console.WriteLine ("Debito Não encontrado.");
                        break;
                        }
                    }
                catch
                    {
                    Console.WriteLine ("Erro dedigitação.");
                    Console.WriteLine ("Pressine qualquer tecla para continuar.");
                    Console.ReadKey ();
                    break;
                    }
                Utils.Cabecalho (" DEBITOS ");
                Console.WriteLine (debito);
                Console.WriteLine ("Tem certeza que deseja Mudar o status deste debito?");
                Console.Write ("Resposta ('s' ou 'n'): ");
                if (Console.ReadKey ().KeyChar == 's')
                    {
                    string descricao;
                    double valor;
                    DateTime dataEmissao;
                    DateTime dataVencimento;
                    do
                        {
                        try
                            {
                            Utils.Cabecalho (" DEBITO ");
                            Console.Write ("Descrição: ");
                            descricao = Console.ReadLine ();
                            Console.Write ("Valor: ");
                            valor = double.Parse (Console.ReadLine ());
                            Console.Write ("Data Emissão: ");
                            dataEmissao = DateTime.Parse (Console.ReadLine ());
                            Console.Write ("Data Vencimento: ");
                            dataVencimento = DateTime.Parse (Console.ReadLine ());

                            break;
                            }
                        catch
                            {
                            Console.WriteLine ("Algum Campo não foi preenchido corretamnete.");
                            Console.ReadKey ();
                            }
                        } while (true);
                    Utils.Cabecalho (" DEBITO ");
                    Console.WriteLine (debito);
                    Console.WriteLine ("--------------------------");
                    Console.WriteLine ("Descricao: " + descricao);
                    Console.WriteLine ("Valor: " + valor);
                    Console.WriteLine ("Data Emissão: " + dataEmissao);
                    Console.WriteLine ("Data Vencimento: " + dataVencimento);
                    Console.WriteLine ("\nVoce tem certeza que deseja modificar este debito?");
                    char c;
                    c = char.ToUpper (Console.ReadKey ().KeyChar);
                    if (c == 'S')
                        {
                        debito.Valor = valor;
                        debito.DataVencimento = dataVencimento;
                        debito.DataEmissao = dataEmissao;
                        debito.Descricao = descricao!;

                        DebitoService debitoService = new DebitoService (context);
                        debitoService.Updates (debito);
                        Console.WriteLine ("\nPressione qualquer tecla para continuar.");
                        Console.ReadKey ();
                        return;
                        }
                    else if (c == 'N')
                        {
                        return;
                        }
                    }
                else
                    return;

                } while (true);
            }
        public static void RemoverDebitos ( MonkeyGymContext context )
            {
            Utils.Cabecalho (" DEBITOS ");
            Debito debito;
            do
                {
                try
                    {
                    debito = EncontraDebito (context);
                    if (debito == null)
                        {
                        Console.WriteLine ("Debito Não encontrado.");
                        break;
                        }
                    }
                catch
                    {
                    Console.WriteLine ("Erro dedigitação.");
                    Console.WriteLine ("Pressine qualquer tecla para continuar.");
                    Console.ReadKey ();
                    break;
                    }
                Utils.Cabecalho (" DEBITOS ");
                Console.WriteLine (debito);
                Console.WriteLine ("Tem certeza que deseja Mudar o status deste debito?");
                Console.Write ("Resposta ('s' ou 'n'): ");
                char c = char.ToUpper(Console.ReadKey ().KeyChar);
                if ( c == 'S')
                    {
                    DebitoService debitoService = new DebitoService (context);
                    debitoService.Remove (debito);
                    Console.WriteLine ("Pressione qualquer tecla para continuar.");
                    Console.ReadKey ();
                    }
                else if (c == 'N')
                    {
                    return;
                    }

                } while (true);
            }
        }
    }
