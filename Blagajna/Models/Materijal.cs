using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVozila.Models
{
    public class Materijal
    {
        public int Id { get; set; }
        public string IdSkladiste { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
    }
}
