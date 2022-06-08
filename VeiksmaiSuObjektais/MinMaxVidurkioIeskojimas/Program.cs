﻿using System;

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
        
        
        }


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



        static decimal PrekiuSuma(List<Preke> prekes)
        {
            decimal prekiuSuma = 0;
            foreach (Preke preke in prekes)
            {
                prekiuSuma += preke.Kaina;
            }
            return prekiuSuma;
        }


        static double PrekiuVidurkis(List<Preke> prekes)
        {
            double prekiuVidurkis;
            prekiuVidurkis = (double) PrekiuSuma(prekes) / prekes.Count;
            return prekiuVidurkis;
        }
    }
}