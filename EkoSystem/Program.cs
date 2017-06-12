using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EkoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Wątek
            //var watekPoboczny1 = new Thread(Helper.PetlaLiczb);
            //var watekPoboczny2 = new Thread(Helper.PetlaImion);

            //watekPoboczny2.IsBackground = true;
            //watekPoboczny1.IsBackground = true;

            //watekPoboczny1.Start();
            //watekPoboczny2.Start();
            #endregion

            var czasTikTak1 = new Thread(Helper.Zegar);
            czasTikTak1.IsBackground = true;
            czasTikTak1.Start();

            // Stworzymy Nowy Ekosystem;
            var ekoSystem = new EkoSystem();


            // Dodac Elementy Do Ekosystemu;
            #region Mrówki
            var zwierzeA = new Mrowka();
            zwierzeA.NadajImie("A");
            ekoSystem.DodajZwierze(zwierzeA);

            var zwierzeB = new Mrowka(Plec.Kobieta);
            zwierzeB.NadajImie("B");
            ekoSystem.DodajZwierze(zwierzeB);

            var zwierzeC = new Mrowka(Plec.Mezczyzna);
            zwierzeC.NadajImie("C");
            ekoSystem.DodajZwierze(zwierzeC);

            for(int licznik = 0; licznik<10; licznik++)
            {
                var plec = Helper.WylosujPlec() ? Plec.Mezczyzna : Plec.Kobieta;
                var mrowkaX = new Mrowka(plec);
                mrowkaX.NadajImie(Helper.WylosujImie(plec));
                ekoSystem.DodajZwierze(mrowkaX);
            }
            #endregion
            #region SurowceNaturalne
            var powietrze = new SurowiecNaturalny("Powietrze", 3000);
            var soleMineralne = new SurowiecNaturalny("SoleMineralne", 10000);
            ekoSystem.DodajSurowiec(powietrze);
            ekoSystem.DodajSurowiec(soleMineralne);

            #endregion

            var wiewiorkaA = new Wiewiorka(Plec.Kobieta);
            wiewiorkaA.NadajImie("Gejminn");
            ekoSystem.DodajZwierze(wiewiorkaA);


            // Ekosystem będzie żył;
            var czySieUdalo = zwierzeC.AwansujNaWojownika(zwierzeA);



            
            // Ekosystem zostanie zniszczony;
            zwierzeB.Usmierc();

            Console.WriteLine("Ilość Mrówek: {0} ", Mrowka.IloscStworzonychMrowek);
            Console.WriteLine("Ilość Wiewiórek {0} ", Wiewiorka.IloscStworzonychWiewiorek);
            Console.WriteLine(ekoSystem);
            Console.ReadKey();
        }
    }
}
