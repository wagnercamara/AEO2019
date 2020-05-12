using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO25conta
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente(Int32 numero) :base(numero){}
        public void LimiteConta(Double Valor)
        {
            this.Limite = this.Limite + Valor;
        }
        public Double gatLimite()
        {
            return this.Limite;
        }
        private Double Limite {get;set;}
        protected override Boolean PodeSacar(double valor)
        {
            if(((getSaldo() + Limite) - valor) >= 0)
            {
                return true;
            }
            return false;
        }

    }
}