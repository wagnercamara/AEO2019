using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO24conta
{
    public class ContaPolpanca : Conta
    {
        public ContaPolpanca(Int32 numero) : base (numero){}

        public override Boolean sacar(double valor)
        {
            double x = this.getSaldo();
            if((x - valor )>= 0)
            {
                base.sacar(valor);
                return true;
            }
            return false;
        }
        //public override string ToString()
        //{
        //    return Convert.ToString(String.Format("cp - saldo:{0:c}",getSaldo()));
        //}
    }  
}
