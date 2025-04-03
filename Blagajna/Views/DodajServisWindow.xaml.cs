using ServisVozila.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DodajServisWindow.xaml
    /// </summary>
    public partial class DodajServisWindow : Window
    {
        ObservableCollection<VrstaServisa> _vrste_servisa;
        public DodajServisWindow(ObservableCollection<VrstaServisa> vrste_servisa)
        {
            InitializeComponent();
            _vrste_servisa = vrste_servisa;
            cboVrstaServisa.ItemsSource = _vrste_servisa;
            cboVrstaServisa.DisplayMemberPath = "Naziv";
            cboVrstaServisa.SelectedIndex = 0;
        }
    }
}
