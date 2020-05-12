using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO27boletin
{
    public class Disciplina
    {
        private Int32 codigo {get;set;}
        private string nomeDis {get; set;}
        public Disciplina(Int32 codigo)
        {
            this.codigo = codigo;
        }
        public override Boolean Equals(Object obj)
        {
            return this.codigo.Equals(((Disciplina)obj).codigo);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format($"{this.nomeDis}");
        }
        public void setNomeDis(String nome)
        {
            this.nomeDis = nome;
        }
    }
}