using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO26CorridaObj
{
    public class Pontuacao : IComparable<Pontuacao> // copareTO
    {
        private Int32 ValorPontuacao { get; set; }
        private Piloto PilotoPontuacao { get; set; }
        public Pontuacao(Piloto piloto)
        {
            this.PilotoPontuacao = piloto;
        }
        public override Boolean Equals(Object obj)
        {
            return this.PilotoPontuacao.Equals(((Pontuacao)obj).PilotoPontuacao);
        }
        public int CompareTo(Pontuacao comparador)
        {
            if (this.ValorPontuacao < comparador.ValorPontuacao)
            {
                return 1;
            }
            if (this.ValorPontuacao == comparador.ValorPontuacao)
            {
                return 0;
            }
            return -1;
        }
        public override String ToString()
        {
            if (this.ValorPontuacao == 0)
            {
                return $"{this.PilotoPontuacao} -> sem pontuação";
            }
            else
            {
                return $"{this.PilotoPontuacao} -> {this.ValorPontuacao} pontos";
            }
        }
        public void SetValorPontuacao(Int32 valor)
        {
            this.ValorPontuacao = valor;
        }
        public Int32 GetValorPontuacao()
        {
            return this.ValorPontuacao;
        }
        public Piloto GetPilotoPontuacao()
        {
            return this.PilotoPontuacao;
        }
    }
}