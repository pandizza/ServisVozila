using ServisVozila.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Wpf.Ui.Controls;
using DataGrid = System.Windows.Controls.DataGrid;
using MenuItem = System.Windows.Controls.MenuItem;
using TextBlock = Wpf.Ui.Controls.TextBlock;
using System.Windows;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServisVozila
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isWindowMaximized = false;

        double initWinHeight;
        double initWinWidth;

        private double _originalLeft;
        private double _originalTop;
        private double _originalWidth;
        private double _originalHeight;

        private DispatcherTimer _ClockTimer;

        public ObservableCollection<Vozila> Vozila { get; }
        public ObservableCollection<KilometrazaVozila> Kolimetraza { get; }
        public ObservableCollection<VrstaGoriva> Vrsta_goriva { get; }
        public ObservableCollection<Servisi> Servisi { get; }
        public ObservableCollection<AlarmiVozila> Alarmi { get; }
        public ObservableCollection<RegistracijaVozila> Registracije { get; }
        public ObservableCollection<Materijal> Materijal { get; }

        //public ObservableCollection<Potrosac> PotrosaciCollection { get; set; }
        //public ICollectionView FilteredPotrosaciView { get; set; }


        //public MainWindow(ObservableCollection<KontoDT> kontaCollection, ObservableCollection<VrstePrometaBlagajna> vrstePrometaCollection)
        //{
            
        //    InitializeComponent();

        //    InitClockTimer();

        //    DataContext = new MainViewModel(kontaCollection, vrstePrometaCollection);
        //}

        public MainWindow(ObservableCollection<Vozila> vozila, 
                            ObservableCollection<KilometrazaVozila> kilometraza, 
                            ObservableCollection<VrstaGoriva> vrsta_goriva, 
                            ObservableCollection<Servisi> servisi, 
                            ObservableCollection<AlarmiVozila> alarmi, 
                            ObservableCollection<RegistracijaVozila> registracije, 
                            ObservableCollection<Materijal> materijal, 
                            ObservableCollection<VrstaServisa> vrsta_servisa,
                            ObservableCollection<MaterijalSkladiste> materijal_skladiste)
        {
            InitializeComponent();

            InitClockTimer();

            DataContext = new MainViewModel(vozila, kilometraza, vrsta_goriva, servisi, alarmi, registracije, materijal, vrsta_servisa, materijal_skladiste );
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void InitClockTimer()
        {
            _ClockTimer = new DispatcherTimer();
            _ClockTimer.Interval = TimeSpan.FromSeconds(1);
            _ClockTimer.Tick += _ClockTimer_Tick; ;

            // Start the timer
            _ClockTimer.Start();

            // Set the initial time
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            CultureInfo culture = new CultureInfo("bs-Latn-BA");

            // Get the current date and time
            DateTime now = DateTime.Now;

            // Get the day of the week as a localized string
            string dayName = culture.DateTimeFormat.GetDayName(now.DayOfWeek);

            // Format the date and time as 'dd.MM.yyyy HH:mm:ss'
            string formattedDateTime = $"{dayName} {now.ToString("dd.MM.yyyy HH:mm:ss")}";

            // Update the TextBlock
            txtDatumVrijeme.Text = formattedDateTime;
        }

        private void _ClockTimer_Tick(object? sender, EventArgs e)
        {
            UpdateDateTime();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Debug.Print(e.ErrorException.ToString());
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            initWinHeight = this.Height;
            initWinWidth = this.Width;

            txtUserName.Text = Settings1.Default.username; 

        }


        private void txtSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {


        }

        private void PrintMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //// Get the clicked MenuItem
            //var menuItem = sender as MenuItem;

            //// Get the ContextMenu to which the MenuItem belongs
            //var contextMenu = menuItem?.Parent as ContextMenu;

            //// Get the DataGridRow that owns the ContextMenu
            //var dataGridRow = contextMenu?.PlacementTarget as DataGridRow;

            //// Get the data item associated with the DataGridRow
            //var dataItem = dataGridRow?.DataContext;

            //// Perform the print action (for example, print to the console)
            //if (dataItem != null)
            //{
            //    System.Windows.MessageBox.Show("Stampa");
            //}
        }


    }
}