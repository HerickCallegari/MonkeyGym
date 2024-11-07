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
    internal class SecretarioGUI
        {
        public static void Inicio(MonkeyGymContext context, Secretaria secretaria)
            {
            int? op = -1;
            do
                {
                op = -1;
                do
                    {
                    Utils.Cabecalho (" SECRETARIA ");
                    Console.WriteLine ("1. Cadastro.");
                    Console.WriteLine ("2. Ver Usuario.");
                    Console.WriteLine ("3. Modificar Usuario.");
                    Console.WriteLine ("4. Deletar Usuario.");
                    Console.WriteLine ("5. Debitos.");
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

                    } while (op != 0 && op != 1 && op != 2 && op != 3 && op != 4 && op != 5);

                switch (op)
                    {
                    case 1:
                        CadastroGui.Cadastro (context);
                        break;
                    case 2:
                        ReadGUI.VerUsuarios (context);
                        break;
                    case 3:
                        ModificarGUI.ModificarUsuario(context);
                        break;
                    case 4:
                        RemoverGUI.RemoverUsuario(context);
                        break;
                    case 5:
                        DebitoGUI.Debitos (context);
                        break;
                    }
                } while (op != 0);
            }
        public static Secretaria FormularioSecretaria ( MonkeyGymContext context, Secretaria Secretaria )
            {
            Console.Write ("Nome: ");
            Secretaria.Nome = Console.ReadLine ().ToString ();
            Console.Write ("CPF: ");
            Secretaria.CPF = Console.ReadLine ().ToString ();
            Console.Write ("RG: ");
            Secretaria.RG = Console.ReadLine ().ToString ();
            Console.Write ("Endereco: ");
            Secretaria.Endereco = Console.ReadLine ().ToString ();
            Console.Write ("Data Nascimento (dd/MM/yyy): ");
            Secretaria.DataNascimento = DateTime.Parse (Console.ReadLine ().ToString ());
            Secretaria.DataContratacao = DateTime.Now;
            Console.Write ("PISS: ");
            Secretaria.PISS = Console.ReadLine ().ToString ();
            Console.Write ("Horario de Trabalho ( 8:00 - 17:30 ): ");
            Secretaria.HorarioTrabalho = Console.ReadLine ().ToString ();
            Console.Write ("Salario: ");
            Secretaria.Salario = double.Parse (Console.ReadLine ());
            Console.Write ("Senha: ");
            Secretaria.Senha = Console.ReadLine ().ToString ();
            return Secretaria;
            }

        }
    }
