using System;
using System.Runtime.CompilerServices;

namespace EkoSystem
{
    abstract class Zwierze
    {
        protected Gatunek _gatunek;
        protected string _imie;
        protected Plec _plec;

        protected int _pozostalyCzasZycia;

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
            _pozostalyCzasZycia = 10 + Helper.LosujLiczbe(-3, 3);
            
            Helper.UplynalCzas += GdyUplynalCzas;
        }
        private void GdyUplynalCzas(int ileJednostek)
        {
            _pozostalyCzasZycia -= ileJednostek;
            if (_pozostalyCzasZycia <= 0)
            {
                Usmierc();
            }
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
                Console.WriteLine("Zwierze {0} Umarło!", opisZwierzecia());
                return true;
            }
            //Nie można zabić martwej mrówki
            return false;
        }

        protected virtual string opisZwierzecia()
        {
            return GetType().ToString();
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