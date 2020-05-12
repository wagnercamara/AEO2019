using System.Text;
using System.Threading;
using static System.Action;
using System;

namespace AEO12MenuOpcoes
{
    class Program

    {
        public static class bancoDados
        {
            public static Int32 contador = 0;
            public static string[] aluno = new string[150];

        }
        static Int32 LerNumeroIntPos ()
        {
            Boolean numeroInteiro = true;
            Boolean numeroPositivo = true;
            Int32 numero = 0;
            while (numeroPositivo != false)
            {
                while(numeroInteiro != false)
                { 
                    try
                    {
                        numero = Convert.ToInt32(Console.ReadLine());
                        numeroInteiro = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incira apenas numero inteiros");
                        numeroInteiro = true;
                    }
                }
                if(numero <= 0)
                {
                    Console.WriteLine("Voce precisa incerir pelomenos 1 alunos");
                    numeroInteiro = true;
                }
                else
                {
                    numeroPositivo = false;
                }
            }
            return numero;
        }

        static string TirarAcetosMinusculo(string palavra)
        {
            palavra = palavra.ToLower();
            return palavra.
		    Replace('á', 'a').Replace('à', 'a').Replace('ã', 'a').Replace('â', 'a').Replace('ä', 'a').
		    Replace('é', 'e').Replace('è', 'e').Replace('ê', 'e').Replace('ë', 'e').
		    Replace('í', 'i').Replace('ì', 'i').Replace('î', 'i').Replace('ï', 'i').
		    Replace('ó', 'o').Replace('ò', 'o').Replace('õ', 'o').Replace('ô', 'o').Replace('ö', 'o').
		    Replace('ú', 'u').Replace('ù', 'u').Replace('û', 'u').Replace('ü', 'u').
		    Replace('ý', 'y').Replace('ÿ', 'y').Replace('ç','c').Replace('Ç','C').
		    Replace('Á', 'A').Replace('À', 'A').Replace('Ã', 'A').Replace('Â', 'A').Replace('Ä', 'A').
		    Replace('É', 'E').Replace('È', 'E').Replace('Ê', 'E').Replace('Ë', 'E').
		    Replace('Í', 'I').Replace('Ì', 'I').Replace('Î', 'I').Replace('Ï', 'I').
		    Replace('Ó', 'O').Replace('Ò', 'O').Replace('Õ', 'O').Replace('Ô', 'O').Replace('Ö', 'O').
		    Replace('Ú', 'U').Replace('Ù', 'U').Replace('Û', 'U').Replace('Ü', 'U').
		    Replace('Ý', 'Y');
        }

