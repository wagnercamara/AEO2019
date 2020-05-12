using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerNumero
{
    public class Numero
    {
        public static Double LerRealPositivo()
        {
            Int32 num = 1;
            Boolean valorvalido = false;
            while (valorvalido == false)
            {
                num = 10;
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    valorvalido = true;
                }
                catch
                {
                    valorvalido = false;
                    Console.WriteLine("Valor Inválido, somente números Reais!");
                    Console.WriteLine();
                    Console.WriteLine("Informe o valor novamente:");
                }
                if (num < 0 || num > 10)
                {
                    valorvalido = false;
                    Console.WriteLine("Nota inválida,  somente números entre 0 e 10!");
                    Console.WriteLine();
                    Console.WriteLine("Informe o valor novamente:");
                }
            }

            return num;
        }

        public static Int32 LerInteiroPositivo()
        {
            Int32 num = 1;
            Boolean valorvalido = false;
            while (valorvalido == false)
            {
                num = 1;
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    valorvalido = true;
                }
                catch
                {
                    valorvalido = false;
                    Console.WriteLine("Valor Inválido, somente números Inteiros!");
                    Console.WriteLine();
                    Console.WriteLine("Informe o valor novamente:");
                }
                if (num < 1)
                {
                    valorvalido = false;
                    Console.WriteLine("Valor Inválido, somente Positivos!");
                    Console.WriteLine();
                    Console.WriteLine("Informe o valor novamente:");
                }
            }

            return num;
        }

        static void Main(string[] args)
        {
        }
    }
}
