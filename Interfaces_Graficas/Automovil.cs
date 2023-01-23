using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_Graficas
{
    public class Automovil : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Automovil(string matricula, string marca, float kilometro, ObservableCollection<Repostaje> repostaje, float mediaConsumo100, float mediaCoste100)
        {
            Matricula = matricula;
            Marca = marca;
            Kilometro = kilometro;
            Repostaje = repostaje;
            MediaConsumo100 = mediaConsumo100;
            MediaCoste100 = mediaCoste100;
        }

        string matricula;
        string marca;
        float kilometro;
        float mediaConsumo100;
        float mediaCoste100;
        ObservableCollection<Repostaje> repostajees;

        public string Matricula { 
            get { return matricula; }
            set { matricula = value; OnPropertyChanged("Matricula"); }
        }
        public string Marca
        {
            get { return marca; }
            set { marca = value; OnPropertyChanged("Marca"); }
        }
        public float Kilometro
        {
            get { return kilometro; }
            set { kilometro = value; OnPropertyChanged("Kilometro"); }
        }

        public ObservableCollection<Repostaje> Repostaje { 
            get{ return repostajees; }
            set { repostajees = value; OnPropertyChanged("Repostaje"); }
        }
        public float MediaConsumo100 { 
            get { return mediaConsumo100; } 
            set { mediaConsumo100 = value; OnPropertyChanged("mediaConsumo100"); }
        }
        public float MediaCoste100 { 
            get { return mediaCoste100; }
            set { mediaCoste100 = value; OnPropertyChanged("mediaCoste100"); } 
        }


        void OnPropertyChanged(String propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
