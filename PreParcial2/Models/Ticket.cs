using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreParcial2.Models
{
    internal abstract class Ticket
    {
        protected int nroOrden {  get; set; }
        private DateTime fechaHora { get { return DateTime.Today; } }

        public int VerNro()         { return nroOrden; }

        public DateTime VerHora() 
        
        { return fechaHora; }

    }
}
