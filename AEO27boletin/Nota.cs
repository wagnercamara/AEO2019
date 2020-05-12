using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO27boletin
{
    public class Nota
    {
        private Disciplina disciplina { get; set; }
        private Double notaAluno { get; set; }

        public override Boolean Equals(Object obj)
        {
            return this.disciplina.Equals(((Nota)obj).disciplina);
        }
        public void setNota(Double nota)
        {
            this.notaAluno = nota;
        }
        public void setDisciplina(Disciplina obj)
        {
            this.disciplina = obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format($"{this.disciplina.ToString()} - {this.notaAluno} {calculo(this.notaAluno)}");
        }
        private String calculo(Double nota)
        {
            if (nota >= 6.5)
            {
                return string.Format("Aprovado");
            }
            return string.Format("Reprovado");
        }

    }
}