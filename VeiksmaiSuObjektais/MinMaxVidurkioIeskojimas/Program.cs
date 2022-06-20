using System;

namespace MinMaxVidurkioIeskojimas // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        // Čia yra pastovūs kintamieji/reikšmės (konstantos), pvz.: failo pavadinimas
        const string FailoPavadinimas = "prekes.csv";
        static void Main(string[] args)
        {
            List<Preke> prekes = NuskaitytiPrekesIsFailo();

            Console.WriteLine("Brangiausia prekė: ");

            Preke brangiausiaPreke = RastiBrangiausiaPreke(prekes);

            Console.WriteLine(brangiausiaPreke);                // kai turiu ToString() overridintą, jo net nereikia rašyti - automatiškai implementuoja.

            Console.WriteLine("Prekių vidurkis yra: ");

            Console.WriteLine(PrekiuVidurkis(prekes));          // nekuriant papildomo kintamojo, bet tikrai galima šitam variantui irgi susikurti papildomą kintamąjį "double prekiuVidurkis" ir taip būtų saugiau.


            Console.WriteLine("-------------- SEKANTIS PAVYZDYS SU RIKIAVIMU -------------------");

            prekes.Sort(new PrekeKainaComparerDidejancia());

            foreach (Preke preke in prekes)
            {
                Console.WriteLine(preke);
            }
        }

        /// <summary>
        /// Nuskaito visas prekes iš tekstinio failo (naudojant dar papildomą konvertavimo eilutės į Prekės funkciją)
        /// </summary>
        /// <returns>Grąžina prekių sąrašą.</returns>
        static List<Preke> NuskaitytiPrekesIsFailo()
        {
            List<Preke> prekes = new List<Preke>();
            string[] eilutes = System.IO.File.ReadAllLines(FailoPavadinimas);

            foreach (string eilute in eilutes.Skip(1).ToArray())
            {
                // Kiekvieną eilutę konvertuoju į Prekės objektą, o tada jau tą prekės objektą dedu į...
                prekes.Add(KonvertuojaEiluteIPreke(eilute));

            }
            return prekes;
        }

        /// <summary>
        /// Konvertuoja vieną tekstinę (String) eilutę į Prekės objektą
        /// </summary>
        /// <param name="eilute">String eilutė, kurią nuskaito iš tekstinio failo ir atsiunčia šitai funkcijai</param>
        /// <returns>Grąžina Prekės objektą</returns>
        static Preke KonvertuojaEiluteIPreke(string eilute)
        {
            string[] stulpeliai = eilute.Split(",");

            // Yra eilutė. Funkcija tą eilutę konvertuoja ir grąžina kaip Prekę, kurią toliau KITOJE funkcijoje dėsime į sąrašą.
            // Jog funkcija konvertuotų eilutę į prekę, reikia eilutę išskaldyti į stulpelius ir kiekvieną stulpelį dėti į atitinkamą prekės kintamąjį
            // Tačiau, ta prekė dar neegzistuoja, mes jos neturime. Ką mums tada reikia daryti? Susikurti tuščią prekę.

            Preke preke = new Preke();

            Console.WriteLine(stulpeliai[0]);

            preke.Id = Convert.ToInt32(stulpeliai[0]);
            preke.Pavadinimas = stulpeliai[1];
            preke.Aprasymas = stulpeliai[2];
            preke.Kaina = Convert.ToDecimal(stulpeliai[3]);
            preke.Kiekis = Convert.ToInt32(stulpeliai[4]);
            preke.Gamintojas = stulpeliai[5];

            return preke;
        }

        /// <summary>
        /// Funkcija suranda brangiausią prekę pagal kainą.
        /// </summary>
        /// <param name="prekes">Prekių sąrašas</param>
        /// <returns>Grąžina brangiausią prekę (Preke objektą)</returns>
        static Preke RastiBrangiausiaPreke(List<Preke> prekes)
        {
            Preke brangiausiaPreke = prekes[0];
            foreach (Preke preke in prekes)
            {
                if (preke.Kaina > brangiausiaPreke.Kaina)
                {
                    brangiausiaPreke = preke;
                }
            }
            return brangiausiaPreke;
        }


        /// <summary>
        /// Funkcija suranda visų prekių kainų sumą.
        /// </summary>
        /// <param name="prekes">Prekių sąrašas</param>
        /// <returns>Grąžina prekių kainų sumą. (decimal skaičių)</returns>
        static decimal PrekiuSuma(List<Preke> prekes)
        {
            decimal prekiuSuma = 0;
            foreach (Preke preke in prekes)
            {
                prekiuSuma += preke.Kaina;
            }
            return prekiuSuma;
        }

        /// <summary>
        /// Funkcija suranda visų prekių kainų vidurkį, taip pat naudojant sumos funkciją.
        /// </summary>
        /// <param name="prekes">Prekių sąrašas</param>
        /// <returns>Grąžina prekių kainų vidurkį.</returns>
        static double PrekiuVidurkis(List<Preke> prekes)
        {
            double prekiuVidurkis;
            prekiuVidurkis = (double) PrekiuSuma(prekes) / prekes.Count;
            return prekiuVidurkis;
        }
    }
}