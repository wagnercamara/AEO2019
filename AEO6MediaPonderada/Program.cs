using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO6MediaPonderada
{
    class Program
    {
        static Double LerRealPositivo()
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

        static void CalcularMedia(Double nota1, Double nota2)
        {
            Double mediaponderada = 0;
            mediaponderada = (((nota1 * 4) + (nota2 * 6)) / 10);
            if ((mediaponderada < 7))
            {
                throw new Exception("Reprovado!");
            }
        }

        static void Main(string[] args)
        {
            String repetir = "s";
            while (repetir == "s")
            {
                Console.Clear();
                Int32 numero = 1;
                Console.WriteLine("Informe a quantidade de alunos:");
                numero = LerInteiroPositivo();

                for (Int32 cont = 1; cont <= numero; cont++)
                {
                    Console.WriteLine("Informe a 1ª nota, com peso 4, do {0}º aluno:", cont);
                    Double nota1 = LerRealPositivo();
                    Console.WriteLine("Informe a 2ª nota, com peso 6, do {0}º aluno:", cont);
                    Double nota2 = LerRealPositivo();
                    try
                    {
                        CalcularMedia(nota1, nota2);
                        Console.WriteLine("Aprovado!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine();
                        Console.WriteLine("Média Computada!");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Repetir (s/n)?");
                repetir = Console.ReadLine();
            }
        }
    }
}