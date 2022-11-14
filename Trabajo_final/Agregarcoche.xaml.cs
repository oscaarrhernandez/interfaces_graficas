using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Lógica de interacción para Agregarcoche.xaml
    /// </summary>
    public partial class Agregarcoche : Window
    {
        public Agregarcoche()
        {
            InitializeComponent();
        }
        private void Button_AnadirCoche_Click(object sender, RoutedEventArgs e)
        {
            if(Check_TextBox() == true && Check_Button())
            {
                DialogResult =true;
            }
        }

        private bool Check_TextBox()
        {
            bool check = true;
            if (String.IsNullOrEmpty(introducirmatricula.Text))
            {
                MessageBox.Show("El campo matricula está vacio.");
                introducirmatricula.Background = Brushes.IndianRed;
                check = false;
            }
            if (String.IsNullOrEmpty(introducirmarca.Text))
            {
                MessageBox.Show("El campo marca está vacio.");
                introducirmarca.Background = Brushes.IndianRed;
                check = false;
            }
            if (String.IsNullOrEmpty(introducirkilometros.Text))
            {
                MessageBox.Show("El campo kilometros está vacio.");
                introducirkilometros.Background = Brushes.IndianRed;
                check = false;
            }
            return check;
        }
        bool chbutton = false;
        private bool Check_Button()
        {
            
            if (chbutton==false)
            {
                MessageBox.Show("Se debe añadir los datos de un repostaje.");
                repostaje.Background = Brushes.IndianRed;
            }
            return chbutton;
        }
        private void Button_AnadirRepostaje_Click(object sender, RoutedEventArgs e)
        {
            //traer la matricula metida

            //pasar al metodo agregarrepostaje
            //si se agregan los datos
                chbutton = true;

            DialogResult = true;
        }
    }
}
