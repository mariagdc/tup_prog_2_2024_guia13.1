using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PreParcial2.Models
{
    internal class AgenciaControllers
    {
        public List<Ticket> ListaAtendidos = new List<Ticket>();
        public List<Vehiculo> ListaVehiculos = new List<Vehiculo>();
        public Queue<Denuncia> denuncias = new Queue<Denuncia>();
        public Queue<Cliente> nuevos = new Queue<Cliente>();

        public Ticket this[int idx]
        {
            get
            {
                if (idx >= 0 && idx < ListaAtendidos.Count)
                    return ListaAtendidos[idx];
                return null;
            }
        }



    }
}
