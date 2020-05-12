using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao_2
{
    class Program
    {
        static String[] alunos;
        static String[] colunasValidas;
        static Int32 contAlunos;
        static Double[,] tabelaAcompanhamento;
        static Int32 busca(Int32 x) // garante que não terá dois alunus com a mesma matricula, e devolve o lucal valido para inceririr o novo registro;
        {
            Int32 i = 0;

            for (i = 0; i < contAlunos; i++)
            {
                string[] y = alunos[i].Split(";");

                if(x == Convert.ToInt32(y[0]))
                {
                    return i; // pasando indice do aluno;
                }
            }
            return -1; // não encontrado;
        }
        static Int32 ValidaMes(Int32 mes, Int32 mat) // garante que o mes não será incerirido 2 vezes;
        {
            Int32 i = 0;
            if (colunasValidas[mat] != null)
            {
                String[] t = colunasValidas[mat].Split(";");
                for (i = 0; i < t.Length; i++)
                {
                    if(mes == Convert.ToInt32(t[i]))
                    {
                        return 1; // pasando indice do aluno;
                    }
                }
            }
            
            return -1; // não encontrado;
        }
        static void GuardarColunaValida (int m , int mes) // m =  indice aluno,  mes incerido 
        {
            StringBuilder x = new StringBuilder();

            if (colunasValidas[m] == null)
            {
                colunasValidas[m] = Convert.ToString(mes);
            }
            else
            {
               colunasValidas[m] = colunasValidas[m] + ";" + mes; 
                String[] ordenar = colunasValidas[m].Split(";");

                string troca = null;

                for(Int32 i = 0; i < ordenar.Length; i++)
                {
                    for(Int32 y = 0; y < ordenar.Length ; y++)
                    {
                        if ((Convert.ToInt32(ordenar[y]) > (Convert.ToInt32(ordenar[i]))))
                        {
                            troca = ordenar[i];
                            ordenar[i] = ordenar[y];
                            ordenar[y] = troca;
                        }   
                    }

                }

                x.Append(ordenar[0]);
                for (Int32 grava = 1; grava < ordenar.Length; grava ++)
                {
                x.Append(";").Append(ordenar[grava]);
                }
                colunasValidas[m] = Convert.ToString(x);
            }
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
        static void CadastrarAluno()
        {
            if (contAlunos < alunos.Length)
            {
                StringBuilder gravar = new StringBuilder();

                Console.WriteLine("Informe a matrícula do aluno");
                Int32 matricula = LerIntPositivo();
                Int32 x = busca(matricula);
                Console.WriteLine();
                if (x < 0)
                {
                    Console.WriteLine("Informe o nome do aluno");
                    String nomeAluno = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Informe o peso inicial");
                    Double pesoAluno = LerRealPositivo(); 
                    Console.WriteLine();
                    contAlunos = contAlunos + 1; // quantidade total de alunos no array;

                    alunos[contAlunos - 1] =  Convert.ToString(gravar.Append(Convert.ToString(matricula)).Append(";").Append(nomeAluno).Append(";").Append(Convert.ToString(pesoAluno)));

                    Console.WriteLine("<>Aluno cadastrado com sucesso<>");
                    Console.WriteLine();
                    Console.WriteLine("<>Precione ENTER para continuar");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Essa matrícula já exite .. ");
                    Console.WriteLine();
                    Console.WriteLine("<>Precione ENTER para continuar");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine(" (O.O) Opss.. a lista de alunos ficou maior que a estipulada no começo do projeto.");
                Console.WriteLine();
                Console.WriteLine("<>Precione ENTER para continuar");
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
                alunos[x] = alunos[contAlunos -1];
                alunos[contAlunos - 1] = null;
                

                for(Int32 i = 0;i < 12; i++)
                {
                    tabelaAcompanhamento[x,i] = tabelaAcompanhamento[contAlunos - 1, i];
                    tabelaAcompanhamento[contAlunos - 1, i] = 0; 
                }
                colunasValidas[x] = colunasValidas[contAlunos - 1];
                colunasValidas[contAlunos - 1] = null;

                contAlunos = contAlunos -1;

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
        static void PesarAluno()
        {
            StringBuilder controle = new StringBuilder();

            Console.WriteLine("Informe a Matrícula do Aluno");
            Int32 matricula = LerIntPositivo();
            Int32 x = busca(matricula);
            Console.WriteLine();
            if (x >= 0)
            {
                Console.WriteLine("Informe o Mês");
                Int32 mesValido = LerIntPositivo();
                Console.WriteLine();
                Int32 mes = ValidaMes(mesValido,x);

                if (mes < 0)
                {
                    if(mesValido <= 12)
                    {
                        Console.WriteLine("Informe o peso do Aluno");
                        Double peso = LerRealPositivo();
                        Console.WriteLine();
                        tabelaAcompanhamento[x,mesValido - 1] = peso;

                        GuardarColunaValida(x,mesValido); 

                        Console.WriteLine("<>Peso Computado<>");
                        Console.WriteLine();
                        Console.WriteLine("<>Precione ENTER para continuar");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Os meses informados devem ser > 1 e < 12");
                        Console.WriteLine();
                        Console.WriteLine("<>Precione ENTER para continuar");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Este mês já possiu um peso");
                    Console.WriteLine();
                    Console.WriteLine("<>Precione ENTER para continuar");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("(¬¬) Matrícula invalida..");
                Console.WriteLine();
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
        }
        static void CalcularEvoluçãodoAluno()
        {
            Console.WriteLine("Informe a Matrícula do Aluno");
            Int32 matricula = LerIntPositivo();
            Int32 x = busca(matricula);

            if (x >=0)
            {   
                if ( colunasValidas[x] != null) // só será aplicado se tives pelomenos 1 mes.
                {
                    String[] colunas = colunasValidas[x].Split(";");
                    Double resultado = 0;
                    String[] inicio = alunos[x].Split(";");
                    Double pesoInicial = Convert.ToDouble(inicio[2]);
                    Console.WriteLine();
                    Console.WriteLine("O aluno {0} portador da matrícula {1}, começou com {2} kg e está com {3} kg",inicio[1],inicio[0],inicio[2],tabelaAcompanhamento[x,Convert.ToInt32(colunas[colunas.Length -1]) - 1]);
                    Console.WriteLine();
                    Console.WriteLine("Evolução:");
                    Console.WriteLine();
                    resultado = ((tabelaAcompanhamento[x,Convert.ToInt32(colunas[0])-1]) - pesoInicial);
                    if (resultado >= 0)
                    {
                        Console.WriteLine("Mês {0} -> +{1} kg",(colunas[0]),resultado);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Mês {0} -> {1} kg",(colunas[0]),resultado);
                        Console.WriteLine();
                    }
                    
                    if (colunas.Length > 1)
                    {
                        for(Int32 i = 0; i < colunas.Length - 1; i++)
                        {
                            resultado = ((tabelaAcompanhamento[x,Convert.ToInt32(colunas[i+1])-1])-(tabelaAcompanhamento[x,Convert.ToInt32(colunas[i])-1]));
                            if (resultado >= 0)
                            {
                                Console.WriteLine("Mês {0} -> +{1} kg",(colunas[i+1]),(resultado));
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Mês {0} -> {1} kg",(colunas[i+1]),(resultado));
                                Console.WriteLine();
                            }
                        }
                    }
                    Console.WriteLine("<>Precione ENTER para continuar");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Humm ... Voce apenas começou, ainda não tenho dados para o calculo");
                    Console.WriteLine();
                    Console.WriteLine("<>Precione ENTER para continuar");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("(¬¬) Matrícula não encontrada");
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
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Informe quantos alunos serão avaliados ?");
            Int32 qAlunos = LerIntPositivo();
            alunos = new String[qAlunos];
            tabelaAcompanhamento = new Double[qAlunos,12];
            colunasValidas = new String[qAlunos];

            MontarMenu(new String[]{
                "Cadastrar Aluno",
                "Alterar Aluno",
                "Excluir Aluno",
                "Pesar Aluno",
                "Calcular Evolução do Aluno",
                "Sair"},
                new Action[]{
                CadastrarAluno,
                AlterarAluno,
                ExcluirAluno,
                PesarAluno,
                CalcularEvoluçãodoAluno   
                }
            );
        }
    }
}