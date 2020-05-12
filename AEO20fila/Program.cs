using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AEO20fila
{
    class Program
    {
        static Queue <Int32> filaAtendimento = new Queue<Int32>();
        static Int32 controleFila = 0;
        static Dictionary <Int32, String> cliente = new Dictionary <Int32, String> ();
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
        static void LiberarTicket()
        {
            Int32 tamanhoDaFila = filaAtendimento.Count;
            Int32 proximoDaFila = tamanhoDaFila + 1;

                 // linha abaixo: incere um numero diferente para não precisar limpar a fila depois
            controleFila = controleFila + 1 ;

            Console.WriteLine("Por favor Insira o Nome do Cliente.");
            string nome = Console.ReadLine();

            filaAtendimento.Enqueue(controleFila);

            cliente.Add(proximoDaFila, nome);

            Console.WriteLine();
            Console.WriteLine("O Sr(a) {0} foi incerido na fila", nome);

            Console.WriteLine();
            Console.WriteLine("<>Precione ENTER para continuar");
            Console.ReadKey();
        }
        static void AtenderTicket()
        {
            if(cliente.Count != 0)
            {
                Int32 numeroNaFila = filaAtendimento.Dequeue();
                String nomeAtendido = cliente[1];
                cliente.Remove(1);
                for (Int32 i = 1; i <= cliente.Count; i++)
                {
                    cliente.Add(i, cliente[i + 1]);
                    cliente.Remove(i + 1);
                }

                Console.WriteLine("O Sr(a) {0} foi atendido",nomeAtendido);
                Console.WriteLine();
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("<>Não há pessoas na fila.");
                Console.WriteLine();
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();   
            }
            
        }
        static void ConsultarFila()
        {
            if(cliente.Count != 0)
            {
                var it = cliente.GetEnumerator();

                while (it.MoveNext())
                {
                    Console.WriteLine(String.Format("{0}° {1}", it.Current.Key, it.Current.Value));
                }
                Console.WriteLine();
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("<>Não há pessoas na fila.");
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
                "Liberar Ticket",
                "Atender Ticket",
                "Consultar Fila",
                "Sair"},
                new Action[]{
                LiberarTicket,
                AtenderTicket,
                ConsultarFila,
                }
            );
        }
    }
}
