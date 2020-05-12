using System;

namespace AEO22conta
{
    public class Conta
    {
        protected double saldo {get;set;}

        public void imprimir()
        {
            Console.WriteLine("Saldo: R${0}",this.saldo);
        }
        public Double valorSaldo()
        {
            return this.saldo;
        }
        public void depositar (Double valor)
        {
            this.saldo = this.saldo + valor;
            Console.WriteLine("Saldo {0}",this.saldo);
        }
        public Boolean sacar (Double valor)
        {
            if (valor <= this.saldo)    
            {
                this.saldo = this.saldo - valor;
                return true;
            } 
            return false;
        }
    }
}