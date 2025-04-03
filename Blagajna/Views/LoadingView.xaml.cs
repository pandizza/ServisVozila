using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace ServisVozila
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoadingView : Window
    {
        bool isWindowMaximized = false;

        double initWinHeight;
        double initWinWidth;

        private double _originalLeft;
        private double _originalTop;
        private double _originalWidth;
        private double _originalHeight;

        public LoadingView()
        {
            InitializeComponent();

            var gifUri = new Uri("pack://application:,,,/Images/loading.gif");
            ImageBehavior.SetAnimatedSource(GifPlayer, new BitmapImage(gifUri));
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
        }

        protected override async void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            // Call DataAccess.GetPotrosaci asynchronously
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                // Asynchronously fetch data
                //var konta = await DataAccess.GetKontaAsync();
                //var vrste_prometa = await DataAccess.GetVrstaPrometaAsync();

                var vozila = await DataAccess.GetVozilaAsync();
                var kolimetraza = await DataAccess.GetKilometrazeAsync();
                var vrsta_goriva = await DataAccess.GetVrsteGorivaAsync();
                var servisi = await DataAccess.GetServisiAsync();
                var alarmi = await DataAccess.GetAlarmiAsync();
                var registracije = await DataAccess.GetRegistracijaAsync();
                var materijal = await DataAccess.GetMaterijalAsync();
                var vrste_servisa = await DataAccess.GetVrsteServisaAsync();

                // After loading, open MainWindow
                MainWindow mainWindow = new MainWindow(vozila, kolimetraza, vrsta_goriva, servisi, alarmi, registracije, materijal, vrste_servisa);
                mainWindow.Show();

            this.Close();
             }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during data loading
                txtInfo.Text = $"Greška: {ex.Message}";
                txtInfo.Foreground = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#F77777"));
                GifPlayer.Visibility = Visibility.Hidden;
            }

}

    }
}