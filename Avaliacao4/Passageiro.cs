using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao4
{
    [Serializable]
    public class Passageiro
    {
        private Int32 codigoEmbarque { get; set; }
        private String nomePassageiro { get; set; }

        public Passageiro(Int32 codigo) // construtor
        {
            this.codigoEmbarque = codigo;
        }

        public override Boolean Equals(Object obj) // comparação
        {
            return this.codigoEmbarque.Equals(((Passageiro)obj).codigoEmbarque);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString() // toStrng
        {
            return (string.Format($"{this.nomePassageiro} - ({this.codigoEmbarque})"));
        }

        public void setNomePassageiro(String nome)
        {
            this.nomePassageiro = nome;
        }
    }
}