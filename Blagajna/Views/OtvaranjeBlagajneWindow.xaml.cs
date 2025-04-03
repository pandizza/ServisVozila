using System;
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

namespace ServisVozila.Views
{
    /// <summary>
    /// Interaction logic for OtvaranjeBlagajneWindow.xaml
    /// </summary>
    public partial class OtvaranjeBlagajneWindow : Window
    {
        public OtvaranjeBlagajneWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtKorisnik.Text = Settings1.Default.username;
            txtDatum.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOtvori_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
