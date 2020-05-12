using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO23conta2
{
    class Program
    {
        static List<Conta> contas = new List<Conta>();

        public static List<Conta> Contas { get => contas; set => contas = value; }

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
        static Double LerRealPositivo()
        {
            Double x = 0;
            Boolean numValido = true;
            Boolean numPositivo = true;

            while (numPositivo == true)
            {
                while (numValido == true)
                {
                    try
                    {
                        string y = Console.ReadLine();
                        x = Convert.ToDouble(y.Replace(".",",")); // padronizando entrada de numero real.
                        numValido = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Por favor insira um numero real maior que Zero...");
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
        static void AbrirConta()
        {
            Console.WriteLine(@"
            +----------------------------------------------+
            |                Abertura de conta             |
            +----------------------------------------------+");
            
            Console.WriteLine("Informe o numero da conta");
            Int32 NConta = LerIntPositivo();
            Conta c1 = new Conta(NConta);

            if (contas.Contains(c1))
            {
                Console.WriteLine("Conta já existe");
                Console.ReadKey();
            }
            else
            {
            Contas.Add(c1); 
            Console.WriteLine("Conta Registrada");
            Console.ReadKey();
            }         
        }
        static void Sacar()
        {
            Console.WriteLine(@"
            +----------------------------------------------+
            |                      Seque                   |
            +----------------------------------------------+");
            Console.WriteLine("Informe o numero da conta");
            Int32 NConta = LerIntPositivo();
            Conta c1 = new Conta(NConta);
            Int32 posicao = contas.IndexOf(c1);

            if (posicao >= 0)
            {
                Console.WriteLine("Informe o valor ?");
                Double valor = LerRealPositivo();                
                
                if(Contas[posicao].sacar(valor))
                {
                    Console.WriteLine("Saque executado");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Valor Indisponivel");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Conta Não existe");
                Console.ReadKey();
            } 
        }
        static void Depositar()
        {
            Console.WriteLine(@"
            +----------------------------------------------+
            |                    Desposito                 |
            +----------------------------------------------+");
            Console.WriteLine("Informe o numero da conta");
            Int32 NConta = LerIntPositivo();
            Conta c1 = new Conta(NConta);
            Int32 posicao = contas.IndexOf(c1);

            if (posicao >= 0)
            {
                Console.WriteLine("Informe o valor ?");
                Double valor = LerRealPositivo();

                Contas[posicao].depositar(valor);
                Console.WriteLine("Deposito efetuado.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Conta Não existe");
                Console.ReadKey();
            } 
        }
        static void ConsultarSaldo()
        {
            Console.WriteLine(@"
            +----------------------------------------------+
            |                Consulta de Saldo             |
            +----------------------------------------------+");
            Console.WriteLine("Informe o numero da conta");
            Int32 NConta = LerIntPositivo();
            Conta c1 = new Conta(NConta);
            Int32 posicao = contas.IndexOf(c1);

            if (posicao >= 0)
            {
                Console.WriteLine(contas[posicao]);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Conta não existe");
                Console.ReadKey();
            }
        }
        static void Extrato()
        {
            Console.WriteLine(@"
            +----------------------------------------------+
            |                     Extrato                  |
            +----------------------------------------------+");
            Console.WriteLine("Informe o numero da conta");
            Int32 NConta = LerIntPositivo();
            Conta c1 = new Conta(NConta);
            Int32 posicao = contas.IndexOf(c1);

            if (posicao >= 0)
            {
                Contas[posicao].imprimir();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Conta Não existe");
                Console.ReadKey();
            } 
        }

        static void Main(string[] args)
        {
            MontarMenu(new String[]{
                "Abrir conta",
                "Sacar",
                "Depositar",
                "consultar saldo",
                "Extrato",
                "Sair"},
                new Action[]{
                AbrirConta,
                Sacar,
                Depositar,
                ConsultarSaldo,
                Extrato
                }
            );
        }
    }
}
