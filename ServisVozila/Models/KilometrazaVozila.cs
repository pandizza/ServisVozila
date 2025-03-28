using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVozila.Models
{
    public class KilometrazaVozila
    {
        public int Id { get; set; }
        public int IdVozila { get; set; }
        public DateTime Datum { get; set; }
        public string Nalog { get; set; }
        public int Stanje { get; set; }
        public string Napomena { get; set; }
    }
}
