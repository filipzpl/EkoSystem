using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stworzymy Nowy Ekosystem;
            var ekoSystem = new EkoSystem();

            // Dodac Elementy Do Ekosystemu;
            var zwierzeA = new Mrowka();
            zwierzeA.NadajImie("Królowa");
            ekoSystem.DodajZwierze(zwierzeA);

            var zwierzeB = new Mrowka(Plec.Mezczyzna);
            zwierzeB.NadajImie("Robotnik");
            ekoSystem.DodajZwierze(zwierzeB);

            // Ekosystem będzie żył;
            // Ekosystem zostanie zniszczony;

            Console.WriteLine(ekoSystem);
            Console.ReadKey();
        }
    }
}
