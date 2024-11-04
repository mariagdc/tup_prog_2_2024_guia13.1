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
            if (turno != null)
            {
                if (turno is Denuncia)
                {
                    denuncias.Enqueue((Denuncia)turno);
                }
                else if (turno is Cliente)
                {
                    nuevos.Enqueue((Cliente)turno);
                }
            }
        }

        public Ticket AtenderTicket(int tipo, int dni)
        {
            Ticket atendido = null;
            
            if (tipo == 0)
            {
                if (denuncias.Count > 0)
                { atendido = denuncias.Dequeue(); }
            }
            else if (tipo == 1)
            {
                if (nuevos.Count > 0)
                { atendido = nuevos.Dequeue(); }

            }

            if (atendido != null)
            {
                ListaAtendidos.Add (atendido);
            }

            return atendido;
        }

        public void AgregarVehiculo (string nroPatente, int dniDueño)
        {
            Vehiculo nuevo = this[nroPatente];
            if (nuevo == null)
            {
                Cliente cliente = new Cliente(dniDueño);
                nuevo = new Vehiculo(nroPatente, cliente);
                ListaVehiculos.Add(nuevo);
            }
        }
    }
}
