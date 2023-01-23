using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Interfaces_Graficas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tablas t;
        ObservableCollection<Automovil> lstautos = new ObservableCollection<Automovil>();
        bool change = true;
        Automovil select;
        public MainWindow()
        {
            InitializeComponent();
            t = new Tablas(lstautos);
            t.Show();
            lstautos.CollectionChanged += Lstautos_CollectionChanged;
            t.AutoSeleccionado += AutoSelect;
        }
        void AutoSelect(object sender, AutoSeleccionadoEventArgs e)
        {
            change = false;
            Mostrar_Grafico(e.auto);
            select = e.auto;
        }
        private void Lstautos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Automovil newItem in e.NewItems)
                {
                    newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
            }
            if (e.OldItems != null)
            {
                foreach (Automovil oldItem in e.OldItems)
                {

                    oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            Grafica();
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (change == true)
            {
                Grafica();
            }
            else
            {
                Mostrar_Grafico(select);
            }
        }

        private void Grafica()
        {
            if (change == true)
            {
                //LIMPIAMOS EL CANVAS
                CanvaFondo.Children.Clear();
                //METODO DE GENERAR LA GRÁFICA
                int i;
                String mat;
                float km, kmmax = 0;
                float coste, costemax = 0;
                float consumo, consumomax = 0;
                int columnas = lstautos.Count();
                float[] posdatos;
                posdatos = new float[10];
                float[] datoskm; datoskm = new float[10];
                float[] datoslitros; datoslitros = new float[10];
                float[] datoscoste; datoscoste = new float[10];
                float altocanva = (float)CanvaFondo.ActualHeight;
                float anchocanva = (float)CanvaFondo.ActualWidth;
                
                double dist = 0;
                foreach (Automovil item in lstautos)
                {
                    if (kmmax <= item.Kilometro)
                    {
                        kmmax = item.Kilometro;
                    }
                    if (costemax <= item.MediaCoste100)
                    {
                        costemax = item.MediaCoste100;
                    }
                    if (consumomax <= item.MediaConsumo100)
                    {
                        consumomax = item.MediaConsumo100;
                    }
                }
                for (int k = 0; k < 10; k++)
                {
                    posdatos[k] = (altocanva)/10 * k;
                    datoskm[k] = (kmmax / 10) * (k+1);
                    datoslitros[k] = (consumomax / 10) * (k+1);
                    datoscoste[k] = (costemax / 10) * (k+1);
                    TextBlock datakm = new TextBlock
                    {
                        Text = "-" + datoskm[k].ToString("0.#"),
                        Foreground = Brushes.Blue,
                    };
                    TextBlock datalitros = new TextBlock
                    {
                        Text = datoslitros[k].ToString("0.#") + "-",
                        Foreground = Brushes.DarkGreen,
                    };
                    TextBlock datacoste = new TextBlock
                    {
                        Text = "-" + datoscoste[k].ToString("0.#"),
                        Foreground = Brushes.Red,
                    };
                    CanvaFondo.Children.Add(datakm);
                    CanvaFondo.Children.Add(datalitros);
                    CanvaFondo.Children.Add(datacoste);

                    Canvas.SetBottom(datakm, posdatos[k]+15);
                    Canvas.SetRight(datakm, -20);

                    Canvas.SetBottom(datalitros, posdatos[k] + 15);
                    Canvas.SetLeft(datalitros, -20);

                    Canvas.SetBottom(datacoste, posdatos[k] + 15);
                    Canvas.SetLeft(datacoste, 4);

                }

                for (i = 0; i < columnas; i++)
                {
                    Automovil item = lstautos[i];

                    mat = item.Matricula;
                    km = item.Kilometro;
                    consumo = item.MediaConsumo100;
                    coste = item.MediaCoste100;
                    TextBlock matCoche = new TextBlock
                    {
                        Text = mat,
                        FontSize = 10,
                        Width = 60,
                    };
                    
                    Rectangle KMrectangle = new Rectangle();
                    KMrectangle.Height = ((((altocanva - 20) * km) / kmmax));
                    KMrectangle.Width = 20;
                    KMrectangle.Fill = new SolidColorBrush(Colors.Blue);
                    KMrectangle.Stroke = new SolidColorBrush(Colors.Transparent);
                    KMrectangle.StrokeThickness = 1;
                    
                    Rectangle CONSUMOrectangle = new Rectangle();
                    CONSUMOrectangle.Height = ((((altocanva - 20) * consumo) / consumomax));
                    CONSUMOrectangle.Width = 20;
                    CONSUMOrectangle.Fill = new SolidColorBrush(Colors.DarkGreen);
                    CONSUMOrectangle.Stroke = new SolidColorBrush(Colors.Transparent);
                    CONSUMOrectangle.StrokeThickness = 1;

                    Rectangle COSTErectangle = new Rectangle();
                    COSTErectangle.Height = ((((altocanva - 20) * coste) / costemax));
                    COSTErectangle.Width = 20;
                    COSTErectangle.Fill = new SolidColorBrush(Colors.Red);
                    COSTErectangle.Stroke = new SolidColorBrush(Colors.Transparent);
                    COSTErectangle.StrokeThickness = 1;



                    CanvaFondo.Children.Add(matCoche);
                    CanvaFondo.Children.Add(COSTErectangle);
                    CanvaFondo.Children.Add(CONSUMOrectangle);
                    CanvaFondo.Children.Add(KMrectangle);
                   
                    dist = i*80+10;
                    //MATRICULA
                    Canvas.SetBottom(matCoche, 0);
                    Canvas.SetLeft(matCoche, dist+50);
                    //COSTE
                    Canvas.SetBottom(COSTErectangle, 15);
                    Canvas.SetLeft(COSTErectangle, dist+20);
                    //CONSUMO
                    Canvas.SetBottom(CONSUMOrectangle, 15);
                    Canvas.SetLeft(CONSUMOrectangle, dist+40);
                    //KM
                    Canvas.SetBottom(KMrectangle, 15);
                    Canvas.SetLeft(KMrectangle, dist+60);

                }
            } 
        }

        void Mostrar_Grafico(Automovil select)
        {
            change = false;
            CanvaFondo.Children.Clear();
            int numfechas = select.Repostaje.Count();
            List<Repostaje> repostsort = select.Repostaje.OrderBy(Repostaje => Repostaje.Fecha).ToList();
            float kmmax=0,costemax=0,litrosmax=0;
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;
            float[] posdatos;
            posdatos = new float[10];
            float[] datoskm; datoskm = new float[10];
            float[] datoslitros; datoslitros = new float[10];
            float[] datoscoste; datoscoste = new float[10];
            Polyline grkm = new Polyline();
            Polyline grcoste = new Polyline();
            Polyline grlitros = new Polyline();
            grcoste.Stroke = Brushes.Red;
            grkm.Stroke = Brushes.Blue;
            grlitros.Stroke = Brushes.DarkGreen;
            Point[] kmpuntos = new Point[numfechas];
            Point[] costepuntos = new Point[numfechas];
            Point[] litrospuntos = new Point[numfechas];
            double dist = 0;
            foreach (Repostaje item in repostsort)
            {
                if (kmmax <= item.Kilometraje)
                {
                    kmmax = item.Kilometraje;
                }
                if (costemax <= item.Coste)
                {
                    costemax = item.Coste;
                }
                if (litrosmax <= item.Litros)
                {
                    litrosmax = item.Litros;
                }

            }
            for (int k = 0; k < 10; k++)
            {
                posdatos[k] = (altocanva) / 10 * k;
                datoskm[k] = (kmmax / 10) * (k + 1);
                datoslitros[k] = (litrosmax / 10) * (k + 1);
                datoscoste[k] = (costemax / 10) * (k + 1);
                TextBlock datakm = new TextBlock
                {
                    Text = "- " + datoskm[k].ToString(),
                    Foreground = Brushes.Blue,
                };
                TextBlock datalitros = new TextBlock
                {
                    Text = datoslitros[k].ToString() + "-",
                    Foreground = Brushes.DarkGreen,
                };
                TextBlock datacoste = new TextBlock
                {
                    Text = "-" + datoscoste[k].ToString(),
                    Foreground = Brushes.Red,
                };
                CanvaFondo.Children.Add(datakm);
                CanvaFondo.Children.Add(datalitros);
                CanvaFondo.Children.Add(datacoste);

                Canvas.SetBottom(datakm, posdatos[k] + 15);
                Canvas.SetRight(datakm, -20);

                Canvas.SetBottom(datalitros, posdatos[k] + 15);
                Canvas.SetLeft(datalitros, -20);

                Canvas.SetBottom(datacoste, posdatos[k] + 15);
                Canvas.SetLeft(datacoste, 0);

            }
            for (int i = 0; i < numfechas; i++)
            {
                Repostaje item = repostsort[i];
                String fecha = item.Fecha.ToString("dd/M/yyyy");
                TextBlock fechaCoche = new TextBlock
                {
                    Text = fecha,
                    FontSize = 10,
                    Width = 60,
                };
                float km = item.Kilometraje;
                float litros = item.Litros;
                float coste = item.Coste;
                


                CanvaFondo.Children.Add(fechaCoche);
                dist = (i*60)+((i+1)*20);
                //FECHA
                Canvas.SetBottom(fechaCoche, 0);
                Canvas.SetLeft(fechaCoche, dist);

                kmpuntos[i].X = dist+30;
                kmpuntos[i].Y = (altocanva-20)-(km*altocanva/kmmax) + 20;
                litrospuntos[i].X = dist + 30;
                litrospuntos[i].Y = (altocanva-20) - (litros * altocanva / litrosmax) + 20;
                costepuntos[i].X = dist + 30;
                costepuntos[i].Y = (altocanva-20) - (coste * altocanva / costemax) + 20;
            }
            grkm.Points = new PointCollection(kmpuntos);
            grlitros.Points = new PointCollection(litrospuntos); 
            grcoste.Points = new PointCollection(costepuntos);
            CanvaFondo.Children.Add(grkm);
            CanvaFondo.Children.Add(grlitros);
            CanvaFondo.Children.Add(grcoste);
        }

        private void Mostrar_Grafico_Todos(object sender, RoutedEventArgs e)
        {
            change = true;
            Grafica();          
        }

        private void WindowsClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            t.Close();
        }
        private void Mostrar_Tablas(object sender, RoutedEventArgs e)
        {
            if (t.Visibility == Visibility.Visible)
            {
                t.Hide();
            }
            else
            {
                t.Show();
            }
        }

        private void Exportar(object sender, RoutedEventArgs e)
        {
            var exploradorArchivos = new SaveFileDialog();
            exploradorArchivos.Filter = "Archivo Binario | .bin";
            exploradorArchivos.DefaultExt = "bin";

            if (exploradorArchivos.ShowDialog() == true)
            {

                FileStream fs = new FileStream(exploradorArchivos.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, lstautos);
                fs.Close();
            }
        }
        private void Importar(object sender, RoutedEventArgs e)
        {
            var exploradorArchivos = new OpenFileDialog();
            exploradorArchivos.Filter = "Archivo Binario |.bin";
            exploradorArchivos.DefaultExt = "bin";
            if (exploradorArchivos.ShowDialog() == true)
            {
                FileStream fs = new FileStream(exploradorArchivos.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                ObservableCollection<Automovil> importbinlst = (ObservableCollection<Automovil>)bf.Deserialize(fs);
                foreach (Automovil auto in importbinlst)
                {
                    lstautos.Add(auto);
                }
            }
        }

    }
}
