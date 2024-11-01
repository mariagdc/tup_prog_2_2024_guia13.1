using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PreParcial2.Models
{
    internal class Denuncia : Ticket
    {
        private Vehiculo dominio;

        public Denuncia (Vehiculo asegurado)
        { dominio = asegurado; }
    
        public string ToString()
        {
            return $"{dominio}";
        }
    }
}
