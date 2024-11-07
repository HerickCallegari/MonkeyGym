using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyGym.GUI
    {
    internal class Utils
        {
        public static void Cabecalho ( string str )
            {
            Console.Clear ();
            string str_traco = "---------------------------------";
            int str_tamanho = str_traco.Length;

            int quantidadeAntes = (str_tamanho - str.Length) / 2;
            int quantidadeDepois = str_tamanho - str.Length - quantidadeAntes;

            string traco_antes = new string ('-', quantidadeAntes);
            string traco_depois = new string ('-', quantidadeDepois);

            Console.WriteLine (str_traco);
            Console.WriteLine (traco_antes + str + traco_depois);
            Console.WriteLine (str_traco);
            }
        }
    }
