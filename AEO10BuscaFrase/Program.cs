using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO10BuscaFrase
{
    class Program
    {
        static Int32 LerNumeroInteirop ()
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
                    Console.WriteLine("O numero tem que ser maior que 'zero'");
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
        static void BuscaNaFrase(string frase, string palavra)
        {
            Boolean x = true;
            string[] a = frase.Split(" ");
            Int32 t = a.Length; // mostra o tamanho do arrey 

            for (Int32 i = 0; i< t; i++ )
            {
                if (a[i].Equals(palavra) == true)
                {
                    Console.WriteLine("A palavra {0} está na posição {1}",palavra,i);
                    x = false;
                    break;
                }
            }
            if (x == true)
            {
               Console.WriteLine("A palavra {0} não foi localizada",palavra); 
            }
        }
        static void Main(string[] args)
        {
          Console.WriteLine("Quantas frases serão digitadas ?");
          Int32 numeroFrase = LerNumeroInteirop();

          for (Int32 i = 1; i <= numeroFrase; i++)
          {
            Console.Clear();
            Console.WriteLine("Digite ou cole a frase");
            string f = Console.ReadLine();
            f = TirarAcetosMinusculo(f);
            Console.WriteLine("Quantas palavras deseja pesquisar ? ");
            Int32 qtd = LerNumeroInteirop(); 
            for (Int32 x = 0; x < qtd; x++)
            {
                Console.WriteLine("Digite ou cole a palavra a ser pesquisada na frase.");
                string p = Console.ReadLine();
                p = TirarAcetosMinusculo(p);
                Console.Clear();
                BuscaNaFrase(f,p);
            }
          }
        }
            
    }
}

