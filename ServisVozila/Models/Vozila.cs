using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVozila.Models
{
    public class Vozila
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string RegOznaka { get; set; }
        public int kW { get; set; }
        public int cm3 { get; set; }
        public int GodProizvodnje { get; set; }
        public int Kilometraza { get; set; }
        public string VrstaGoriva { get; set; }
    }
}
