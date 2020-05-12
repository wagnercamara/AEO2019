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
        static Dictionary <Int32, String> passageiro = new Dictionary <Int32, String> ();
        static String LerString()
        {
            Boolean notNull = true;
            string nome = "";
            while(notNull == true)
            {
                nome = Console.ReadLine();
                if (nome == "")
                {
                    Console.WriteLine();
                    Console.WriteLine("É necessário um nome para prosseguir");
                    Console.Write("> ");
                }
                else
                {
                    notNull = false;
                }
            }
            return nome;
        }
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
                        Console.WriteLine("-------------------------------ATENÇÂO-------------------------------");
                        Console.WriteLine("A Entrada deste campo deve ser apenas  de numeros interios possitivos");
                        Console.Write("Tente novamente > ");
                    }    
                }
                if (x <= 0)
                {
                    Console.WriteLine("------------------------------ATENÇÂO-------------------------------");
                    Console.WriteLine("  A Entrada deste campo deve ser apenas de numeros maior que 'ZERO' ");
                    Console.Write("  Tente novamente > ");
                    numValido = true;
                }
                else
                {
                    numPositivo = false;
                }
                
            }
            return x;
        }
        static void CadastrarPassageiro()
        {
            Console.WriteLine("Por favor informe o código de embarque");
            Int32 codigoEmbarque = LerIntPositivo();
            Boolean codigoExiste = passageiro.ContainsKey(codigoEmbarque);
            
            if (codigoExiste == true)
            {
                Console.WriteLine("Erro Codigo existente: \n O codigo de embarque: ({0}) \n Correnponde ao passageiro: {1}",codigoEmbarque,passageiro[codigoEmbarque]);
                Console.WriteLine();
                Console.WriteLine("< Precione ENTER para continuar >");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\n Codigo de embarque({0}) \n Por favor Insira o Nome do Passageiro. \n ",codigoEmbarque);
                Console.Write("> ");
                string nome = LerString();

                filaAtendimento.Enqueue(codigoEmbarque);
                passageiro.Add(codigoEmbarque, nome);

                Console.WriteLine("\n Check in C.E({0}) \n Boa Viagem Sr(a) {1}.",codigoEmbarque, nome);

                Console.WriteLine();
                Console.WriteLine("< Precione ENTER para continuar >");
                Console.ReadKey();
            }
        }
        static void ChamarPassageiro()
        {
            if(filaAtendimento.Count != 0)
            {
                Int32 numeroNaFila = filaAtendimento.Dequeue(); // pegando o codigo que será embarcado
                String nomeAtendido = passageiro[numeroNaFila]; // pegando o nome do passageiro.
                passageiro.Remove(numeroNaFila);

                Console.WriteLine();
                Console.WriteLine("Embarque:");
                Console.WriteLine("{0} - {1}",numeroNaFila,nomeAtendido);
                Console.WriteLine();
                Console.WriteLine("< Precione ENTER para continuar >");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Não há Passageiros aguardado o embarque.");
                Console.WriteLine();
                Console.WriteLine("< Precione ENTER para continuar >");
                Console.ReadKey();   
            }
        }
        static void ConsultarFila()
        {
            if(filaAtendimento.Count != 0)
            {
                Int32 controleDeEmbaque = 0;

                Console.WriteLine("\nFila de Embarque:\n");
                
                var it = filaAtendimento.GetEnumerator();

                while (it.MoveNext())
                {                 
                    controleDeEmbaque ++;
                    Int32 codigo = it.Current;

                    Console.WriteLine(String.Format("{0}° {1}- {2}",controleDeEmbaque, codigo, passageiro[codigo]));
                }
                Console.WriteLine();
                Console.WriteLine("< Precione ENTER para continuar >");
                Console.ReadKey();
            }
            
            else
            {
                Console.WriteLine();
                Console.WriteLine("Não há Passageiros aguardado o embarque.");
                Console.WriteLine();
                Console.WriteLine("< Precione ENTER para continuar >");
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
                        Console.WriteLine("Opção invalida.");
                        Console.WriteLine();
                        Console.WriteLine("< Precione ENTER para continuar >");
                        Console.ReadKey();
                    }
                }
            }
        }       
        static void Main(string[] args)
        {
            MontarMenu(new String[]{
                "Cadastrar Passageiro",
                "Chamar Passageiro",
                "Consultar Fila",
                "Sair"},
                new Action[]{
                CadastrarPassageiro,
                ChamarPassageiro,
                ConsultarFila,
                }
            );
        }
    }
}

