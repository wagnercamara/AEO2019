using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO25conta
{
    public class Conta
    {
        private List<Transacao> transacoes = new List<Transacao>();
        private Int32 numeroConta { get; set; }
        private Double saldo { get; set; }

        public Conta(Int32 numero) // pasando numero ao contrutor.
        {
            this.numeroConta = numero;
        }
        public override bool Equals(Object obj)
        {
            return this.numeroConta.Equals(((Conta)obj).numeroConta);
        }
        public override int GetHashCode()
        {
            return this.numeroConta;
        }

        public virtual void depositar(Double valor, char tipo = 'd')
        {
            Transacao TDeposito = new Transacao();
            TDeposito.setSaldoAtual(this.saldo);
            if (tipo == 'r')
            {
                TDeposito.setTipo("Rendimento");
            }
            else
            {
                TDeposito.setTipo("Deposito");
            }
            TDeposito.setValor(valor);
            TDeposito.setDataHora(DateTime.Now);

            this.saldo = this.saldo + valor;

            TDeposito.setSaldoDepois(this.saldo);
            transacoes.Add(TDeposito);
        }

        //saque
        protected virtual Boolean PodeSacar(Double valor)
        {
            if (this.saldo - valor >= 0)
            {
                return true;
            }
            return false;
        }
        public Boolean sacar(Double valor)
        {
            if (PodeSacar(valor) == true)
            {
                Transacao TSaque = new Transacao();
                TSaque.setSaldoAtual(this.saldo);
                TSaque.setTipo("Saque");
                TSaque.setValor(valor);
                TSaque.setDataHora(DateTime.Now);
                this.saldo = this.saldo - valor;
                TSaque.setSaldoDepois(this.saldo);
                transacoes.Add(TSaque);
                return true;
            }
            return false;
        }

        public Double getSaldo()
        {
            return this.saldo;
        }

        public void getTrasacao()
        {
            for (int i = 0; i < transacoes.Count; i++)
            {
                Console.WriteLine(transacoes[i]);
            }
            Console.WriteLine("____________________________________");
            Console.WriteLine($"Saldo:               {this.saldo:c}");
        }
    }
}