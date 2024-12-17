using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna_BCSH2
{
    public class Zapujcka
    {
        public int Id { get; set; }
        public DateTime DatumZapujcky { get; set; }
        public DateTime? DatumVraceni { get; set; }
        public int KnihaId { get; set; }
        public int ZakaznikId { get; set; }
        public Kniha Kniha { get; set; }
        public Zakaznik Zakaznik { get; set; }
    }
}
