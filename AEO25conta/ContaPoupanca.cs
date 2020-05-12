using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO25conta
{
    public class ContaPoupanca : Conta
    {
        private Double taxaJuros {get;set;}
        public ContaPoupanca(Int32 numero) : base(numero){}
        public void setJuros(Double valor)
        {
            this.taxaJuros = valor;
        }
        public Double getJuros()
        {
            return this.taxaJuros;
        }
        public void consultarRendimeto()
        {
            Console.WriteLine($"Saldo Anterior: {getSaldo():c}\nRendimento: {((getSaldo()*this.taxaJuros)/100):c}\nNovo Saldo: {getSaldo() + ((getSaldo()*this.taxaJuros)/100):c}\nTaxadejuros:{this.taxaJuros}%");
            this.depositar(((this.getSaldo()*this.taxaJuros)/100),'r');
        }        
    }
}