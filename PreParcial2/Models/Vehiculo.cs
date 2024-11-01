using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreParcial2.Models
{
    internal class Vehiculo : IComparable<Vehiculo>
    {
        private string nroPatente {  get; set; }

        private Cliente dueño { get; set; }

        public Vehiculo (string nropatente, Cliente dueño)
        {
            this.nroPatente = nropatente;
            this.dueño = dueño;
        }

        public Cliente VerDueño ()
        {
            return dueño;
        }

        public string VerPatente()
        {
            return nroPatente;
        }
        
        public int CompareTo(Vehiculo v)
        {
            Vehiculo vehiculo = v;
            if (vehiculo == null)
            { nroPatente.CompareTo(vehiculo.nroPatente); 
              return 1;}
            return -1;
        }

        public override string ToString()
        {
            return $"{nroPatente}-{dueño}";
        }
    }
}
