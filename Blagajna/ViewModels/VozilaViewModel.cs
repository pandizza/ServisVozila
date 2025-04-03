using ServisVozila.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace ServisVozila
{
    public class VozilaViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Vozila> _vozila;
        private ObservableCollection<KilometrazaVozila> _kilometraza;
        private ObservableCollection<VrstaGoriva> _vrstaGoriva;
        private ObservableCollection<Servisi> _servisi;
        private ObservableCollection<AlarmiVozila> _alarmi;
        private ObservableCollection<RegistracijaVozila> _registracije;
        private ObservableCollection<Materijal> _materijal;
        private ObservableCollection<VrstaServisa> _vrste_servisa;


        private ICollectionView _filteredVozilaView;
        private Vozila _selectedVozilo;
        private string _searchText;

        public event PropertyChangedEventHandler PropertyChanged;

        public VozilaViewModel(
            ObservableCollection<Vozila> vozila,
            ObservableCollection<KilometrazaVozila> kilometraza,
            ObservableCollection<VrstaGoriva> vrstaGoriva,
            ObservableCollection<Servisi> servisi,
            ObservableCollection<AlarmiVozila> alarmi,
            ObservableCollection<RegistracijaVozila> registracije,
            ObservableCollection<Materijal> materijal,
            ObservableCollection<VrstaServisa> vrste_servisa)
        {
            _vozila = vozila;
            _kilometraza = kilometraza;
            _vrstaGoriva = vrstaGoriva;
            _servisi = servisi;
            _alarmi = alarmi;
            _registracije = registracije;
            _materijal = materijal;
            _vrste_servisa = vrste_servisa;

            _filteredVozilaView = CollectionViewSource.GetDefaultView(_vozila);
            _filteredVozilaView.Filter = FilterVozila;

            VoziloDoubleClickCommand = new RelayCommand(OnVoziloDoubleClicked);
            AddVoziloCommand = new RelayCommand(OnAddVozilo);
        }

        public ICollectionView MyCollection => _filteredVozilaView;

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    _filteredVozilaView.Refresh();
                }
            }
        }

        public Vozila SelectedVozilo
        {
            get => _selectedVozilo;
            set
            {
                _selectedVozilo = value;
                OnPropertyChanged(nameof(SelectedVozilo));
            }
        }

        public ICommand VoziloDoubleClickCommand { get; }
        public ICommand AddVoziloCommand { get; }

        private bool FilterVozila(object obj)
        {
            if (obj is Vozila vozilo)
            {
                if (string.IsNullOrWhiteSpace(SearchText))
                    return true;

                return vozilo.Naziv?.ToLower().Contains(SearchText.ToLower()) ?? false;
            }
            return false;
        }

        private void OnVoziloDoubleClicked(object obj)
        {
            if (SelectedVozilo != null)
            {
                var window = new Views.VozilaInfoWindow(SelectedVozilo);
                window.ShowDialog();
            }
        }

        private void OnAddVozilo(object obj)
        {
            var window = new Views.DodajVoziloWindow(_vrstaGoriva);
            window.ShowDialog();

            if (window.VoziloAdded)
            {
                ReloadVozila(); // Refresh the vehicle list
            }
        }

        public async void ReloadVozila()
        {
            var novaLista =await DataAccess.GetVozilaAsync();

            _vozila.Clear();
            foreach (var v in novaLista)
            {
                _vozila.Add(v);
            }

            _filteredVozilaView.Refresh(); // Refresh filter/view if active
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
