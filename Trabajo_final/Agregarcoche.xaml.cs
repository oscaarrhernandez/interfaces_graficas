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
        Coche newcar;
        List<Repostaje> repostajecoche = null;
        public Coche AnadirCoche { get { return newcar; }}

        public Agregarcoche()
        {
            InitializeComponent();
        }
        private void Button_AnadirCoche_Click(object sender, RoutedEventArgs e)
        {
            if(Check_TextBox())
            {
                newcar = new Coche(introducirmatricula.Text, introducirmarca.Text, float.Parse(introducirkilometros.Text), repostajecoche);
                
                DialogResult = true;
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
            else
            {
                introducirmatricula.Background = Brushes.White;

            }
            if (String.IsNullOrEmpty(introducirmarca.Text))
            {
                MessageBox.Show("El campo marca está vacio.");
                introducirmarca.Background = Brushes.IndianRed;
                check = false;
            }
            else
            {
                introducirmarca.Background = Brushes.White;

            }
            if (String.IsNullOrEmpty(introducirkilometros.Text))
            {
                MessageBox.Show("El campo kilometros está vacio.");
                introducirkilometros.Background = Brushes.IndianRed;
                check = false;
            }
            else
            {
                introducirkilometros.Background = Brushes.White;
            }
            return check;
        }
       
        private void Button_AnadirRepostaje_Click(object sender, RoutedEventArgs e)
        {
            //traer la matricula metida
            
            //pasar al metodo agregarrepostaje
            //si se agregan los datos
            

        }
        
        private void introducirmatricula_SelectionChanged(object sender, RoutedEventArgs e)
        {
            introducirmatricula.Background = Brushes.White;
        }
        private void introducirmarca_SelectionChanged(object sender, RoutedEventArgs e)
        {
            introducirmarca.Background = Brushes.White;
        }
        private void introducirkilometros_SelectionChanged(object sender, RoutedEventArgs e)
        {
            introducirkilometros.Background = Brushes.White;
        }
    }
}
