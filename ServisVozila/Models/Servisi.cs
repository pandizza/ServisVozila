using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVozila.Models
{
    public class Servisi
    {
        public int Id { get; set; }
        public int IdVozila { get; set; }
        public int VrstaServisa { get; set; }
        public string Naziv { get; set; }
        public int IdRacunovodstvo { get; set; }
        public string IdNaloga { get; set; }
        public DateTime Datum { get; set; }
        public string Nalog { get; set; }
    }
}
