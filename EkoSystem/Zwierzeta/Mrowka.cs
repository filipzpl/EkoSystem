using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using EkoSystem.Interface;
using Helpers;
using Helpers.Enums;

namespace EkoSystem.Zwierzeta
{
    class Mrowka : Zwierze, IIstotaZywa
    {
        private HierarchiaMrowek _pozycjaHierarchiMrowek;

        public static ulong IloscStworzonychMrowek = 0;

        //Metoda do konstruowania Mrowek
        public Mrowka(Plec plec) : base(Gatunek.Mrowka, plec)
        {
            IloscStworzonychMrowek++;
            _pozycjaHierarchiMrowek = HierarchiaMrowek.Robotnica;
        }

        /// <summary>
        /// Konstruktor Krolowych
        /// </summary>
        public Mrowka() : this(Plec.Kobieta)
        {
            _pozycjaHierarchiMrowek = HierarchiaMrowek.Krolowa;

            /*
             * [Jakub] z racji że na tę chwilę, tylko mrówki, które są królowymi potrafią rodzić
             * potomstwo, to musimy wydluzyc jej czas zycia, aby nasz ekosystem rozwijał się trochę 
             * dłużej niż kilka sekund
             */
            _pozostalyCzasZycia = 999999;

            Helper.UplynalCzas += PowijPotomstwo;
        }

        protected override void PowijPotomstwo(int ileJednostek)
        {

            if (CzyZyje)
            {
                var losujPorod = Helper.LosujLiczbe(0, 3);
                var losujPlec = Helper.LosujLiczbe(0, 2);
                if (losujPorod == 1)
                {
                    var plec = losujPlec == 0 ? Plec.Kobieta : Plec.Mezczyzna;
                    var nowaMrowka = new Mrowka(plec);
                    nowaMrowka.NadajImie(Helper.WylosujImie(plec));
                    wyslijEventUrodziloSie(nowaMrowka);
                }
            }
            else
            {
                Helper.UplynalCzas -= PowijPotomstwo;
            }


        }

        protected override void umieraj()
        {
            IloscStworzonychMrowek--;
            base.umieraj();
        }

        /// <summary>
        /// Sprawdzenie czy mrówka jest krówlową
        /// </summary>
        /// <returns>
        /// Zwraca True jeżli jest krówlową, False w przeciwnym wypadku
        /// </returns>
        public bool CzyJestKrolowa()
        {
            return _pozycjaHierarchiMrowek.Equals(HierarchiaMrowek.Krolowa);
        }

        public bool AwansujNaWojownika(Mrowka mrowka)
        {
            if (mrowka.CzyJestKrolowa())
            {
                _pozycjaHierarchiMrowek = HierarchiaMrowek.Wojownik;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            if(_pozycjaHierarchiMrowek.Equals(HierarchiaMrowek.Krolowa))
            {
                return krotkiOpis() + " ( * " + _plec + (CzyZyje ? "" : " [*] ")+")"; 
            }
            else if (_pozycjaHierarchiMrowek.Equals(HierarchiaMrowek.Wojownik))
            {
                return krotkiOpis() + " ( # " + _plec + (CzyZyje ? "" : " [*] ") + ")";
            }
            else
            {
                return krotkiOpis() + " ( _ " + _plec + (CzyZyje ? "" : " [*] ") + ")";
            }
        }

        protected override string opisZwierzecia()
        {
            return krotkiOpis();
        }


        private string krotkiOpis()
        {
            return _gatunek.ToString() + " " + _imie;
        }
    }
}
