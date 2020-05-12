using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO4Notas
{
    class Program
    {
        static Int32 LerNota(Int32 cont)
        {
            Boolean notavalida = false;
            while (notavalida == false)
            {
                Double nota = 10;
                try
                {
                    Console.WriteLine("Informe a {0}ª nota:", cont);
                    nota = Convert.ToDouble(Console.ReadLine());
                    notavalida = true;
                }
                catch
                {
                    notavalida = false;
                    Console.WriteLine("Nota inválida!");
                    Console.WriteLine();
                }
                if (nota >= 0 && nota < 7)
                {
                    throw new Exception("Reprovado!");
                }
                if (nota < 0 || nota > 10)
                {
                    notavalida = false;
                    Console.WriteLine("Nota inválida!");
                    Console.WriteLine();
                }
            }
            
            return cont;
        }
        static void Main(string[] args)
        {
            String repetir = "s";
            while (repetir == "s")
            {
                Console.Clear();
                Int32 numero = 1;
                Boolean quantidade = false;
                while (quantidade == false)
                {
                    numero = 1;
                    try
                    {
                        Console.WriteLine("Informe a quantidade de alunos:");
                        numero = Convert.ToInt32(Console.ReadLine());
                        quantidade = true;
                    }
                    catch
                    {
                        Console.WriteLine("Quantidade inválida!");
                        quantidade = false;
                    }

                    if (numero < 1)
                    {
                        Console.WriteLine("Quantidade inválida!");
                        quantidade = false;
                    }
                    Console.WriteLine();
                }

                for (Int32 cont = 1; cont <= numero; cont++)
                {
                    try
                    {
                        LerNota(cont);
                        Console.WriteLine("Aprovado!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine();
                        Console.WriteLine("Nota Computada!");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Repetir (s/n)?");
                repetir = Console.ReadLine();
            }
        }
    }
}
