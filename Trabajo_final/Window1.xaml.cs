using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Trabajo_final
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void AddCar(object sender, RoutedEventArgs e)
        {
            Agregarcoche newcoche = new Agregarcoche();
            newcoche.ShowDialog();
            if (newcoche.DialogResult == true)
            {
                //controlo subir datos

                listacoches.Items.Add(newcoche.AnadirCoche);
            }
        }
        private void lista_SelectionCoche(object sender, SelectionChangedEventArgs e)
        {
            if(listacoches.SelectedItem != null)
            {
                //Si la lista no está vacia, muestra en la listarepostajes los repostajes de ese coche si existen
            }
        }
        
        private void DeleteCar(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "¿Está seguro de eliminar el vehiculo con matricula?";
            
            string caption = "Eliminar";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;
            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.No);
            if(result == MessageBoxResult.Yes)
            {
                listacoches.Items.Remove(listacoches.SelectedItem);
                listacoches.Items.Refresh();

            }

        }
        private void AddFuel(object sender, RoutedEventArgs e)
        {

        }
    }
}