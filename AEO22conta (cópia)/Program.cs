using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO22conta
{
    class Program
    {
        static Dictionary<Int32,Conta> contas = new Dictionary<Int32,Conta>();
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
        static void AbrirConta()
        {
            Console.WriteLine("Informe a conta");
            Int32 numeroDaConta = LerIntPositivo();

            if(contas.ContainsKey(numeroDaConta))
            {
                Console.WriteLine("Conta já existe");
                Console.WriteLine("< Precione ENTER para continuar >");
                Console.ReadKey();
            }
            else
            {
               Conta transacao = new Conta();
               contas.Add(numeroDaConta, transacao);
            }
        }
        static void Sacar()
        {
            //Conta saque = new Conta();

            Console.WriteLine("Qual o valor que desejá sacar");
            Double valor = LerRealPositivo();
            Console.WriteLine("Qual a Conta?");
            Int32 numeroDaConta = LerIntPositivo();
            Console.WriteLine();
            if(contas.ContainsKey(numeroDaConta))
            {
                //Boolean ok = saque.sacar(valor);
                Boolean ok = contas[numeroDaConta].sacar(valor);
                Console.WriteLine(ok);
                if (ok == true)
                {
                    Console.WriteLine("Foi sacado R${0}, na conta {1}",valor,numeroDaConta);
                    Console.WriteLine();
                    Console.WriteLine("< Precione ENTER para continuar >");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Saque: R${0}, você não tem saldo no momento.",valor);
                    Console.WriteLine();
                    Console.WriteLine("< Precione ENTER para continuar >");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Conta não encontrada");
                Console.WriteLine();
                Console.WriteLine("< Precione ENTER para continuar >");
                Console.ReadKey();
            }
        }
        static void Depositar()
        {
            Console.WriteLine("Qual o valor que desejá depoditar");
            Double valor = LerRealPositivo();
            Console.WriteLine("Qual o numero da Conta ?");
            Int32 numeroDaConta = LerIntPositivo();
            Console.WriteLine();

            if(contas.ContainsKey(numeroDaConta))
            {
                contas[numeroDaConta].depositar(valor);
                Console.WriteLine("Deposito Concluido");
                Console.WriteLine();
                Console.WriteLine("< Precione ENTER para continuar >");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Conta não encontrada");
                Console.WriteLine();
                Console.WriteLine("< Precione ENTER para continuar >");
                Console.ReadKey();
            }
        }
        static void consultarSaldo()
        {
            Console.WriteLine("Qual o numero da Conta ?");
            Int32 numeroDaConta = LerIntPositivo();
            if(contas.ContainsKey(numeroDaConta))
            {
                contas[numeroDaConta].imprimir();
                Console.WriteLine();
                Console.WriteLine("< Precione ENTER para continuar >");
                Console.ReadKey();
            }   
            else
            {
                Console.WriteLine("Conta não encontrada");
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
                    //Console.Clear();
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
                "Abrir conta",
                "Sacar",
                "Depositar",
                "consultar saldo",
                "Sair"},
                new Action[]{
                AbrirConta,
                Sacar,
                Depositar,
                consultarSaldo
                }
            );
        }
    }
}
