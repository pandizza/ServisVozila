using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVozila.Models
{
    public class RegistracijaVozila
    {
        public int Id { get; set; }
        public int IdVozila { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public bool Aktivna { get; set; }
        public decimal Cijena { get; set; }
        public string Napomena { get; set; }
    }
}
