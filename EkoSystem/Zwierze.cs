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

                Console.WriteLine("Zwierze typu {0} umarło!", GetType());

                return true;
            }

            //niemozna zabic martwej mrowki
            return false;
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