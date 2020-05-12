using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO27boletin
{
    class Program
    {
        static List<Disciplina> diciplinas = new List<Disciplina>();
        static List<Aluno> alunos = new List<Aluno>();
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
        static Double LerRealPositivo(Double limite = Double.MaxValue)
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
                        x = Convert.ToDouble(y.Replace(".", ",")); // padronizando entrada de numero real.
                        numValido = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Por favor insira um numero real maior que Zero...");
                    }
                }
                if ((x > 0) || (x <= limite))
                {
                    numPositivo = false;
                }
                else
                {
                    Console.WriteLine("O numero informar tem que ser maior que 'Zero'...");
                    numValido = true;
                }

            }
            return x;
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
        static void CadastrarDisciplina()
        {
            Console.WriteLine("Informe o codigo da diciplina");
            Int32 codigo = LerIntPositivo();

            Disciplina d1 = new Disciplina(codigo);

            Int32 posicao = diciplinas.IndexOf(d1);

            if (posicao >= 0)
            {
                Console.WriteLine("Diciplica já cadastrada");
            }
            else
            {
                Console.WriteLine("Qual o nome da Diciplina");
                String nome = Console.ReadLine();
                d1.setNomeDis(nome);

                diciplinas.Add(d1);
            }
        }
        static void CadastrarAluno()
        {
            Console.WriteLine("Informe o codigo do Aluno");
            Int32 codigo = LerIntPositivo();

            Aluno a1 = new Aluno(codigo);

            Int32 posicao = alunos.IndexOf(a1);

            if (posicao >= 0)
            {
                Console.WriteLine("Aluno já cadastrada");
            }
            else
            {
                Console.WriteLine("Qual o nome do Aluno");
                String nome = Console.ReadLine();
                a1.setNomeAlu(nome);

                alunos.Add(a1);
            }
        }
        static void LançarNota()
        {
            Console.WriteLine("Informe o cadastro do aluno");
            Int32 cadastro = LerIntPositivo();
            Aluno a1 = new Aluno(cadastro);
            Int32 posAluno = alunos.IndexOf(a1);
            if (posAluno >= 0)
            {
                Console.WriteLine("Informe o codigo da diciplina");
                Int32 codigo = LerIntPositivo();
                Disciplina d1 = new Disciplina(codigo);
                Int32 posDisciplina = diciplinas.IndexOf(d1);
                if (posDisciplina >= 0)
                {
                    Console.WriteLine("Informe a nota do aluno");
                    Double nota = LerRealPositivo(10.0);

                    if (alunos[posAluno].lancarNota(diciplinas[posDisciplina], nota))
                    {
                        Console.WriteLine("Nota Computada");
                    }
                    else
                    {
                        Console.WriteLine("Nota já foi lançada");
                    }
                }
                else
                {
                    Console.WriteLine("Disciplina não está cadastrada");
                }
            }
            else
            {
                Console.WriteLine("Aluno não está cadastrado");
            }
        }
        static void ExibirAluno()
        {
            Console.WriteLine("Informe o Codigo do aluno");
            Int32 codigo = LerIntPositivo();
            Aluno a1 = new Aluno(codigo);
            Int32 posicao = alunos.IndexOf(a1);

            if (posicao >= 0)
            {
                Console.WriteLine(string.Format($"{alunos[posicao]}"));
                alunos[posicao].exibirNotas();
            }
            else
            {
                Console.WriteLine("Aluno não encontrado");
            }
        }
        static void Main(string[] args)
        {
            MontarMenu(new String[]{
                "Cadastrar Disciplina",
                "Cadastrar Aluno",
                "Lançar Nota",
                "Exibir Aluno",
                "Sair"},
                new Action[]{
                CadastrarDisciplina,
                CadastrarAluno,
                LançarNota,
                ExibirAluno
                }
            );
        }
    }
}
