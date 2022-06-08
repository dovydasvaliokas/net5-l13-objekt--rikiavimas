using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxVidurkioIeskojimas
{
    internal class Preke
    {
        // Kintamieji (PRIVATŪS BŪTINAI)
        private int id;
        private string pavadinimas;
        private string aprasymas;
        private decimal kaina;              // kainai geriau decimal nei double, nes jis yra tiksliau su mažesnio tikslumo skaičiais
        private int kiekis;
        private string gamintojas;

        // Getteriai setteriai
        public int Id { get => id; set => id = value; }
        public string Pavadinimas { get => pavadinimas; set => pavadinimas = value; }
        public string Aprasymas { get => aprasymas; set => aprasymas = value; }
        public decimal Kaina { get => kaina; set => kaina = value; }
        public int Kiekis { get => kiekis; set => kiekis = value; }
        public string Gamintojas { get => gamintojas; set => gamintojas = value; }

        // Konstruktoriai
        // Pilnas konstruktorius
        public Preke(int id, string pavadinimas, string aprasymas, decimal kaina, int kiekis, string gamintojas)
        {
            this.id = id;
            this.pavadinimas = pavadinimas;
            this.aprasymas = aprasymas;
            this.kaina = kaina;
            this.kiekis = kiekis;
            this.gamintojas = gamintojas;
        }

        // Tuščias konstruktorius
        public Preke()
        {
        }

        //---------------------------- Klasės funkcijos/metodai -----------------------------------
        

        // Overridintas ToString() metodas.
        public override string? ToString()
        {
            string tekstas = "id: " + id + "; pavadinimas: " + pavadinimas + "; aprasymas: " + aprasymas + "; kaina: " + kaina + "; kiekis: " + kiekis + "; gamintojas: " + gamintojas;
            
            return tekstas;
        }
    }
}
