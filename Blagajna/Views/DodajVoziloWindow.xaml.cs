using Dapper;
using ServisVozila.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
    /// Interaction logic for DodajVoziloWindow.xaml
    /// </summary>
    public partial class DodajVoziloWindow : Window
    {
        private ObservableCollection<VrstaGoriva> _vrsteGoriva;

        public DodajVoziloWindow(ObservableCollection<VrstaGoriva> vrsteGoriva)
        {
            InitializeComponent();
            _vrsteGoriva = vrsteGoriva;
            cboVrstaGoriva.ItemsSource = _vrsteGoriva;
            cboVrstaGoriva.DisplayMemberPath = "Naziv";
            cboVrstaGoriva.SelectedIndex = 0;
        }

        private void txtNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnDodajVozilo.IsEnabled = !string.IsNullOrWhiteSpace(txtNaziv.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtNaziv.Focus();
        }

        private void txtKubikaza_KeyDown(object sender, KeyEventArgs e)
        {
            Helper.AllowOnlyIntegers(sender, e);
        }

        private void txtSnagaMotora_KeyDown(object sender, KeyEventArgs e)
        {
            Helper.AllowOnlyIntegers(sender,e);
        }

        private void txtKilometraza_KeyDown(object sender, KeyEventArgs e)
        {
            Helper.AllowOnlyIntegers(sender, e);
        }

        public bool VoziloAdded { get; private set; } = false;
        private void btnDodajVozilo_Click(object sender, RoutedEventArgs e)
        {
            var vg = (VrstaGoriva)cboVrstaGoriva.SelectedItem;
            var regdo = dtpRegistrovanDo.SelectedDate.HasValue
                ? dtpRegistrovanDo.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss")
                : DBNull.Value.ToString();

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@Naziv", txtNaziv.Text);
            dp.Add("@RegOznaka", txtRegistracija.Text == string.Empty?"": txtRegistracija.Text);
            dp.Add("@kW", txtSnagaMotora.Text == string.Empty ? "" : txtSnagaMotora.Text);
            dp.Add("@cm3", txtKubikaza.Text == string.Empty ? "" : txtKubikaza.Text);
            dp.Add("@God", txtGodProzvodnje.Text == string.Empty ? "" : txtGodProzvodnje.Text);
            dp.Add("@Kilometraza", txtKilometraza.Text == string.Empty ? "" : txtKilometraza.Text);
            dp.Add("@VrstaGoriva", vg.Id);
            dp.Add("@RegDo", regdo);



            try
            {
                int result = DataAccess.ExecuteStoredProcedure("sp_unesiVozilo", dp);

                MessageBox.Show("Vozilo uspešno dodato!", "Uspeh", MessageBoxButton.OK, MessageBoxImage.Information);
                VoziloAdded = true;
                this.Close();

            }
            catch (SqlException ex)
            {
                ErrorWindow ew = new ErrorWindow("SqlException", "GREŠKA", ex.Message);
                ew.Show();
            }
            catch (Exception ex)
            {
                ErrorWindow ew = new ErrorWindow(ex.GetType().ToString(), "GREŠKA", ex.Message);
                ew.Show();
            }

        }
    }
}
