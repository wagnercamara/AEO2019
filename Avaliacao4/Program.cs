using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao4
{
    class Program
    {
        static List<Passageiro> passageiros = new List<Passageiro>();
        static List<Cidade> cidades = new List<Cidade>();
        static List<Voo> voos = new List<Voo>();
        static Int32 LerInteiroPositivo(Int32 limite = Int32.MaxValue, char tipo = 'c')
        {
            Boolean numeroPositivo = false, Enumero = false;

            Int32 x = 0;

            while (numeroPositivo == false)
            {
                while (Enumero == false)
                {
                    try
                    {
                        x = Convert.ToInt32(Console.ReadLine());
                        Enumero = true;
                    }
                    catch
                    {
                        Console.WriteLine("\nErro, Você não informou um numero Inteiro\n");
                    }
                }
                if (x > 0 && x <= limite)
                {
                    numeroPositivo = true;
                }
                else
                {
                    if (tipo == 'l')
                    {
                        Console.WriteLine($"\nErro, Informe um numero 1 e {limite}");
                    }
                    else if (tipo == 'r')
                    {
                        Console.WriteLine($"Acento Inválido");
                    }
                    else
                    {
                        Console.WriteLine($"\nErro, Informe um numero maior que 0");
                    }
                    Enumero = false;
                }
            }
            return x;
        }
        static Int32 buscaCidade(Int32 codigo)
        {
            Cidade c1 = new Cidade(codigo);
            Int32 posicao = cidades.IndexOf(c1);
            return posicao;
        }
        static void MontarMenu(string[] opcoes, Action[] metodos)
        {
            Boolean x = true;
            Int32 escolha = 0;
            StringBuilder menu = new StringBuilder();

            menu.Append("Menu de opções\n");
            for (Int32 i = 0; i < opcoes.Length; i++)
            {
                menu.Append(string.Format($"{i + 1} - {opcoes[i]}\n"));
            }
            while (x == true)
            {
                Console.Write($"{menu}\n> ");

                escolha = LerInteiroPositivo();

                if (escolha > opcoes.Length)
                {
                    Console.WriteLine("Opcão invalida");
                }
                else if (escolha == opcoes.Length)
                {
                    Console.WriteLine("Exit");
                    x = false;
                }
                else
                {
                    metodos[escolha - 1]();
                }
            }
        }
        static void CadastrarPassageiro()
        {
            Console.WriteLine("\nInfome o Codigo do Passageiro\n");
            Int32 codigoEmbaque = LerInteiroPositivo();
            Passageiro p1 = new Passageiro(codigoEmbaque);
            Int32 posicao = passageiros.IndexOf(p1);

            if (posicao >= 0)
            {
                Console.WriteLine("\nERRO, Esse passageiro já foi cadastrado\n");
            }
            else
            {
                Console.WriteLine("\nInforme o nome do passageiro\n");
                String nome = Console.ReadLine();
                p1.setNomePassageiro(nome);
                passageiros.Add(p1);
                Console.WriteLine("\nO passageiro foi cadastrado no sistema\n");
            }
        }
        static void CadastrarCidade()
        {
            Console.WriteLine("\nInfome o Codigo da Cidade\n");
            Int32 codigoCidade = LerInteiroPositivo();
            Cidade c1 = new Cidade(codigoCidade);
            Int32 posicao = cidades.IndexOf(c1);

            if (posicao >= 0)
            {
                Console.WriteLine("\nERRO, Cidade já cadastrada\n");
            }
            else
            {
                Console.WriteLine("\nInforme o nome da Cidade\n");
                String nome = Console.ReadLine();
                c1.setNomeCidade(nome);
                cidades.Add(c1);
                Console.WriteLine("\nA Cidade foi cadastrado no sistema\n");
            }
        }
        static void CadastrarVoo()
        {
            Console.WriteLine("\nInforme o codigo do Voo\n");
            Int32 codigoVoo = LerInteiroPositivo();
            Voo v1 = new Voo(codigoVoo);
            Int32 posicao = voos.IndexOf(v1);

            if (posicao >= 0)
            {
                Console.WriteLine("\nERRO, Voo já cadastrado\n");
            }
            else
            {
                Console.WriteLine("\nInforme o codigo da cidade de Origem\n");
                Int32 posicaoCidadeOrigem = buscaCidade(LerInteiroPositivo());

                if (posicaoCidadeOrigem >= 0)
                {
                    Console.WriteLine("\nInforme o codigo da cidade de Destino\n");
                    Int32 posicaoCidadeDestino = buscaCidade(LerInteiroPositivo());
                    if (posicaoCidadeDestino >= 0)
                    {
                        if (posicaoCidadeDestino == posicaoCidadeOrigem)
                        {
                            Console.WriteLine("\nO destino do voo não pode ser o mesmo de origem\n");
                        }
                        else
                        {
                            Console.WriteLine("\nInforme a quantidade de acentos para o Voo");
                            Int32 numeroAcentos = LerInteiroPositivo(200,'l');

                            v1.setCidade(cidades[posicaoCidadeOrigem]);
                            v1.setCidade(cidades[posicaoCidadeDestino]);
                            v1.setAcentos(numeroAcentos);
                            voos.Add(v1);
                            Console.WriteLine("\nVoo cadastrado no sistema\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nA cidade informada não está cadastrada no sistema\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nA cidade informada não está cadastrada no sistema\n");
                }
            }
        }
        static void ReservarAcento()
        {
            Console.WriteLine("\nInfome o Codigo do Passageiro\n");
            Int32 codigoEmbaque = LerInteiroPositivo();
            Passageiro p1 = new Passageiro(codigoEmbaque);
            Int32 posicaoP = passageiros.IndexOf(p1);

            if (posicaoP >= 0)
            {
                Console.WriteLine("\nInforme o codigo do Voo\n");
                Int32 codigoVoo = LerInteiroPositivo();
                Voo v1 = new Voo(codigoVoo);
                Int32 posicaoVoo = voos.IndexOf(v1);

                if (posicaoVoo >= 0)
                {
                    Console.WriteLine("\nInforme o numero da Poltrona\n");
                    Int32 numeroPoltrona = LerInteiroPositivo(voos[posicaoVoo].getNumeroAcentos(), 'r');

                    if (voos[posicaoVoo].faserReserva(numeroPoltrona, passageiros[posicaoP]))
                    {
                        Console.WriteLine("\nReserva Efetuada com sucesso\n");
                    }
                    else
                    {
                        Console.WriteLine("\nAcento ocupado\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nVoo não encontrado\n");
                }
            }
            else
            {
                Console.WriteLine("\nPassageiro não encontrado\n");
            }
        }
        static void ExibirVoo()
        {
            Console.WriteLine("\nInforme o codigo do Voo\n");
            Int32 codigoVoo = LerInteiroPositivo();
            Voo v1 = new Voo(codigoVoo);
            Int32 posicao = voos.IndexOf(v1);

            if (posicao >= 0)
            {
                voos[posicao].ExibirAcentos();
            }
            else
            {
                Console.WriteLine("Voo não encontrado");
            }
        }
        static void Main(string[] args)
        {
            MontarMenu(new String[]{
                  "Cadastrar Passageiro",
                  "Cadastrar Cidade",
                  "Cadastrar Voo",
                  "Reservar Acento",
                  "Exibir Voo",
                  "Sair"
                },
                new Action[]{
                  CadastrarPassageiro,
                  CadastrarCidade,
                  CadastrarVoo,
                  ReservarAcento,
                  ExibirVoo
                  });
        }
    }
}
