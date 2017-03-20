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

        //Metoda do konstruowania Mrowek
        public Mrowka(Plec plec) : base(Gatunek.Mrowka, plec)
        {
            _pozycjaHierarchiMrowek = HierarchiaMrowek.Robotnica;
        }

        /// <summary>
        /// Konstruktor Krolowych
        /// </summary>
        public Mrowka() : this(Plec.Kobieta)
        {
            _pozycjaHierarchiMrowek = HierarchiaMrowek.Krolowa;
            
        }
        public override string ToString()
        {
            if(_pozycjaHierarchiMrowek.Equals(HierarchiaMrowek.Krolowa))
            {
                return _gatunek.ToString() + " (* " + _imie + ", " + _plec + ")";
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
