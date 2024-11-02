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

        public Vehiculo this[string patente]
        {
            get
            {
                ListaVehiculos.Sort();
                Vehiculo v = new Vehiculo(patente, null);
                int idx = ListaVehiculos.BinarySearch(v);

                if (idx >= 0)
                    return ListaVehiculos[idx];
                return null;
            }
        }

        public void AgregarTicket (Ticket turno)
        {
            ListaAtendidos.Add(turno);
        }

        public Ticket AtenderTicket(int tipo, int dni)
        {
            if (tipo == 1)
            { }
            else if (tipo == 2)
            {
            }
            else if (tipo == 3)
            { }
            else if (tipo == 4)
            { }

            return null;
        }
    }
}
