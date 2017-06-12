using EkoSystem.Surowce;
using EkoSystem.Zwierzeta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EkoSystem
{
    class EkoSystem
    {
        /// <summary>
        ///Lista Surowców Naturalnych Dostępnych w Ekosystemie;
        /// </summary>
        private List<SurowiecNaturalny> _surowceNaturalne;

        /// <summary>
        /// Lista Zwierząt;
        /// </summary>
        private  List<Zwierze> _zwierzeta;


        /*
         * [Jakub] ekosystem nie potrzebuje dodatkowego kontenera na zwierzeta, bo ma juz jeden o nazwie _zwierzeta
         */
        /*private List<Zwierze> _urodzoneZwierzeta;*/
        

        /// <summary>
        /// Konstruktor Domyślny;
        /// </summary>
        public EkoSystem()
        {
            _surowceNaturalne = new List<SurowiecNaturalny>();
            _zwierzeta = new List<Zwierze>();

            /*
             * [Jakub] konstruktor tworzacy nowa liste elementow klasy Zwierze
             * przyjmuje jako parametr liczbe pustych miejsc na liscie do pozniejszego wypelnienia typu INT
             * proba podstawienia tam metody jest bledem
             */
            /*_urodzoneZwierzeta = new List<Zwierze>(zwierzeUrodziloSie);*/
        }


        #region DodajZwierze
        /// <summary>
        /// Dodaje Zwierzę do Ekosystemu
        /// </summary>
        /// <param name="zwierze">Zwierze do dodania</param>
        public void DodajZwierze(Zwierze zwierze)
        {
            _zwierzeta.Add(zwierze);
            zwierze.ZwierzeUmarlo += zwierzeUmarlo;
            
            /*
             * [Jakub] to co nalezalo zrobic aby zaczac dodawac do kolekcji zwierzat ekosystemu
             * wszystkie dzieci zwierzat, ktore juz sa w ekosystemie, to przy dodawaniu 
             * zwierzaka zaczynamy "sluchac" eventu mówiącego, że dziecko się urodzilo
             * i na tym wydarzeniu nalezy nowonarodzone dziecko dodać do naszej kolekcji
             */
            zwierze.ZwierzeUrodziloSie += akcjaGdyZwierzeSieUrodzilo;
        }

        /*
         * [Jakub] to jest metoda pomocnicza, ktora bedzie wywolywana za kazdym razem, gdy 
         * jedno ze zwierzat dodanych do ekosystemu urodzi dziecko
         * jedyne co ona robi, to zwierze, ktore sie urodzi dodaje do ekosystemu
         */
        private void akcjaGdyZwierzeSieUrodzilo(Zwierze zwierzeKtoreSieUrodzilo)
        {
            DodajZwierze(zwierzeKtoreSieUrodzilo);
        }


        private void zwierzeUmarlo(Zwierze zwierzeKtoreUmarlo)
        {
            _zwierzeta.Remove(zwierzeKtoreUmarlo);
            /*
             * [Jakub] gdy zwierze umiera wyświetlimy ile zwierzat zostalo w ekosystemie
             */
            Console.WriteLine("[?] W ekosystemie pozostało {0} zwierzat", _zwierzeta.Count);
        }

        /*
         * [Jakub] ta metoda jest niepotrzebna, jej celem bylo wg. Ciebie dodanie nowego zwierza do listy
         * ale do tego mamy juz metode DodajZwierze, ktora robi dokladnie to samo a nawet troszke wiecej
         * 
         */
        /*private void zwierzeUrodziloSie(Zwierze zwierzeKtoreUrodziloSie)
        {
            _zwierzeta.Add(zwierzeKtoreUrodziloSie);
        }*/

        #endregion

        public void DodajSurowiec(SurowiecNaturalny surowiec)
        {
            _surowceNaturalne.Add(surowiec);
        }

        


        public override string ToString()
        {
            var opisEkosystemu = "";
            opisEkosystemu += "Lista Zwierząt w Ekosystemie" + Environment.NewLine;
            foreach (var zwierz in _zwierzeta)
            {
                opisEkosystemu += zwierz.ToString() + Environment.NewLine;
            }

            opisEkosystemu += Environment.NewLine;
            opisEkosystemu += Environment.NewLine;

            opisEkosystemu += "Lista Surowców Naturalnych w Ekosystemie" + Environment.NewLine;
            foreach (var surowiec in _surowceNaturalne)
            {
                opisEkosystemu += surowiec.ToString() + Environment.NewLine;
            }

            return opisEkosystemu;
        }

    }
}
