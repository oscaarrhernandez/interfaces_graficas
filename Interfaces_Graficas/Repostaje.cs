using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_Graficas
{
    public class Repostaje : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Repostaje(float kilometraje, float coste, DateTime fecha, float litros)
        {
            Kilometraje = kilometraje;
            Coste = coste;
            Fecha = fecha.Date;
            Litros = litros;
        }

        float kilometraje;
        float coste;
        DateTime fecha;
        float litros;

        public float Kilometraje { 
            get { return kilometraje; } 
            set { kilometraje = value; OnPropertyChanged("Kilometraje"); } 
        }
        public float Coste { 
            get { return coste; } 
            set { coste = value; OnPropertyChanged("Coste"); } 
        }
        public DateTime Fecha { 
            get { return fecha; } 
            set { fecha = value; OnPropertyChanged("Fecha"); } 
        }
        public float Litros { 
            get { return litros; } 
            set { litros = value; OnPropertyChanged("Litros"); } 
        }

        void OnPropertyChanged(String propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
