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
        /// 
        /// </summary>
        /// <param name="imie"></param>
        public void NadajImie(string imie)
        {
            _imie = imie;
        }


        /// <summary>
        /// Zabji mrowke
        /// </summary>
        /// <returns>True gdy mrowką uda się zabić</returns>
        public bool Usmierc()
        {
            if (_czyZyje)
            {
                umieraj();

                Console.WriteLine("Zwierze {0} umarło!", opisZwierzecia());

                return true;
            }

            //niemozna zabic martwej mrowki
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




        public override string ToString()
        {
            return _gatunek.ToString() + " " + _imie + " ( " + _plec + ")";
        }
    }
}