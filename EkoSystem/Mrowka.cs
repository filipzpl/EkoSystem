using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using EkoSystem.Interfejsy;

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
                return _gatunek.ToString() + " " + _imie + " ( * " + _plec + (CzyZyje ? "" : " [*] ")+")"; 
            }
            else if (_pozycjaHierarchiMrowek.Equals(HierarchiaMrowek.Wojownik))
            {
                return _gatunek.ToString() + " " + _imie + " ( # " + _plec + (CzyZyje ? "" : " [*] ") + ")";
            }
            else
            {
                return _gatunek.ToString() + " " + _imie + " ( Z " + _plec + (CzyZyje ? "" : " [*] ") + ")";
            }
        }
    }
}
