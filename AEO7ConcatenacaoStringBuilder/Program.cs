using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO7ConcatenacaoStringBuilder
{
    class Program
    {
        static Int32 LerInteiroPositivo()
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
            Console.WriteLine("Digite a quantidade de palavras a serem lidas");

            Int32 qntword = LerInteiroPositivo();
            String words = "Resultado Concatenado: ";
            StringBuilder wordsSB = new StringBuilder("Resultado StringBuilder: ");
            Int32 cont = 1;
            Console.WriteLine("Digite a {0}ª palavra:", cont);
            String readword = Console.ReadLine();
            wordsSB.Append(readword);
            words = words + readword;
            for (cont = 2; cont <= qntword; cont++)
            {
                Console.WriteLine();
                Console.WriteLine("Digite a {0}ª palavra:", cont);
                String readwordf = Console.ReadLine();
                wordsSB.Append(", ");
                words = words + ", ";
                wordsSB.Append(readwordf);
                words = words + readwordf;
            }
            Console.WriteLine(wordsSB);
            Console.WriteLine();
            Console.WriteLine(words);
            Console.ReadKey();

        }
    }
}