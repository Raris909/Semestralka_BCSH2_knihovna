using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna_BCSH2
{
    public class Kniha
    {
        public int Id { get; set; }             // Primární klíč
        public string Nazev { get; set; }       // Název knihy
        public string Zanr { get; set; }        // Žánr knihy
        public string Vydavatel { get; set; }   // Vydavatel
        public int RokVydani { get; set; }      // Rok vydání
        public int PocetStran { get; set; }     // Počet stran
        public string Jazyk { get; set; }       // Jazyk knihy

        // Klíč cizí tabulky pro autora
        public int AutorId { get; set; }        // ID autora spojeného s knihou

        // Navigační vlastnost (volitelné, užitečné s ORM)
        public Autor Autor { get; set; }        // Detailní informace o autorovi
    }

}
