using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAIZ
{
    class Program
    {
        static Double Raiz(Double x1)
        {
            Double xn = 0;
            Double r_num = x1;
            Double pausa = x1;
            x1 = (x1 / 2);
            while (pausa != xn)
            {
                pausa = x1;
                xn = (x1 - ((x1 * x1) - r_num) / (2 * x1));
                x1 = xn;
            }
            return x1;
        }

        static void Main(string[] args)
        {
            Double num = Convert.ToDouble(Console.ReadLine());
            Double resultado = Raiz(num);
            Console.WriteLine(resultado);
        }
    }
}