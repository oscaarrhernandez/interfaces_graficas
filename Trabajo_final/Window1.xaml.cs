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

        private void MenuAgregarCoche_Click(object sender, RoutedEventArgs e)
        {
            Agregarcoche newcoche = new Agregarcoche();
            newcoche.ShowDialog();
            if (newcoche.DialogResult == true)
            {
                //controlo subir datos
                
                listacoches.Items.Add(newcoche.AnadirCoche);
            }
        }
        private void MenuAgregarRepostaje_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void lista_SelectionCoche(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
