using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVozila.Models
{
    public class Potrosac
    {
        public int IdPotrosaca { get; set; }
        public int IdMjernogMjesta { get; set; }
        public string NazivConcat { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string Ulaz { get; set; }
        public int Stan { get; set; }
        public decimal Saldo { get; set; }
        public decimal Kamata { get; set; }
        public string Kategorija { get; set; }
        public string VrstaPotrosaca { get; set; }

        //Ukoliko bude trebalo registrovati pojedinacne promjene na potrosacu
        #region

        // Event to notify when a property changes
        //    public event PropertyChangedEventHandler PropertyChanged;

        //    // Helper method to raise the PropertyChanged event
        //    protected void OnPropertyChanged(string propertyName)
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }

        //    // Fields and Properties

        //    private int idPotrosaca;
        //    public int IdPotrosaca
        //    {
        //        get => idPotrosaca;
        //        set
        //        {
        //            if (idPotrosaca != value)
        //            {
        //                idPotrosaca = value;
        //                OnPropertyChanged(nameof(IdPotrosaca));
        //            }
        //        }
        //    }

        //    private int idMjernogMjesta;
        //    public int IdMjernogMjesta
        //    {
        //        get => idMjernogMjesta;
        //        set
        //        {
        //            if (idMjernogMjesta != value)
        //            {
        //                idMjernogMjesta = value;
        //                OnPropertyChanged(nameof(IdMjernogMjesta));
        //            }
        //        }
        //    }

        //    private string nazivConcat;
        //    public string NazivConcat
        //    {
        //        get => nazivConcat;
        //        set
        //        {
        //            if (nazivConcat != value)
        //            {
        //                nazivConcat = value;
        //                OnPropertyChanged(nameof(NazivConcat));
        //            }
        //        }
        //    }

        //    private string ulica;
        //    public string Ulica
        //    {
        //        get => ulica;
        //        set
        //        {
        //            if (ulica != value)
        //            {
        //                ulica = value;
        //                OnPropertyChanged(nameof(Ulica));
        //            }
        //        }
        //    }

        //    private string broj;
        //    public string Broj
        //    {
        //        get => broj;
        //        set
        //        {
        //            if (broj != value)
        //            {
        //                broj = value;
        //                OnPropertyChanged(nameof(Broj));
        //            }
        //        }
        //    }

        //    private string ulaz;
        //    public string Ulaz
        //    {
        //        get => ulaz;
        //        set
        //        {
        //            if (ulaz != value)
        //            {
        //                ulaz = value;
        //                OnPropertyChanged(nameof(Ulaz));
        //            }
        //        }
        //    }

        //    private int stan;
        //    public int Stan
        //    {
        //        get => stan;
        //        set
        //        {
        //            if (stan != value)
        //            {
        //                stan = value;
        //                OnPropertyChanged(nameof(Stan));
        //            }
        //        }
        //    }

        //    private decimal saldo;
        //    public decimal Saldo
        //    {
        //        get => saldo;
        //        set
        //        {
        //            if (saldo != value)
        //            {
        //                saldo = value;
        //                OnPropertyChanged(nameof(Saldo));
        //            }
        //        }
        //    }

        //    private decimal kamata;
        //    public decimal Kamata
        //    {
        //        get => kamata;
        //        set
        //        {
        //            if (kamata != value)
        //            {
        //                kamata = value;
        //                OnPropertyChanged(nameof(Kamata));
        //            }
        //        }
        //    }

        //    private string kategorija;
        //    public string Kategorija
        //    {
        //        get => kategorija;
        //        set
        //        {
        //            if (kategorija != value)
        //            {
        //                kategorija = value;
        //                OnPropertyChanged(nameof(Kategorija));
        //            }
        //        }
        //    }

        //    private string vrstaPotrosaca;
        //    public string VrstaPotrosaca
        //    {
        //        get => vrstaPotrosaca;
        //        set
        //        {
        //            if (vrstaPotrosaca != value)
        //            {
        //                vrstaPotrosaca = value;
        //                OnPropertyChanged(nameof(VrstaPotrosaca));
        //            }
        //        }
        //    }
        //}

        #endregion
    }

}