using ServisVozila.Models;
using ServisVozila.ViewModels;
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
    /// Interaction logic for VozilaInfoWindow.xaml
    /// </summary>
    public partial class VozilaInfoWindow : Window
    {
        public VozilaInfoWindow(Vozila vozilo)
        {
            InitializeComponent();
            DataContext = new VozilaInfoViewModel(vozilo);
        }
    }
}
