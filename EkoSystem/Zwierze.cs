using System;
using System.Runtime.CompilerServices;

namespace EkoSystem
{
    abstract class Zwierze
    {
        protected Gatunek _gatunek;
        protected string _imie;
        protected Plec _plec;

        private bool _czyZyje;

        public bool CzyZyje
        {
            get
            {
                return _czyZyje;
            }
        }


        public Zwierze(Gatunek gatunek, Plec plec)
        {
            _gatunek = gatunek;
            _plec = plec;
            _czyZyje = true;
        }
        ~Zwierze()
        {
            Usmierc();
        }

        /// <summary>
        /// Metoda: Ture > Śmierć : False > Żyje
        /// Metoda do Destrukcji (Destructor) Mrówek
        /// </summary>
        public bool Usmierc()
        {
            if (_czyZyje)
            {
                umieraj();
                Console.WriteLine("Zwierze Typu {0} Umarło!", this.GetType());
                return true;
            }
            //Nie można zabić martwej mrówki
            return false;
        }

        protected virtual void umieraj()
        {
            _czyZyje = false;
        }

        /// <summary>
        /// Nadaje Imie
        /// </summary>
        /// <param name="imie"></param>
        public void NadajImie(string imie)
        {
            _imie = imie;
        }

        public override string ToString()
        {
            return _gatunek.ToString() + " " + _imie + " ( " + _plec + ")";
        }
    }
}