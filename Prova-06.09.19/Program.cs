using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_06._09._19
{
    class Program
    {
        static Int32 LerTotalCorrida ()
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
                    Console.WriteLine("Para começar você precisa de no minimo 1 corrida");
                    numeroInteiro = true;
                }
                else
                {
                    numeroPositivo = false;
                }
            }
            return numero;
        }
        static Int32 LerTotalPiloto ()
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
                if(numero < 3)
                {
                    Console.WriteLine("A quantidade de pilotos deve ser de no minimo 3 pilotos");
                    numeroInteiro = true;
                }
                else
                {
                    numeroPositivo = false;
                }
            }
            return numero;
        }
        static Double LerPontuacao ()
        {
            Boolean numeroInteiro = true;
            Boolean numeroPositivo = true;
            Double numero = 0;
            while (numeroPositivo != false)
            {
                while(numeroInteiro != false)
                { 
                    try
                    {
                        numero = Convert.ToDouble(Console.ReadLine());
                        numeroInteiro = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incira apenas numero reais ou inteiros maior que 0");
                        numeroInteiro = true;
                    }
                }
                if(numero < 0)
                {
                    Console.WriteLine("Informe apenas numeros reais ou inteiros maior que 0 ");
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
        static Int32 VemPrimeiro (string piloto1, string piloto2)
        {
            Int32 x = 0;
            x = TirarAcetosMinusculo(piloto1).CompareTo(TirarAcetosMinusculo(piloto2));
            return x;
        }

        static void Main(string[] args)
        {
            Int32 corrida = 0 ;
            
            Double totalCorrida = 0 ;
            string nomePiloto = string.Empty;

            string primeiroLugar = string.Empty;
            string segundoLugar = string.Empty;
            string terceiroLugar = string.Empty;
            Double guardaPrimeiro = 0;
            Double guardaSegundo = 0;
            Double guardaTerceiro = 0;

            Console.WriteLine("Bem vindo ao Podio");
            Console.WriteLine("Para começar incira a quantidade de Corridas");
            Int32 numeroCorrida = LerTotalCorrida();

            Console.WriteLine("Muito bem, agora incira a quantidade de pilotos");
            Console.WriteLine("Obs: você precisa de no minimo 3 pilotos");
            Int32 numeroPilotos = LerTotalPiloto();

            Console.Clear();

            for(Int32 i = 1; i <= numeroPilotos; i++)
            {
                Console.WriteLine("Por favor incira o nome do {0} piloto",i);
                nomePiloto = Console.ReadLine();
                Console.WriteLine("Incira o resultado das coridas abaixo");

                for(corrida = 1; corrida <= numeroCorrida; corrida++)
                {
                   Console.Write("{0}° Corrida > ",corrida); 
                   Double pontoCorrida = LerPontuacao();
                   if (corrida % 2 == 0)
                   {
                       pontoCorrida = pontoCorrida * 2;
                   }
                   
                   totalCorrida = totalCorrida + pontoCorrida;
                }
                
                if (totalCorrida > guardaPrimeiro ||(totalCorrida == guardaPrimeiro && VemPrimeiro(primeiroLugar,nomePiloto)==1))
                {
                    guardaTerceiro = guardaSegundo;
                    terceiroLugar = segundoLugar;

                    guardaSegundo = guardaPrimeiro;
                    segundoLugar = primeiroLugar;

                    guardaPrimeiro = totalCorrida;
                    primeiroLugar = nomePiloto;
                }
                else if (totalCorrida > guardaSegundo ||(totalCorrida == guardaSegundo && VemPrimeiro(segundoLugar,nomePiloto)==1))
                {
                    guardaTerceiro = guardaSegundo;
                    terceiroLugar = segundoLugar;

                    guardaSegundo = totalCorrida;
                    segundoLugar = nomePiloto;
                }
                else if(totalCorrida > guardaTerceiro ||(totalCorrida == guardaSegundo && VemPrimeiro(segundoLugar,nomePiloto)==1))
                {
                    guardaTerceiro = totalCorrida;
                    terceiroLugar = nomePiloto;
                }
                totalCorrida = 0;
            }
        Console.WriteLine("");
        Console.WriteLine("Resultado");
        Console.WriteLine("1° lugar {0}",primeiroLugar);
        Console.WriteLine("--------2° lugar {0}",segundoLugar);
        Console.WriteLine("----------------3° lugar {0}",terceiroLugar);
        }

    }
}
