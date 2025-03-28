using ServisVozila.Models;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServisVozila
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<AlarmiVozila> alarmi;
        private ObservableCollection<KilometrazaVozila> kolometraze;
        private ObservableCollection<Materijal> materijal;
        private ObservableCollection<RegistracijaVozila> registracije;
        private ObservableCollection<Servisi> servisi;
        private ObservableCollection<VrstaGoriva> vrsta_goriva;

        public MainWindow(ObservableCollection<Vozila> vozila, ObservableCollection<AlarmiVozila> alarmi, ObservableCollection<KilometrazaVozila> kolometraze, ObservableCollection<Materijal> materijal, ObservableCollection<RegistracijaVozila> registracije, ObservableCollection<Servisi> servisi, ObservableCollection<VrstaGoriva> vrsta_goriva)
        {
            InitializeComponent();

            this.alarmi = alarmi;
            this.kolometraze = kolometraze;
            this.materijal = materijal;
            this.registracije = registracije;
            this.servisi = servisi;
            this.vrsta_goriva = vrsta_goriva;
        }

        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMaximizeApp_Click(object sender, RoutedEventArgs e)
        {
            ToggleFullScreen();
        }

        public void ToggleFullScreen()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;


            }
            else
                this.WindowState = WindowState.Maximized;
        }

        private void btnMinimizeApp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}