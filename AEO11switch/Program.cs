using System;

namespace AEO11switchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32 escolha = 1;

            while (escolha != 4)
            {
                Console.Clear();
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine("|1 Matricular Aluno                |");
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine("|2 Excluir Aluno                   |");
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine("|3 Procurar Aluno                  |");
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine("|4 Sair                            |");
                Console.WriteLine("+----------------------------------+");
                Console.WriteLine("");
                Console.Write("Escolher um opção acima > ");
                escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("+----------------------------------+");
                        Console.WriteLine("|Aluno Matriculado                 |");
                        Console.WriteLine("+----------------------------------+");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("+----------------------------------+");
                        Console.WriteLine("|Excluir Aluno                     |");
                        Console.WriteLine("+----------------------------------+");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("+----------------------------------+");
                        Console.WriteLine("|Aluno Encontrado                  |");
                        Console.WriteLine("+----------------------------------+");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("+----------------------------------+");
                        Console.WriteLine("|Adeus....                         |");
                        Console.WriteLine("+----------------------------------+");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("+----------------------------------+");
                        Console.WriteLine("|ERRO Opção invalida               |");
                        Console.WriteLine("+----------------------------------+");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
