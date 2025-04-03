using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisVozila.Models
{
    public class VrstePrometaBlagajna
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int VrstaPoslovanja { get; set; }
        public string Konto { get; set; }
        public bool IsPotrosac { get; set; }
        public bool IsDobavljac { get; set; }
        public bool IsRadnik { get; set; }
    }
}
