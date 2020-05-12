using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO3Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            String repete = "s";
            while (repete == "s")
            {
                Console.Clear();
                Int32 numero = 0;
                Int32 resultado = 0;
                Boolean leitura = false;
                while (leitura == false)
                {
                    numero = 1;
                    Console.WriteLine("Informe um Número Inteiro Positivo, referente a posição da sequência de Fibonacci:");
                    try
                    {
                        numero = Convert.ToInt32(Console.ReadLine());
                        leitura = true;
                    }
                    catch
                    {
                        Console.WriteLine("VALOR INVÁLIDO!");
                        leitura = false;
                    }
                    if (numero < 1)
                    {
                        Console.WriteLine("VALOR INVÁLIDO! SOMENTE POSITIVOS!");
                        leitura = false;
                    }
                    Console.WriteLine();
                }
                
                if (numero == 1)
                {
                    Console.WriteLine("O {0}º número da sequência de Fibonacci é : {1}", numero, resultado);
                }
                else
                {
                    resultado = 1;
                    Int32 troca = 0;
                    for (Int32 cont = 2; cont < numero; cont++)
                    {
                        Int32 resultadoant = troca;
                        troca = resultado;
                        resultado = resultado + resultadoant;
                    }

                    Console.WriteLine("O {0}º número da sequência de Fibonacci é : {1}", numero, resultado);
                }
                Console.WriteLine();
                Console.WriteLine("Deseja repetir (s/n)?");
                repete = Console.ReadLine();
            }
        }
    }
}