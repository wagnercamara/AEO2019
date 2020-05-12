using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO26CorridaObj
{
    public class Corrida
    {
        private Int32 NumeroCorrida { get; set; }
        private List<Pontuacao> PontuacaoCorrida;

        public Corrida(Int32 numero)
        {
            this.PontuacaoCorrida = new List<Pontuacao>();
            this.NumeroCorrida = numero;
        }

        public override Boolean Equals(Object obj)
        {
            return this.NumeroCorrida.Equals(((Corrida)obj).NumeroCorrida);
        }
        public void SetPontuacaoCorrida(Pontuacao pontuacao)
        {
            Int32 posicao = this.PontuacaoCorrida.IndexOf(pontuacao);



            if (posicao >= 0) // atualizando lista;
            {

                this.PontuacaoCorrida[posicao].SetValorPontuacao(pontuacao.GetValorPontuacao());

            }
            else // criando novo abjeto;
            {
                Pontuacao pontuacaolista = new Pontuacao(pontuacao.GetPilotoPontuacao());
                pontuacaolista.SetValorPontuacao(pontuacao.GetValorPontuacao());
                this.PontuacaoCorrida.Add(pontuacaolista);

            }
        }
        public Int32 GetNumeroCorrida()
        {
            return this.NumeroCorrida;
        }
        public void GetResultado(List<Piloto> pilotos)
        {
            if (this.PontuacaoCorrida.Count > 0)
            {
                foreach (Piloto piloto in pilotos)
                {
                    Pontuacao pontuacao = new Pontuacao(piloto);
                    Int32 posicao = this.PontuacaoCorrida.IndexOf(pontuacao);
                    if (posicao >= 0)
                    {
                        pontuacao.SetValorPontuacao(this.PontuacaoCorrida[posicao].GetValorPontuacao());
                        this.PontuacaoCorrida[posicao] = pontuacao;
                    }
                    else
                    {
                        Pontuacao pontuacaolista = new Pontuacao(pontuacao.GetPilotoPontuacao());
                        this.PontuacaoCorrida.Add(pontuacaolista);
                    }
                }
                this.PontuacaoCorrida.Sort();
                foreach (Pontuacao pontuacao in this.PontuacaoCorrida)
                {
                    Console.WriteLine($"{(this.PontuacaoCorrida.IndexOf(pontuacao) + 1)}ºlugar {pontuacao}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum pontuação registrada!");
            }
        }
    }
}