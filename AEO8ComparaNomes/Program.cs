using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LerNumero;

namespace AEO8ComparaNomes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe a quantidade de nomes a serem comparados:");
            Int32 qnt = Numero.LerInteiroPositivo();

            Console.WriteLine("Informe o 1º nome:");
            String nome = Console.ReadLine();
            String maior = nome;
            String menor = nome;
            for (Int32 cont = 2; cont <= qnt; cont++)
            {
                Console.WriteLine();
                Console.WriteLine("Informe o {0}º nome:", cont);
                nome = Console.ReadLine();

                if (nome.CompareTo(menor) == -1)
                {
                    menor = nome;
                }
                else if (nome.CompareTo(maior) == 1)
                {
                    maior = nome;
                }
            }
            Console.WriteLine();
            Console.WriteLine("menor e MAIOR nomes lidos:");
            Console.WriteLine(menor.ToLower());
            Console.WriteLine(maior.ToUpper());
            Console.ReadLine();
        }

    }

}