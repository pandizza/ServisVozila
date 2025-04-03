using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVozila.Models
{
    public class KontoDT
    {
        public string Konto { get; set; }
        public string ImeNaziv { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public int Opstina { get; set; }
        public int Entitet { get; set; }
        public decimal Saldo { get; set; }
        public decimal SaldoSporno { get; set; }
        public string VrstaKonta { get; set; }
    }
}
