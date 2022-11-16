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
                
            }
        }
        
        private void DeleteCar(object sender, RoutedEventArgs e)
        {
            if(listacoches.SelectedItem != null)
            {
                string messageBoxTextdelete = "¿Está seguro de eliminar el vehiculo con matricula ?";
                string captiondelete = "Eliminar";
                MessageBoxButton buttondelete = MessageBoxButton.YesNo;
                MessageBoxImage icondelete = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTextdelete, captiondelete, buttondelete, icondelete, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    listacoches.Items.Remove(listacoches.SelectedItem);
                    listacoches.Items.Refresh();
                }
            }
            else
            {
                string messageBoxTextcheck = "Por favor, seleccione un elemento de la lista.";
                MessageBoxButton buttoncheck = MessageBoxButton.OK;
                MessageBoxImage iconcheck = MessageBoxImage.Exclamation;
                MessageBoxResult resultcheck;
                resultcheck = MessageBox.Show(messageBoxTextcheck, "Error", buttoncheck, iconcheck, MessageBoxResult.OK);
            }

        }
        private void AddFuel(object sender, RoutedEventArgs e)
        {

        }
    }
}