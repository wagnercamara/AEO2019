using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO2fatorial
{
    class Program
    {
        static void Main(string[] args)
        {
            string repetir = "s";
            while (repetir == "s")
            {
                Console.Clear();
                Console.WriteLine("Informe um número inteiro, para saber seu fatorial:");
                Int32 numberint = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                BigInteger resultado = 1;
                Console.WriteLine("O resulta do fatorial de {0} é:", numberint);
                for (Int32 mult = numberint; mult > 1; mult--)
                {
                    resultado = (resultado * mult);
                }
                Console.WriteLine(" = {0}", resultado);
                Console.WriteLine();
                Console.WriteLine("Deseja realizar novamente (s/n) ?");
                repetir = (Console.ReadLine());
            }
        }
    }
}