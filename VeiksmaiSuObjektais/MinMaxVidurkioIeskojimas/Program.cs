using System;

namespace MinMaxVidurkioIeskojimas // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Preke preke = new Preke(10251, "Kėdė", "Medinė sulankstoma kėdė", 23.99m , 4, "UAB Baldai");

            Console.WriteLine(preke.ToString());

            
        }


    }
}