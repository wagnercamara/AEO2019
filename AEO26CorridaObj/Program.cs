using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO26CorridaObj
{
    class Program
    {
        static List<Corrida> corridas = new List<Corrida>();
        static List<Piloto> pilotos = new List<Piloto>();
        static Int32 LerIntPositivo()
        {
            Int32 numero = 0;
            Boolean numValido = false;
            Boolean LerNumero = true;

            while (LerNumero)
            {
                while (numValido == false)
                {
                    try
                    {
                        numero = Convert.ToInt32(Console.ReadLine());
                        numValido = true;
                    }
                    catch
                    {
                        Console.Write("\nValor Invalido! Informe apenas de numeros inteiros positivos:\n> ");
                    }
                }
                if (numero <= 0)
                {
                    Console.Write("\nNúmero Invalido! Informe apenas de numeros inteiros positivos:\n> ");
                    numValido = false;
                }
                else
                {
                    LerNumero = false;
                }

            }
            return numero;
        }
        static void MontarMenu(String[] opcao, Action[] metodo)
        {
            if (opcao.Length > 0)
            {
                Boolean imprimirMenu = true;
                Int32 opcaoEscolhida = 0;
                StringBuilder menu = new StringBuilder();
                menu.Append("\n").Append(1).Append("-").Append(opcao[0]);
                for (Int32 i = 2; i <= opcao.Length; i++)
                {
                    menu.Append("\n").Append(i).Append("-").Append(opcao[i - 1]);
                }

                while (imprimirMenu)
                {
                    Console.Write($"{menu}\n> ");
                    opcaoEscolhida = LerIntPositivo();

                    if (opcaoEscolhida < opcao.Length)
                    {
                        metodo[opcaoEscolhida - 1]();
                    }
                    else if (opcaoEscolhida == opcao.Length)
                    {
                        imprimirMenu = false;
                    }
                    else
                    {
                        Console.WriteLine("\nOpção invalida!");
                    }
                }
            }
        }
        static void CadastrarPiloto()
        {
            Console.WriteLine("\nInforme o numero do Piloto:");
            Int32 numero = LerIntPositivo();

            Piloto novopiloto = new Piloto(numero);
            Int32 posicao = pilotos.IndexOf(novopiloto);

            if (posicao < 0)
            {
                Console.WriteLine("\nInforme o nome do piloto:");
                String nome = Console.ReadLine();
                novopiloto.SetNomePiloto(nome);
                pilotos.Add(novopiloto);
                Console.WriteLine("\nPiloto cadastrado!");
            }
            else
            {
                Console.WriteLine($"\nPiloto {pilotos[posicao].GetNomePiloto()} já cadastrado com este número ({numero})!");
            }
        }
        static void CadastrarCorrida()
        {
            Console.WriteLine("\nInforme o numero da corrida:");
            Int32 numero = LerIntPositivo();

            Corrida novocorrida = new Corrida(numero);
            Int32 posicao = corridas.IndexOf(novocorrida);

            if (posicao < 0)
            {
                corridas.Add(novocorrida);
                Console.WriteLine("\nCorrida cadastrada!");
            }
            else
            {
                Console.WriteLine("\nCorrida já cadastrada!");
            }
        }
        static void LançarPontuacao()
        {
            Console.WriteLine("\nInforme o numero da corrida:");
            Int32 numero = LerIntPositivo();

            Corrida novocorrida = new Corrida(numero);
            Int32 posicao = corridas.IndexOf(novocorrida);

            if (pilotos.Count == 0)
            {
                Console.WriteLine("\nNenhum piloto encontrado!");
            }
            else if (posicao >= 0)
            {
                for (Int32 posicaoPiloto = 0; posicaoPiloto < pilotos.Count; posicaoPiloto++)
                {
                    Console.WriteLine($"\nInforme a pontuação de {pilotos[posicaoPiloto]}:");
                    Pontuacao pontuacao = new Pontuacao(pilotos[posicaoPiloto]);
                    pontuacao.SetValorPontuacao(LerIntPositivo());
                    corridas[posicao].SetPontuacaoCorrida(pontuacao);
                }
                Console.WriteLine("\nPontuação da corrida atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nCorrida não encontrada!");
            }
        }
        static void ExibirResultado()
        {
            Console.WriteLine("\nInforme o número da corrida:");
            Int32 numero = LerIntPositivo();

            Corrida novocorrida = new Corrida(numero);
            Int32 posicao = corridas.IndexOf(novocorrida);

            if (pilotos.Count == 0)
            {
                Console.WriteLine("\nNenhum piloto encontrado!");
            }
            else if (posicao >= 0)
            {
                corridas[posicao].GetResultado(pilotos);
            }
            else
            {
                Console.WriteLine("\nCorrida não encontrada!");
            }

        }
        static void AlterarNomePiloto()
        {
            Console.WriteLine("\nInforme o numero do Piloto:");
            Int32 numero = LerIntPositivo();

            Piloto novopiloto = new Piloto(numero);
            Int32 posicao = pilotos.IndexOf(novopiloto);

            if (posicao >= 0)
            {
                Console.WriteLine($"\nInforme o novo nome do piloto {pilotos[posicao]}:");
                String nome = Console.ReadLine();
                pilotos[posicao].SetNomePiloto(nome);
                Console.WriteLine($"\nNome do piloto ({pilotos[posicao].GetNumeroPiloto()}) alterado com sucesso!\nNovo nome: {pilotos[posicao].GetNomePiloto()}");
            }
            else
            {
                Console.WriteLine("\nPiloto não encontrado!");
            }
        }
        public static void Main(string[] args)
        {
            MontarMenu(new String[]{
                "Cadastrar Piloto",
                "Alterar Nome Piloto",
                "Cadastrar Corrida",
                "Lançar Pontuação",
                "Exibir Resultado",
                "Sair"},
                new Action[]{
                CadastrarPiloto,
                AlterarNomePiloto,
                CadastrarCorrida,
                LançarPontuacao,
                ExibirResultado
                }
            );
        }
    }
}