﻿using Helpers;
using System;
using System.Runtime.CompilerServices;
using Helpers.Enums;

namespace EkoSystem.Zwierzeta
{
    abstract class Zwierze
    {
        protected Gatunek _gatunek;
        protected string _imie;
        protected Plec _plec;

        protected int _pozostalyCzasZycia;

        private bool _czyZyje;
        private Gatunek mrowka;
        private Plec plec;

        public bool CzyZyje
        {
            get
            {
                return _czyZyje;
            }
        }

        protected virtual void PowijPotomstwo(int ileJednostek)
        {
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
                Console.WriteLine("[-] Zwierze {0} Umarło!", opisZwierzecia());
                umieraj();
                return true;
            }
            //Nie można zabić martwej mrówki
            return false;
        }

        protected virtual string opisZwierzecia()
        {
            //return GetType().ToString();
            return string.Format("{0} {1}", _gatunek, _imie);
        }

        protected virtual void umieraj()
        {
            _czyZyje = false;
            if (ZwierzeUmarlo != null)
            {
                ZwierzeUmarlo(this);
            }
        }

        protected void wyslijEventUrodziloSie(Zwierze zwierze)
        {
            /*
             * [Jakub] brakowo nam podczas działania programu informacji o tym, że zwierzęta się rodziły
             * teraz naprawiamy ten błąd
             */
            Console.WriteLine("[+] Zwierze {0} urodziło się!", zwierze.opisZwierzecia());

            if (ZwierzeUrodziloSie != null)
            {
                ZwierzeUrodziloSie(zwierze);
            }
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

        public delegate void ZwierzeUmarloEvent(Zwierze zwierzeKtoreUmarlo);
        public event ZwierzeUmarloEvent ZwierzeUmarlo;

        public delegate void ZwierzeUrodziloSieEvent(Zwierze zwierzeKtoreSieUrodzilo);
        public event ZwierzeUrodziloSieEvent ZwierzeUrodziloSie;
    }
}