using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO24conta
{
    public class ContaCorrente:Conta
    {
        private Double Limite {get; set;}
        public ContaCorrente(Int32 numero) : base (numero){}
        public void LimiteConta(Double Valor)
        {
            this.Limite = this.Limite + Valor;
        }
        public override Boolean sacar(double valor)
        {
            double x = this.getSaldo();
            if(((x + this.Limite) - valor )>= 0)
            {
                base.sacar(valor);
                return true;
            }
            return false;
        }
        //public override string ToString()
        //{
        //    return Convert.ToString(String.Format("Limite:{0:c}",this.Limite));
        //}
        public Double gatLimite()
        {
            return this.Limite;
        }
    }
}