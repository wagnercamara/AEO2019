using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao4
{
    public class Voo
    {
        private List<Cidade> cidades = new List<Cidade>();
        private List<Reserva> reservas = new List<Reserva>();
        private Int32 codigoVoo { get; set; }
        private Int32 numeroAcentos { get; set; }

        public Voo(Int32 codigo)
        {
            this.codigoVoo = codigo;
        }
        public override Boolean Equals(Object obj)
        {
            return this.codigoVoo.Equals(((Voo)obj).codigoVoo);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void setCidade(Cidade obj)
        {
            this.cidades.Add(obj);
        }
        public void setAcentos(Int32 numero)
        {
            this.numeroAcentos = numero;
        }
        public Int32 getNumeroAcentos()
        {
            return this.numeroAcentos;
        }
        public Boolean faserReserva(Int32 numeroPoltrona, Passageiro passageiro)
        {
            Reserva r1 = new Reserva(numeroPoltrona);

            if (this.reservas.IndexOf(r1) >= 0)
            {
                return false;
            }
            r1.setPassageiro(passageiro);
            this.reservas.Add(r1);
            return true;
        }
        public void ExibirAcentos()
        {
            Console.WriteLine($"\nVoo Partindo de {cidades[0].ToString()} com destino a {cidades[1].ToString()}\n");

            Reserva r1;
            for (Int32 i = 0; i < this.numeroAcentos; i++)
            {
                r1 = new Reserva(i + 1);
                Int32 posicao = reservas.IndexOf(r1);

                if (posicao>= 0)
                {
                    Console.WriteLine(string.Format($"{i + 1} - {reservas[posicao].ToString()}"));
                }
                else
                {
                    Console.WriteLine(string.Format($"{i + 1} - Livre"));
                }
            }
            Console.WriteLine();
        }
    }
}