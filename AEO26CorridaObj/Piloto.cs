using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO26CorridaObj
{
    public class Piloto
    {
        private String NomePiloto { get; set; }
        private Int32 NumeroPiloto { get; set; }
        public Piloto(Int32 numero)
        {
            this.NumeroPiloto = numero;
        }

        public override Boolean Equals(Object obj)
        {
            return this.NumeroPiloto.Equals(((Piloto)obj).NumeroPiloto);
        }

        public override String ToString()
        {
            return $"{this.NomePiloto} ({this.NumeroPiloto})";
        }

        public Int32 GetNumeroPiloto()
        {
            return this.NumeroPiloto;
        }

        public void SetNomePiloto(String nome)
        {
            this.NomePiloto = nome;
        }

        public String GetNomePiloto()
        {
            return this.NomePiloto;
        }
    }
}