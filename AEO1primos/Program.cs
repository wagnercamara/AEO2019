using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO1primos
{
    class Program
    {
        static Boolean naoprimo(Int32 numberint)
        {
            if (numberint == 1)
            {
                return true;
            }
            else
            {
                for (Int32 cont = 2; cont < numberint; cont++)
                {
                    if (numberint % cont == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            string repetir = "s";
            while (repetir == "s")
            {
                Console.Clear();
                Console.WriteLine("Informe um número inteiro para descobrir se é primo:");
                Int32 numberint = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (naoprimo(numberint) == false)
                {
                    Console.WriteLine("O número {0} é primo!", numberint);
                }
                else
                {
                    Console.WriteLine("O número {0} não é primo!", numberint);
                }
                Console.WriteLine();
                Console.WriteLine("Deseja realizar novamente (s/n) ?");
                repetir = (Console.ReadLine());
            }
        }
    }
}