using ServisVozila.Models;

namespace ServisVozila.ViewModels
{
    public class VozilaInfoViewModel
    {
        public Vozila SelectedVozilo { get; }

        public VozilaInfoViewModel(Vozila vozilo)
        {
            SelectedVozilo = vozilo;
        }

        public string Naziv => SelectedVozilo?.Naziv;
        public string RegOznaka => SelectedVozilo?.RegOznaka;
        public int GodProizvodnje => SelectedVozilo.GodProizvodnje;
        public int kW => SelectedVozilo.kW;
        public int cm3 => SelectedVozilo.cm3;
        public DateTime RegistracijaDo => SelectedVozilo.RegistracijaDo;

    }
}