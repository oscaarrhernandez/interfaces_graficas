using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Interfaces_Graficas
{
    /// <summary>
    /// Lógica de interacción para EditAuto.xaml
    /// </summary>
    public partial class EditAuto : Window
    {
        private readonly Automovil auto;

        public EditAuto(Automovil auto)
        {
            InitializeComponent();
            this.auto = auto;
            introducirmatricula.Text = auto.Matricula;
            introducirmarca.Text = auto.Marca;
            introducirkilometros.Text = Convert.ToString(auto.Kilometro);
        }

        private void introducirMatricula_SelectionChanged(object sender, RoutedEventArgs e)
        {
            introducirmatricula.BorderBrush = Brushes.Black;
            errormatricula.Visibility = Visibility.Hidden;
        }

        private void introducirMarca_SelectionChanged(object sender, RoutedEventArgs e)
        {
            introducirmarca.BorderBrush = Brushes.Black;
            errormarca.Visibility = Visibility.Hidden;
        }

        private void introducirKilometros_SelectionChanged(object sender, RoutedEventArgs e)
        {
            introducirkilometros.BorderBrush = Brushes.Black;
            errorkilometros.Visibility = Visibility.Hidden;
        }

        private void anadirAutoButton(object sender, RoutedEventArgs e)
        {
            if (Check_TextBox() == true)
            {
                auto.Matricula = introducirmatricula.Text;
                auto.Marca = introducirmarca.Text;
                auto.Kilometro = float.Parse(introducirkilometros.Text);
                DialogResult = true;
            }
        }

        private bool Check_TextBox()
        {
            bool check = true;

            if (String.IsNullOrEmpty(introducirmatricula.Text))
            {
                introducirmatricula.BorderBrush = Brushes.Red;
                errormatricula.Visibility = Visibility.Visible;
                check = false;
            }
            if (String.IsNullOrEmpty(introducirmarca.Text))
            {
                introducirmarca.BorderBrush = Brushes.Red;
                errormarca.Visibility = Visibility.Visible;
                check = false;
            }
            string s = introducirkilometros.Text;
            bool isNumber = Regex.IsMatch(s, @"^\d+$");
            if (String.IsNullOrEmpty(introducirkilometros.Text) || isNumber == false)
            {
                introducirkilometros.BorderBrush = Brushes.Red;
                errorkilometros.Visibility = Visibility.Visible;
                check = false;
            }

            return check;
        }
    }
}
