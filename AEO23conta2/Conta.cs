using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO23conta2
{
    public class Conta
    {
        private Double saldo {get;set;}
        private Int32 numeroConta{get;set;}
        private string historico{get;set;}
        public Conta(Int32 numero) // pasando coisas ao contrutor.
        {
            this.numeroConta = numero;
        }
        public override bool Equals(object obj)
        {
            return this.numeroConta.Equals(((Conta)obj).numeroConta);
            //if(obj is Conta)
            //{
            //    if(this.numeroConta == ((Conta)obj).numeroConta)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
        }
        public override int GetHashCode()
        {
            return this.numeroConta;
        }
        public override string ToString()
        {
            return Convert.ToString(String.Format("Conta:{0} Saldo:{1:c}",this.numeroConta,this.saldo));
        }

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
            String hora = DateTime.Now.ToShortTimeString();
            String data = DateTime.Now.ToShortDateString();
            this.historico = this.historico + string.Format("{0} {1}-Deposito {2:c}\n",data,hora,valor);
        }
        public Boolean sacar (Double valor)
        {
            if (valor <= this.saldo)    
            {
                this.saldo = this.saldo - valor;
                String hora = DateTime.Now.ToShortTimeString();
                String data = DateTime.Now.ToShortDateString();
                this.historico = this.historico + string.Format("{0} {1}-Saque   -{2:c}\n",data,hora,valor);
                return true;
            } 
            return false;
        }
    }
}