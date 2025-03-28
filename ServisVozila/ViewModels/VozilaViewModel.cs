using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ServisVozila.Models;

namespace ServisVozila.ViewModels
{
    public class VozilaViewModel
    {
        public ObservableCollection<Vozila> vozila_list { get; set; } = new();
        public Vozila SelectedVozilo { get; set; }

        public ICommand VoziloDoubleClickCommand { get; }

        public VozilaViewModel()
        {
            VoziloDoubleClickCommand = new RelayCommand(OnVoziloDoubleClicked);

            _ = LoadVozilaAsync(); // fire and forget
        }

        private async Task LoadVozilaAsync()
        {
            var result = await DataAccess.GetVozilaAsync();
            if (result != null)
            {
                foreach (var vozilo in result)
                {
                    vozila_list.Add(vozilo);
                }
            }
        }

        private void OnVoziloDoubleClicked(object obj)
        {
            if (SelectedVozilo != null)
            {
                Debug.WriteLine($"Double-clicked: {SelectedVozilo.Naziv}");
            }
        }
    }
}
