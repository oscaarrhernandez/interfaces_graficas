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
    /// Lógica de interacción para EditRepos.xaml
    /// </summary>
    public partial class EditRepos : Window
    {
        private readonly Repostaje repos;

        public EditRepos(Repostaje repos)
        {
            InitializeComponent();
            this.repos = repos;
            introducirkilometraje.Text = Convert.ToString(repos.Kilometraje);
            introducircoste.Text = Convert.ToString(repos.Coste);
            introducirlitros.Text = Convert.ToString(repos.Litros);
            introducirfecha.Text = Convert.ToString(repos.Fecha);
        }

        private void introducirKilometraje_SelectionChanged(object sender, RoutedEventArgs e)
        {
            introducirkilometraje.BorderBrush = Brushes.Black;
            errorkilometraje.Visibility = Visibility.Hidden;
        }

        private void introducirCoste_SelectionChanged(object sender, RoutedEventArgs e)
        {
            introducircoste.BorderBrush = Brushes.Black;
            errorcoste.Visibility = Visibility.Hidden;
        }

        private void introducirLitros_SelectionChanged(object sender, RoutedEventArgs e)
        {
            introducirlitros.BorderBrush = Brushes.Black;
            errorlitros.Visibility = Visibility.Hidden;
        }

        private void introducirFecha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            introducirfecha.BorderBrush = Brushes.Black;
            errorfecha.Visibility = Visibility.Hidden;
        }

        private void anadirFuelButton(object sender, RoutedEventArgs e)
        {
            if (Check_TextBox() == true)
            {
                repos.Kilometraje = float.Parse(introducirkilometraje.Text);
                repos.Coste = float.Parse(introducircoste.Text);
                repos.Litros = float.Parse(introducirlitros.Text);
                repos.Fecha = introducirfecha.SelectedDate.Value.Date;
                DialogResult = true;
            }
        }
        private bool Check_TextBox()
        {
            bool check = true;
            string s = introducirkilometraje.Text;
            bool isNumber = Regex.IsMatch(s, @"^\d+$");
            if (String.IsNullOrEmpty(introducirkilometraje.Text) || isNumber == false)
            {
                introducirkilometraje.BorderBrush = Brushes.Red;
                errorkilometraje.Visibility = Visibility.Visible;
                check = false;
            }
            s = introducircoste.Text;
            isNumber = Regex.IsMatch(s, @"^\d+$");
            if (String.IsNullOrEmpty(introducircoste.Text) || isNumber == false)
            {
                introducircoste.BorderBrush = Brushes.Red;
                errorcoste.Visibility = Visibility.Visible;
                check = false;
            }
            s = introducirlitros.Text;
            isNumber = Regex.IsMatch(s, @"^\d+$");
            if (String.IsNullOrEmpty(introducirlitros.Text) || isNumber == false)
            {
                introducirlitros.BorderBrush = Brushes.Red;
                errorlitros.Visibility = Visibility.Visible;
                check = false;
            }
            if (String.IsNullOrEmpty(introducirfecha.Text))
            {
                introducirfecha.BorderBrush = Brushes.Red;
                errorfecha.Visibility = Visibility.Visible;
                check = false;
            }

            return check;

        }
    }
}