        static void MatricularAluno ()
        {
            if (bancoDados.contador < bancoDados.aluno.Length)
            {
                Console.Clear();
                Console.WriteLine("Quantos Alunos deseja cadastrar?");
                Int32 x = LerNumeroIntPos();
                Int32 y = 0; // controle while
                Int32 i = 1;
                Console.WriteLine();
                for(y = 0; y < x; y++)
                {
                    StringBuilder matriNome = new StringBuilder();
                    Console.WriteLine("Por favor insira a Matricula do {0} aluno",i);
                    Int32 nmatri = LerNumeroIntPos();
                    Console.WriteLine("Por favor escreva o nome do {0} aluno",i);
                    string nAluno = Console.ReadLine();
                    Console.WriteLine();
                    i++;
                    bancoDados.aluno[bancoDados.contador++] = Convert.ToString(matriNome.Append(Convert.ToSingle(nmatri)).Append(";").Append(nAluno));
                }
            Console.WriteLine("Alunos matriculado com sucesso");
            }
            
        }
        static void ExcluirAluno ()
        {
            Console.Clear();
            Int32 i = 0; // controle de vezes do while / posição de pesquisa dentro do arrey
            Console.WriteLine(@"
            Para excluir um Aluno você precisa estar com a MATRICULA,
            caso não tenha volte ao menu anterior e pesquise pelo nome do
            aluno que o progrma lhe informa a matricula do mesmo");
            Console.WriteLine();

            Console.WriteLine("Por favor informe a matricula do Aluno");
            Int32 matricula = LerNumeroIntPos();
            string busca = Convert.ToString(matricula);

            for(i = 0; i < bancoDados.contador; i++)
            {   
                if (bancoDados.aluno[i] != null && (busca.Equals((bancoDados.aluno[i].Split(";"))[0])) == true)
                {
                    bancoDados.aluno[i] = bancoDados.aluno[bancoDados.contador];    
                    bancoDados.aluno[bancoDados.contador]=null;
                    bancoDados.contador = bancoDados.contador - 1 ;
                    Console.WriteLine("A matricula {0} do aluno {1} foi deletada",matricula,((bancoDados.aluno[i].Split(";"))[1]));
                    break;
                }
            }
            if (i == bancoDados.contador)
            {
                Console.WriteLine("O aluno {0} não existe", busca);
            }
        }
        static void ProcurarAlunoMatricula ()
        {
            Console.Clear();
            Int32 i = 0; // controle de vezes do while / posição de pesquisa dentro do arrey

            Console.WriteLine("Por favor informe a matricula do Aluno");
            Int32 matricula = LerNumeroIntPos();
            string busca = Convert.ToString(matricula);

            for(i = 0; i <= bancoDados.contador; i++)
            {   
                if (bancoDados.aluno[i] != null && (busca.Equals((bancoDados.aluno[i].Split(";"))[0])) == true)
                {
                    Console.WriteLine("A matricula {0} corresponde ao aluno {1}",matricula,((bancoDados.aluno[i].Split(";"))[1]));
                    break;
                }
            }
            if (i == bancoDados.contador)
            {
                Console.WriteLine("O aluno {0} não existe", busca);
            }
        }
        
        static void ProcurarAlunoNome ()
        {
            Console.Clear();
            Int32 i = 0; // controle de vezes do for / posição de pesquisa dentro do arrey
            Console.WriteLine();

            Console.WriteLine("Por favor informe a Nome do Aluno");
            string busca = Console.ReadLine();

            for(i = 0; i <= bancoDados.contador; i++)
            {   
                if (bancoDados.aluno[i] != null && (TirarAcetosMinusculo(busca).Equals(TirarAcetosMinusculo((bancoDados.aluno[i].Split(";"))[1]))) == true)
                {
                    Console.WriteLine("O aluno {0} pertence a matricula {1}",((bancoDados.aluno[i].Split(";"))[1]),((bancoDados.aluno[i].Split(";"))[0]));
                    break;
                }
            }
            if (i == bancoDados.contador)
            {
                Console.WriteLine("O aluno {0} não existe", busca);
            }
        }
        static void MontarMenu(string[] opcao,Action[] acoes)
        {
            Boolean imprimirMenu =true;
            Int32 opcaoEscolhida = 0;
            Int32 numeroOpcao = 1;
            StringBuilder menu = new StringBuilder();
            
            if (opcao.Length > 0)
            {
                menu.Append(numeroOpcao).Append("-").Append(opcao[numeroOpcao - 1]);
                for(numeroOpcao = 2;numeroOpcao <= opcao.Length; numeroOpcao++)
                {
                    menu.Append("\n").Append(numeroOpcao).Append("-").Append(opcao[numeroOpcao - 1]);
                }
                while(imprimirMenu == true)
                {
                    Console.WriteLine(menu.ToString()); // impriminto o menu
                    opcaoEscolhida = Convert.ToInt32(Console.ReadLine());
                    if (opcaoEscolhida < opcao.Length)
                    {
                        acoes[opcaoEscolhida -1 ]();
                        Console.WriteLine();
                    }
                    else if(opcaoEscolhida == opcao.Length)
                    {
                        Console.WriteLine("Saindo...");
                        imprimirMenu = false;
                    }    
                    else
                    {
                        Console.WriteLine("Opção invalida");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            string[] x = new string[5];
            Action[] y = new Action[4];
            x[0]="Matricula Aluno";
            x[1]="Excluir Aluno"; 
            x[2]="Prourar Aluno usando o Nome"; 
            x[3]="Procurar Aluno usando Matricula"; 
            x[4]="Sair";            
            y[0]= MatricularAluno;
            y[1]= ExcluirAluno;
            y[2]= ProcurarAlunoNome;
            y[3]= ProcurarAlunoMatricula;
            MontarMenu(x,y);

        }
    }
}
