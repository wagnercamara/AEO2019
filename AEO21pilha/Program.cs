using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO21pilha
{
    class Program
    {   
        static Stack <Int32> pilhaEstoque = new Stack <Int32>();
        static Dictionary <Int32, String> brinquedos = new Dictionary <Int32, String> ();
        static Int32 LerIntPositivo()
        {
            Int32 x = 0;
            Boolean numValido = true;
            Boolean numPositivo = true;

            while (numPositivo == true)
            {
                while (numValido == true)
                {
                    try
                    {
                        x = Convert.ToInt32(Console.ReadLine());
                        numValido = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Por favor insira um numero inteiro maior que Zero...");
                    }    
                }
                if (x <= 0)
                {
                    Console.WriteLine("O numero informar tem que ser maior que 'Zero'...");
                    numValido = true;
                }
                else
                {
                    numPositivo = false;
                }
                
            }
            return x;
        }
        static void ArmazenarBrinquedo()
        {
            Int32 tamanhoDaPilha = pilhaEstoque.Count;
            Int32 proximoDaPilha = tamanhoDaPilha + 1;

            DateTime d = new DateTime();

            Console.WriteLine("Por favor Insira o Nome do Brinquedo.");
            string nome = Console.ReadLine(); // nome do brinquedo

            pilhaEstoque.Push(proximoDaPilha);

            brinquedos.Add(proximoDaPilha, nome);

            Console.WriteLine();
            Console.WriteLine("({0}) foi Armazenado. {1}", nome,d);

            Console.WriteLine();
            Console.WriteLine("<>Precione ENTER para continuar");
            Console.ReadKey();
        }
        static void LiberarBrinquedo()
        {
            if(brinquedos.Count != 0)
            {
                Int32 numeroNaFila = pilhaEstoque.Pop();
                Console.WriteLine("{0} foi removido do estoque",brinquedos[numeroNaFila]);
                brinquedos.Remove(numeroNaFila);

                Console.WriteLine();
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("<>Não há Brinquedos no Estoque.");
                Console.WriteLine();
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();   
            }
            
        }
        static void ConsultarEstoque()
        {
            if(brinquedos.Count != 0)
            {
                Int32 i = 0;
                Int32 saida = 0;
                for(i = brinquedos.Count; i != 0; i--)
                {
                    saida ++;
                    Console.WriteLine(String.Format("{0}° {1}", saida, brinquedos[i]));
                }
                Console.WriteLine();
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("<>Não há Brinquedos no Estoque.");
                Console.WriteLine();
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }

        }
        static void MontarMenu(String[] opcao, Action[] metodo)
        {
            if(opcao.Length > 0)
            {
                Boolean imprimirMenu = true;
                Int32 opcaoEscolhida = 0;
                StringBuilder x = new StringBuilder();
                x.Append(1).Append("-").Append(opcao[0]).Append("\n");
                for(Int32 i = 2; i <= opcao.Length;i++)
                {
                    x.Append(i).Append("-").Append(opcao[i-1]).Append("\n");
                }

                while(imprimirMenu == true)
                {
                    Console.Clear();
                    Console.WriteLine(x);
                    opcaoEscolhida = LerIntPositivo();

                    if(opcaoEscolhida  < opcao.Length)
                    {
                        metodo[opcaoEscolhida - 1]();
                    }
                    else if (opcaoEscolhida == opcao.Length)
                    {
                        Console.WriteLine("bye..");
                        imprimirMenu = false;
                    }
                    else
                    {
                        Console.WriteLine("Ops.. opção invalida.");
                        Console.WriteLine();
                        Console.WriteLine("<>Precione ENTER para continuar");
                        Console.ReadKey();
                    }
                }
            }
        }       
        static void Main(string[] args)
        {
            MontarMenu(new String[]{
                "Armazenar Brinquedo",
                "Liberar Brinquedo",
                "Consultar Estoque",
                "Sair"},
                new Action[]{
                ArmazenarBrinquedo,
                LiberarBrinquedo,
                ConsultarEstoque,
                }
            );
        }
    }
}
