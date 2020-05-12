using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace AEO22conta
{
    public class Conta
    {
        private double saldo {get;set;}
        protected string historico{get;set;}

        public void imprimir()
        {
            Console.WriteLine("Historico:\n");
            Console.WriteLine(this.historico);
            Console.WriteLine("_________________________________");
            Console.WriteLine("Saldo:                    {0:c}",this.saldo);
        }
        public void depositar (Double valor)
        {
            this.saldo = this.saldo + valor;
            Console.WriteLine("Saldo {0}",this.saldo);
            String hora = DateTime.Now.ToShortTimeString();
            String data = DateTime.Now.ToShortDateString();
            this.historico = this.historico + string.Format("{0} {1}-Deposito {2}\n",data,hora,valor.ToString("C",CultureInfo.CurrentCulture));
        }
        public Boolean sacar (Double valor)
        {
            if (valor <= this.saldo)    
            {
                this.saldo = this.saldo - valor;
                String hora = DateTime.Now.ToShortTimeString();
                String data = DateTime.Now.ToShortDateString();
                this.historico = this.historico + string.Format("{0} {1}-Saque   -{2}\n",data,hora,valor.ToString("C",CultureInfo.CurrentCulture));
                return true;
            } 
            return false;
        }
    }
}