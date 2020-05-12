using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao4
{
    [Serializable]
    public class Cidade
    {
        private Int32 codigoCidade { get; set; }
        private String nomeCidade { get; set; }

        public Cidade(Int32 codigo)
        {
            this.codigoCidade = codigo;
        }
        public override Boolean Equals(Object obj)
        {
            return this.codigoCidade.Equals(((Cidade)obj).codigoCidade);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.nomeCidade;
        }

        public void setNomeCidade(String nome)
        {
            this.nomeCidade = nome;
        }
    }
}