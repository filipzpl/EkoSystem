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

            #region Mrowki

            // Dodac Elementy Do Ekosystemu;
            var zwierzeA = new Mrowka();
            zwierzeA.NadajImie("A");
            ekoSystem.DodajZwierze(zwierzeA);

            var zwierzeB = new Mrowka(Plec.Kobieta);
            zwierzeB.NadajImie("B");
            ekoSystem.DodajZwierze(zwierzeB);

            var zwierzeC = new Mrowka(Plec.Mezczyzna);
            zwierzeC.NadajImie("C");
            ekoSystem.DodajZwierze(zwierzeC);

            #endregion

            var powietrze = new SurowiecNaturalny("Powietrze", 3000);
            var soleMineralne = new SurowiecNaturalny("Sole Mineralne", 10000);
            ekoSystem.DodajSurowiec(powietrze);
            ekoSystem.DodajSurowiec(soleMineralne);

            // Ekosystem będzie żył;
            var czySieUdalo = zwierzeC.AwansujNaWojownika(zwierzeA);

            
            // Ekosystem zostanie zniszczony;
            zwierzeB.Usmierc();


            Console.WriteLine("Ilosc mrowek: {0}", Mrowka.IloscStworzonychMrowek);

            Console.WriteLine(ekoSystem);
            Console.ReadKey();
        }
    }
}
