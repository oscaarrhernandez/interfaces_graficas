using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_final
{
    public class Coche
    {
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public float Kilometro { get; set; }
        public List<Repostaje> repostaje { get; set; }

        public Coche(string matricula, string marca, float kilometro, List<Repostaje> repostaje)
        {
            Matricula = matricula;
            Marca = marca;
            Kilometro = kilometro;
            this.repostaje = repostaje;
        }
    }
}
