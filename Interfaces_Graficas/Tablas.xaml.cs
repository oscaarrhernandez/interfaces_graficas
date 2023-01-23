using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Interfaces_Graficas
{
    /// <summary>
    /// Lógica de interacción para Tablas.xaml
    /// </summary>
    public class AutoSeleccionadoEventArgs : EventArgs
    {
        public Automovil auto { get; set; }

        public AutoSeleccionadoEventArgs(Automovil a)
        {
            auto = a;
        }
    }
    public partial class Tablas : Window
    {
        public event EventHandler<AutoSeleccionadoEventArgs> AutoSeleccionado;
        ObservableCollection<Automovil> listaautos;

        void OnAutoSeleccionado(AutoSeleccionadoEventArgs e)
        {
            AutoSeleccionado?.Invoke(this, e);
        }

        public Tablas(ObservableCollection<Automovil> lstautos)
        {
            InitializeComponent();
            listaautos = lstautos;
            listacoches.ItemsSource = listaautos;

        }
        private void TablasClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void lista_SelectionCoche(object sender, SelectionChangedEventArgs e)
        {
            
            if ((Automovil)listacoches.SelectedItem != null)
            {
                Automovil autoeselect = listacoches.SelectedItem as Automovil;
                listarepostajes.ItemsSource = autoeselect.Repostaje;
                AutoSeleccionadoEventArgs aux = new AutoSeleccionadoEventArgs(autoeselect);
                OnAutoSeleccionado(aux);
            } 
        }
        
        //BOTONES TABLA VEHICULOS
        private void AddCar(object sender, RoutedEventArgs e)
        {
            NewAuto newcar = new NewAuto();
            newcar.ShowDialog();
            if (newcar.DialogResult == true)
            {
                listaautos.Add(newcar.AddAuto);
            }
            
        }
        private void EditCar(object sender, RoutedEventArgs e)
        {
            if ((Automovil)listacoches.SelectedItem != null)
            {
                Automovil autoedit = listacoches.SelectedItem as Automovil;
                string messageBoxTextedit = "¿Está seguro de modificar los datos del vehiculo con matricula " + autoedit.Matricula + "?";
                string captiondelete = "Modificar";
                MessageBoxButton buttonedit = MessageBoxButton.YesNo;
                MessageBoxImage iconedit = MessageBoxImage.Asterisk;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTextedit, captiondelete, buttonedit, iconedit, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    EditAuto editauto = new EditAuto(autoedit);
                    editauto.ShowDialog();
                    if (editauto.DialogResult == true)
                    {
                        MessageBox.Show("Datos Automovil modificados.", "", MessageBoxButton.OK, MessageBoxImage.None);
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
        }
        private void DeleteCar(object sender, RoutedEventArgs e)
        {
            if ((Automovil)listacoches.SelectedItem != null)
            {
                Automovil autodelete = listacoches.SelectedItem as Automovil;
                string messageBoxTextdelete = "¿Está seguro de eliminar el vehiculo con matricula " + autodelete.Matricula + " ?";
                string captiondelete = "Eliminar";
                MessageBoxButton buttondelete = MessageBoxButton.YesNo;
                MessageBoxImage icondelete = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTextdelete, captiondelete, buttondelete, icondelete, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    listaautos.Remove(autodelete);
                    autodelete.Repostaje.Clear();
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

        //BOTONES TABLA REPOSTAJE
        private void AddFuel(object sender, RoutedEventArgs e)
        {
            if ((Automovil)listacoches.SelectedItem != null)
            {
                Automovil autoselect = listacoches.SelectedItem as Automovil;
                NewRepos newrepos = new NewRepos();
                newrepos.ShowDialog();
                if (newrepos.DialogResult == true)
                {
                    Repostaje repos = newrepos.AddRepostaje;
                    autoselect.Repostaje.Add(repos);
                    //listarepostaje.Add(repos);
                    autoselect.Kilometro = repos.Kilometraje;
                    actualizardatos(autoselect);
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

        private void actualizardatos(Automovil autoselect)
        {

            // MEDIA COSTE 100KM
            // 10$ -> ((repos[ultimo].km)-(repos[penultimo].km))
            // x$  -> 100km
            float sumacoste = 0;
            float sumaconsumo = 0;
            float km1 = 1;
            float km2 = 0;
            foreach (Repostaje r in autoselect.Repostaje)
            {
                if (km1 <= r.Kilometraje)
                {
                    km1 = r.Kilometraje;
                }
                sumacoste += r.Coste;
                sumaconsumo += r.Litros;
            }
            autoselect.Kilometro = km1;
            autoselect.MediaCoste100 = (100 * sumacoste) / (km1 - km2);
            autoselect.MediaConsumo100 = (100 * sumaconsumo) / (km1 - km2);
           
        }

        private void DeleteFuel(object sender, RoutedEventArgs e)
        {
            if((Repostaje)listarepostajes.SelectedItem != null)
            {
                Automovil autoselect = listacoches.SelectedItem as Automovil;
                Repostaje reposdelete = listarepostajes.SelectedItem as Repostaje;
                string messageBoxTextdelete = "¿Está seguro de eliminar el repostaje?";
                string captiondelete = "Eliminar";
                MessageBoxButton buttondelete = MessageBoxButton.YesNo;
                MessageBoxImage icondelete = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTextdelete, captiondelete, buttondelete, icondelete, MessageBoxResult.No);
                if(result == MessageBoxResult.Yes)
                {
                    autoselect.Repostaje.Remove(reposdelete);
                    listarepostajes.ItemsSource = autoselect.Repostaje;
                    actualizardatos(autoselect);
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
        private void EditFuel(object sender, RoutedEventArgs e)
        {
            if ((Repostaje)listarepostajes.SelectedItem != null)
            {
                Repostaje reposedit = listarepostajes.SelectedItem as Repostaje;
                string messageBoxTextedit = "¿Está seguro de modificar los datos del respostaje?";
                string captionedit = "Modificar";
                MessageBoxButton buttonedit = MessageBoxButton.YesNo;
                MessageBoxImage iconedit = MessageBoxImage.Asterisk;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTextedit, captionedit, buttonedit, iconedit, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    EditRepos editrepos = new EditRepos(reposedit);
                    editrepos.ShowDialog();
                    if (editrepos.DialogResult == true)
                    {
                        Automovil autoselect = listacoches.SelectedItem as Automovil;
                        actualizardatos(autoselect);
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
        }
    }
}
