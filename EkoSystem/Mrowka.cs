using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkoSystem
{
    class Mrowka : Zwierze
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

        public bool CzyJestKrolowa()
        {
            return _pozycjaHierarchiMrowek.Equals(HierarchiaMrowek.Krolowa);
        }
        public bool AwansujNaWojownika(Mrowka mrowka)
        {
//Metoda: Jesli jest Krolowa, to moze awansowac Robotnice na Wojownika
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
            if (_pozycjaHierarchiMrowek.Equals(HierarchiaMrowek.Krolowa))
            {
                return _gatunek.ToString() + " " + _imie + " ( * " + _plec + ")";
            }
            else if (_pozycjaHierarchiMrowek.Equals(HierarchiaMrowek.Wojownik))
            {
                return _gatunek.ToString() + " " + _imie + " ( # " + _plec + ")";
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
