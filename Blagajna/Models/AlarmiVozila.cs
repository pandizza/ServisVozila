using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVozila.Models
{
    public class AlarmiVozila
    {
        public int Id { get; set; }
        public int IdServisa { get; set; }
        public int Vrsta { get; set; }
        public DateTime DatumTreshold { get; set; }
        public int KilometriTreshold { get; set; }
        public int DatumPreostalo { get; set; }
        public int KilometriPreostalo { get; set; }
        public int DatumNotifZona { get; set; }
        public int KilometriNotifZona { get; set; }
        public DateTime Datum { get; set; }
        public string Nalog { get; set; }
        public bool Alarmiranje { get; set; }
        public string RazlogGasenja { get; set; }
        public bool NasilnoGasenje { get; set; }
    }
}
