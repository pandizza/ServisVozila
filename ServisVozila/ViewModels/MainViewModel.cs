using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Wpf.Ui.Input;
using ServisVozila.Views;

namespace ServisVozila
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MenuItem> TopMenuItems { get; } = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> BottomMenuItems { get; } = new ObservableCollection<MenuItem>();

        private object _currentView;
        private MenuItem _selectedMenuItem;

        public MainViewModel()
        {
            // Create menu items
            var vozilaItem = new MenuItem("VOZILA", "/Images/car-50.png", new VozilaView());
            var servisiItem = new MenuItem("SERVISI", "/Images/maintenance-50.png", new VozilaView());
            //var pologItem = new MenuItem("Polog pazara", "/Images/payment-50.png", new PologView());
            //var zatvaranjeItem = new MenuItem("Zatvaranje kase", "/Images/close-register-32.png", new ZatvaranjeKaseView());

            // Assign commands
            vozilaItem.Command = new RelayCommand(_ => SelectedMenuItem = vozilaItem);
            servisiItem.Command = new RelayCommand(_ => SelectedMenuItem = servisiItem);
            //pologItem.Command = new RelayCommand(_ => SelectedMenuItem = pologItem);
            //zatvaranjeItem.Command = new RelayCommand(_ => SelectedMenuItem = zatvaranjeItem);

            // Add to collections
            TopMenuItems.Add(vozilaItem);
            TopMenuItems.Add(servisiItem);
            //BottomMenuItems.Add(pologItem);
            //BottomMenuItems.Add(zatvaranjeItem);

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

                // Deselect previous item
                if (_selectedMenuItem != null)
                    _selectedMenuItem.IsSelected = false;

                _selectedMenuItem = value;

                // Select new item
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

