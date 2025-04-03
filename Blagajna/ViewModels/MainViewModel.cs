using ServisVozila.Models;
using ServisVozila.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Input;

namespace ServisVozila
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MenuItem> TopMenuItems { get; } = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> BottomMenuItems { get; } = new ObservableCollection<MenuItem>();

        private object _currentView;
        private MenuItem _selectedMenuItem;

        private ObservableCollection<Vozila> vozila;
        private ObservableCollection<KilometrazaVozila> kilometraza;
        private ObservableCollection<VrstaGoriva> vrsta_goriva;
        private ObservableCollection<Servisi> servisi;
        private ObservableCollection<AlarmiVozila> alarmi;
        private ObservableCollection<RegistracijaVozila> registracije;
        private ObservableCollection<Materijal> materijal;
        private ObservableCollection<VrstaServisa> vrste_servisa;
        private ObservableCollection<MaterijalSkladiste> materijal_skladiste;

        public MainViewModel(
            ObservableCollection<Vozila> vozila,
            ObservableCollection<KilometrazaVozila> kilometraza,
            ObservableCollection<VrstaGoriva> vrsta_goriva,
            ObservableCollection<Servisi> servisi,
            ObservableCollection<AlarmiVozila> alarmi,
            ObservableCollection<RegistracijaVozila> registracije,
            ObservableCollection<Materijal> materijal, 
            ObservableCollection<VrstaServisa> vrste_servisa,
            ObservableCollection<MaterijalSkladiste> materijal_skladiste)
        {
            this.vozila = vozila;
            this.kilometraza = kilometraza;
            this.vrsta_goriva = vrsta_goriva;
            this.servisi = servisi;
            this.alarmi = alarmi;
            this.registracije = registracije;
            this.materijal = materijal;
            this.vrste_servisa = vrste_servisa;
            this.materijal_skladiste = materijal_skladiste;

            // Views with full data passed to ViewModel
            var vozilaViewModel = new VozilaViewModel(vozila, kilometraza, vrsta_goriva, servisi, alarmi, registracije, materijal, vrste_servisa, materijal_skladiste);
            var vozilaView = new VozilaView(vozilaViewModel);
            vozilaView.InitData(vozila, kilometraza, vrsta_goriva, servisi, alarmi, registracije, materijal, vrste_servisa);

            // Menu Items
            var vozilaItem = new MenuItem("VOZILA", "/Images/car-50.png", vozilaView);
            var servisiItem = new MenuItem("SERVISI", "/Images/maintenance-50.png", new IstorijaView());
            var materijalItem = new MenuItem("MATERIJALI", "/Images/materijal-50.png", new PologView());
            var zatvaranjeItem = new MenuItem("Zatvaranje kase", "/Images/close-register-32.png", new ZatvaranjeKaseView());

            // Commands
            vozilaItem.Command = new RelayCommand(_ => SelectedMenuItem = vozilaItem);
            servisiItem.Command = new RelayCommand(_ => SelectedMenuItem = servisiItem);
            materijalItem.Command = new RelayCommand(_ => SelectedMenuItem = materijalItem);
            zatvaranjeItem.Command = new RelayCommand(_ => SelectedMenuItem = zatvaranjeItem);

            // Add to Menu
            TopMenuItems.Add(vozilaItem);
            TopMenuItems.Add(servisiItem);
            TopMenuItems.Add(materijalItem);
            // BottomMenuItems.Add(zatvaranjeItem); // Add if needed

            SelectedMenuItem = TopMenuItems.FirstOrDefault();
        }

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                if (_selectedMenuItem == value) return;

                if (_selectedMenuItem != null)
                    _selectedMenuItem.IsSelected = false;

                _selectedMenuItem = value;

                if (_selectedMenuItem != null)
                    _selectedMenuItem.IsSelected = true;

                CurrentView = _selectedMenuItem?.Content;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MenuItem : INotifyPropertyChanged
    {
        public string Title { get; }
        public string ImagePath { get; }
        public object Content { get; }
        public ICommand Command { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public MenuItem(string title, string imagePath, object content)
        {
            Title = title;
            ImagePath = imagePath;
            Content = content;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
