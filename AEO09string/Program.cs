using System;
using System.Globalization;

namespace AEO09String
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
                return palavra
                .Replace('â','a').Replace('ã','a').Replace('á','a').Replace('à','a').Replace('ç','c')
                .Replace('ì','i').Replace('í','i')
                .Replace('ó','o').Replace('ò','o').Replace('õ','o').Replace('ô','o')
                .Replace('é','e').Replace('è','e').Replace('ê','e')
                .Replace('ü','u').Replace('ú','u').Replace('ù','u');
            }
        static void IgualDiferemte(string palavra1, string palavra2, Int32 i)
            {
                Boolean x = palavra1.Equals(palavra2);
                if (x == true)
                {
                    Console.WriteLine("O Par {0} É Igual",i);
                }
                else
                {
                    Console.WriteLine("O par {} é diferente",i);
                }
            }
        static void Main(string[] args)
            {
                Int32 npares = 0;
                string palavra1 = "";
                string palavra2 = "";
                Int32 i = 0;

                Console.WriteLine("Informe a quantidade de pares que serão lidos");

                npares = LerNumeroInteirop();

                for (i = 1; i <= npares;i++)
                {
                    Console.WriteLine("Digite a {0} dupla de palavras",i);
                    Console.Write("Palavra 1 > ");
                    palavra1 = Console.ReadLine();
                    
                    
                    Console.Write("Palavra 2 > ");
                    palavra2 = Console.ReadLine();

                    palavra1 = TirarAcetosMinusculo(palavra1);
                    palavra2 = TirarAcetosMinusculo(palavra2);
                        
                    IgualDiferemte(palavra1, palavra2,i);
     
                }
            }
    }
}

