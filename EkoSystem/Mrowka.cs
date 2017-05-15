using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using EkoSystem.Interface;

namespace EkoSystem
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

            Helper.UplynalCzas += PowijMrowke;
        }

        private void PowijMrowke(int ileJednostek)
        {
            var losujPorod = Helper.LosujLiczbe(0, 3);
            var losujPlec = Helper.LosujLiczbe(0, 2);
            if (losujPorod == 1)
            {
                var plec = losujPlec == 0 ? Plec.Kobieta : Plec.Mezczyzna;
                var nowaMrowka = new Mrowka(plec);
                nowaMrowka.NadajImie(Helper.WylosujImie(plec));
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
