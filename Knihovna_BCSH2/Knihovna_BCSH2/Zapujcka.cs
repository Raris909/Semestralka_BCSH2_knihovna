using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna_BCSH2
{
    public class Zapujcka
    {
        public int Id { get; set; } // Jedinečný identifikátor zápůjčky
        public DateTime DatumZapujcky { get; set; } // Datum zápůjčky
        public DateTime? DatumVraceni { get; set; } // Datum vrácení
        public int KnihaId { get; set; } // ID knihy
        public int ZakaznikId { get; set; } // ID zákazníka
        public Kniha Kniha { get; set; } // Název knihy
        public Zakaznik Zakaznik { get; set; } // Jméno zákazníka
    }
}
