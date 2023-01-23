using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Lógica de interacción para NewAuto.xaml
    /// </summary>
    public partial class NewAuto : Window
    {
        Automovil newAuto;
        ObservableCollection<Repostaje> repostajeauto = new ObservableCollection<Repostaje>();
        public Automovil AddAuto { get { return newAuto; } }

        public NewAuto()
        {
            InitializeComponent();
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
                newAuto = new Automovil(introducirmatricula.Text, introducirmarca.Text, float.Parse(introducirkilometros.Text), repostajeauto, 0, 0);
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
