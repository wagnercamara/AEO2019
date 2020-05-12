using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao4
{
    public class Reserva
    {
        private Int32 numeroDoAceanto { get; set; }
        private Passageiro passageiro { get; set; }

        public Reserva(Int32 numero)
        {
            this.numeroDoAceanto = numero;
        }
        public void setPassageiro(Passageiro obj)
        {
            this.passageiro = obj;
        }
        public override Boolean Equals(Object obj)
        {
            return (this.numeroDoAceanto.Equals(((Reserva)obj).numeroDoAceanto));
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format($"{this.passageiro.ToString()}");
        }
    }
}