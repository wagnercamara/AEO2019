using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO27boletin
{
    public class Aluno
    {
        private List<Nota> notas = new List<Nota>();
        private Int32 codigo { get; set; }
        private String nomeAlu { get; set; }
        public Aluno(Int32 codigo)
        {
            this.codigo = codigo;
        }
        public override Boolean Equals(Object obj)
        {
            return this.codigo.Equals(((Aluno)obj).codigo);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format($"{this.nomeAlu} {(this.codigo)}");
        }
        public void exibirNotas()
        {
            for (Int32 i = 0; i < notas.Count; i++)
            {
                Console.WriteLine(notas[i]);
            }
        }
        public void setNomeAlu(String nome)
        {
            this.nomeAlu = nome;
        }
        public Boolean lancarNota(Disciplina obj, Double nota)
        {
            Nota n1 = new Nota();
            Int32 posicao = notas.IndexOf(n1);
            if (posicao < 0)
            {
                Console.WriteLine("Entrei no if");
                n1.setDisciplina(obj);
                n1.setNota(nota);
                notas.Add(n1);
                return true;
            }
            return false;
        }
    }
}