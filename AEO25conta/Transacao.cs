using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO25conta
{
    public class Transacao
    {
        private String tipo {get;set;}
        private DateTime dataHora {get;set;}
        private Double valor{get;set;}
        private Double saldoAtual{get;set;}
        private Double saldoDepois{get;set;}

        public void setTipo (String nome)
        {
            this.tipo = nome;
        }
        public void setDataHora (DateTime data)
        {
            this.dataHora = data;    
        }

        public void setValor (Double valor)
        {
            this.valor = valor;
        }
        public void setSaldoAtual (Double valor)
        {
            this.saldoAtual = valor;
        }
        public void setSaldoDepois (Double valor)
        {
            this.saldoAtual = valor;
        }
        public String tipoTrasacao ()
        {
            return this.tipo;
        }
        public String dataHoraTransacao ()
        {
            return this.dataHora.ToString();
        }
        public Double valorTransacao()
        {
            return this.valor;
        }
        public Double saldoAtualTrasacao()
        {
            return this.saldoAtual;
        }
        public Double saldoDepoisTransacao()
        {
            return this.saldoDepois;
        }

        public override String ToString()
        {
            return String.Format($"{this.dataHoraTransacao()} {this.tipoTrasacao()} {this.valorTransacao():c}");
        }    
    }

}