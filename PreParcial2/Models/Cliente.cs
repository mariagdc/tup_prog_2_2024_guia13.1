using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreParcial2.Models
{
    internal class Cliente : Ticket
    {
        private long DNI;
        private static int numero;
        
        private object ex;

        public Cliente(long dNI)
        {
            string dni = Convert.ToString(dNI);

            if (dni.Length != 8)
            {
                throw new Exception("El DNI debe tener exactamente 8 dígitos numéricos.");
      
            }
            else
            { DNI = Convert.ToInt64(dni); }


        //Si el DNI tiene 8 dígitos numéricos, continuará con el resto del código
        
         catch (Exception ex)
            {
                // Código a ejecutar si ocurre una excepción
                Console.WriteLine($"Ha ocurrido un error: {ex.Message}");
            }

        }

        //for (int c = dNI. ((char)dNI)) {
        //DNI = dNI;
    }
    }
}
