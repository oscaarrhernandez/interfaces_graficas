using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_final
{
    public class Repostaje
    {
        public float Kilometraje { get; set; } 
        public float Coste { get; set; }
        public DateTime Fecha { get; set; }
        public float Litros { get; set; }

        public Repostaje(float kilometraje, float coste, DateTime fecha, float litros)
        {
            Kilometraje = kilometraje;
            Coste = coste;
            Fecha = fecha;
            Litros = litros;
        }
    }
}
