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
            #region Mrówki
            var zwierzeA = new Mrowka();
            zwierzeA.NadajImie("A");
            ekoSystem.DodajZwierze(zwierzeA);

            var zwierzeB = new Mrowka(Plec.Mezczyzna);
            zwierzeB.NadajImie("B");
            ekoSystem.DodajZwierze(zwierzeB);

            var zwierzeC = new Mrowka(Plec.Mezczyzna);
            zwierzeC.NadajImie("C");
            ekoSystem.DodajZwierze(zwierzeC);
            #endregion

            #region SurowceNaturalne
            var powietrze = new SurowiecNaturalny("Powietrze", 3000);
            var soleMineralne = new SurowiecNaturalny("SoleMineralne", 10000);
            ekoSystem.DodajSurowiec(powietrze);
            ekoSystem.DodajSurowiec(soleMineralne);

            #endregion

            // Ekosystem będzie żył;
            var czySieUdalo = zwierzeC.AwansujNaWojownika(zwierzeA);

            // Ekosystem zostanie zniszczony;

            Console.WriteLine("Ilość Mrówek: {0} ", Mrowka.IloscStworzonychMrowek);
            Console.WriteLine(ekoSystem);
            Console.ReadKey();
        }
    }
}
