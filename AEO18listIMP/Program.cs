using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao_2
{
    class Program
    {
        static List <String> alunos = new List<String>();

        static Int32 busca(Int32 x) // garante que não terá dois alunus com a mesma matricula, e devolve o lucal valido para inceririr o novo registro;
        {
            Int32 i = 0;

            for (i = 0; i < alunos.Count; i++)
            {
                string[] y = alunos[i].Split(";");

                if(x == Convert.ToInt32(y[0]))
                {
                    return i; // pasando indice do aluno;
                }
            }
            return -1; // não encontrado;
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
        static void MatricularAluno()
        {
            Console.WriteLine("Digite o numero da matricula");
            Int32 mat = LerIntPositivo();
            Int32 val = busca(mat);

            if (val < 0)
            {
                Console.WriteLine("Digite o nome do aluno");
                String nome = Console.ReadLine();
                StringBuilder guarda = new StringBuilder();

                guarda.Append(Convert.ToString(mat)).Append(";").Append(nome);
                alunos.Add(Convert.ToString(guarda)); 
                Console.WriteLine();
                Console.WriteLine("Aluno {0} matriculado",nome);
                Console.WriteLine();
                Console.WriteLine("<>Precione Enter para sair<>");
                Console.ReadKey();
            } 
            else
            {
                Console.WriteLine("Matricula já existe");
                Console.WriteLine();
                Console.WriteLine("<>Precione Enter para sair<>");
                Console.ReadKey();
            }
        }
        static void AlterarAluno()
        {
            StringBuilder gravar = new StringBuilder(); // gravando aluno no banco de dados
            Boolean valido = true;
            Int32 alterarAqui = 0;

            Console.WriteLine("Informe a Matrícula do Aluno");
            Int32 matricula = LerIntPositivo();

            Int32 x = busca(matricula);

            if (x >= 0)
            {
                String[] y = alunos[x].Split(";");
                Console.WriteLine("Na lista abaixo o que deseja alterar");
                Console.WriteLine();

                while(valido == true) // validar opção escolhida
                {
                    for (Int32 i = 0; i < y.Length; i++) // imprimindo informação
                    {
                        Console.WriteLine("{0} - {1}",(i+1),(y[i]));
                    }
                    Console.WriteLine("4 - Cancelar");
                    alterarAqui = LerIntPositivo(); // ler entrada

                    if (alterarAqui >= 1 && alterarAqui <= 4) // verificando entrada
                    {
                       valido = false; // saindo do while;
                    }
                    else
                    {
                        Console.WriteLine("Opção invalida");
                        Console.WriteLine("<>Precione ENTER para continuar");
                        Console.ReadKey();
                    } 
                }
                   switch(alterarAqui) 
                   {
                       case 1:
                            Console.WriteLine("Insira a matricula nova");
                            matricula = LerIntPositivo();
                            x = busca(matricula);
                            Console.WriteLine();

                            if (x > 0)
                            {
                                Console.WriteLine("Matricula já exite");
                                Console.WriteLine();
                            }
                            else
                            {
                              y[alterarAqui - 1] = Convert.ToString(matricula);
                              Console.WriteLine("<> A informação foi alterada <>");
                                Console.WriteLine("");  
                            }
                            break;
                        case 2:
                            Console.WriteLine("Insira um nome para substituir");
                            y[alterarAqui - 1] = Console.ReadLine();
                            Console.WriteLine("<> A informação foi alterada <>");
                            Console.WriteLine("");
                            break;
                        case 3:
                            Console.WriteLine("Insira nova pesagem");
                            y[alterarAqui - 1] = Convert.ToString(LerRealPositivo());
                            Console.WriteLine("<> A informação foi alterada <>");
                            Console.WriteLine("");
                            break;
                        case 4:
                            Console.WriteLine("Operação cancelada");
                            break;
                   }
                // gravando alteração;
                    alunos[x] = Convert.ToString(gravar.Append(y[0]).Append(";").Append(y[1]).Append(";").Append(y[2]));
                    Console.WriteLine("<>Precione ENTER para continuar");
                    Console.ReadKey();
            }
            else if (x < 0)
            {
                Console.WriteLine("(¬.¬) A Matrícula informada não exite no banco de dados.");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
        }
        static void ExcluirAluno()
        {
          Console.WriteLine("Informe a Matrícula do Aluno");
            Int32 matricula = LerIntPositivo();

            Int32 x = busca(matricula);

            if (x >= 0)
            {
                alunos.RemoveAt(x);

                Console.WriteLine("<>A matrícula {0} foi excluída<>",matricula);
                Console.WriteLine("");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("(¬¬) Matrícula não existe");
                Console.WriteLine("");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }

        }
        static void ImprimirLista()
        {
            var maiorNome = alunos.Select(aluno => aluno.Split(';')[1]).OrderByDescending(nomeAluno => nomeAluno.Length).FirstOrDefault();
            //var maiorNome = (from aluno in alunos
            //orderby aluno.Split(';')[1].Length descending
            //select aluno.Split(';')[1]).FirstOrDefault();
            
            
            
            if (maiorNome != null)
            {
                Console.WriteLine(String.Format("{0,9}  {1,4}", "Matrícula", "Nome"));
                Console.WriteLine(String.Concat(Enumerable.Repeat("-", Math.Max(4, maiorNome.Length) + 11)));
            
            
            
                var it = alunos.GetEnumerator();
            
            
            
                while (it.MoveNext())
                {
                    String[] dados = it.Current.Split(';');
                    Console.WriteLine(String.Format("{0,-9}  {1,-50}", dados[0], dados[1]));
                }
            }
            else
            {
                Console.WriteLine("Nenhum aluno encontrado");
            }
                    
        }
        static void ExibirAluno()
        {
            Console.WriteLine("Por favor informe a matricula do Aluno");
            Int32 matricula = LerIntPositivo();
            Int32 val = busca(matricula);

            if(val >=0)
            {
                String[] y = alunos[val].Split(";");
                Console.WriteLine("a matricula {0}, pertense ao aluno {1}",y[0],y[1]);   
                Console.WriteLine("");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();             
            }
            else
            {
                Console.WriteLine("Matricula não existe!");
                Console.WriteLine("");
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
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            MontarMenu(new String[]{
                "Matricular Aluno",
                "Alterar Aluno",
                "Excluir Aluno",
                "Exibir Aluno",
                "Imprimir a lista",
                "Sair"},
                new Action[]{
                MatricularAluno,
                AlterarAluno,
                ExcluirAluno,
                ExibirAluno,
                ImprimirLista
                }
            );
        }
    }
}