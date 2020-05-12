using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO5Triangulos
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
                    Console.WriteLine();
                    Console.WriteLine("Valor Inválido, somente números Inteiros!");
                    Console.WriteLine();
                    Console.WriteLine("Informe o valor novamente:");
                }
                if (num < 1)
                {
                    valorvalido = false;
                    Console.WriteLine();
                    Console.WriteLine("Valor Inválido, somente Positivos!");
                    Console.WriteLine();
                    Console.WriteLine("Informe o valor novamente:");
                }
            }

            return num;
        }

        static void DesenharTriangulo(Int32 lado1, Int32 lado2, Int32 lado3)
        {
            Boolean etriangulo = false;
            if ((lado2 - lado3) < 0)
            {
                if ((((lado2 - lado3) * (-1)) < (lado1)) && ((lado1) < (lado2 + lado3)))
                {
                    Console.WriteLine("Triângulo Desenhado!");
                    etriangulo = true;
                }
            }
            else if ((lado2 - lado3) >= 0)
            {
                if (((lado2 - lado3) < (lado1)) && ((lado1) < (lado2 + lado3)))
                {
                    Console.WriteLine("Triângulo Desenhado!");
                    etriangulo = true;
                }
            }

            if (etriangulo == false)
            {
                throw new Exception("Os valores não respresentam um triângulo!");
            }
        }
        static void Main(string[] args)
        {
            String repetir = "s";
            while (repetir == "s")
            {
                Console.Clear();
                Int32 qnt = 1;
                Console.WriteLine("Informe a quantidade de triangulos que quer formar:");
                qnt = LerInteiroPositivo();
                Console.WriteLine();

                Int32[] ladotriangulo = new Int32[3];
                for (Int32 qnttri = 1; qnttri <= qnt; qnttri++)
                {
                    Console.WriteLine("Informe os valores, inteiros positivos, dos lados do {0}º triângulo:", qnttri);
                    Console.WriteLine();
                    for (Int32 lado = 0; lado <= 2; lado++)
                    {
                        Console.Write(" -> {0}º lado: ", (lado + 1));
                        ladotriangulo[lado] = LerInteiroPositivo();
                    }
                    Console.WriteLine();
                    try
                    {
                        DesenharTriangulo(ladotriangulo[0], ladotriangulo[1], ladotriangulo[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Repetir (s/n)?");
                repetir = Console.ReadLine();
            }
        }
    }
}