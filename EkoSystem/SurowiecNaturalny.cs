using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkoSystem
{
    class SurowiecNaturalny
    {

        #region pola i propercje

        /// <summary>
        /// Opis Słowny Surowca;
        /// </summary>
        private string _nazwa;

        /// <summary>
        /// propercja
        /// </summary>
        public string Nazwa
        {
            get
            {
                return _nazwa;
            }
            private set
            {
                if (value == "")
                {
                    Console.WriteLine("Błąd! Nazwa nie może być pusta!");
                }
                else
                {
                    _nazwa = value;
                }
            }
        }

        /// <summary>
        /// Ilość Danego Surowca w Danej Jednostce;
        /// </summary>
        private ulong _ilosc;

        #endregion

        /// <summary>
        /// Tworzy nowy surowiec naturlany
        /// </summary>
        public SurowiecNaturalny(string nazwa, ulong ilosc)
        {
            Nazwa = nazwa;
            _ilosc = ilosc;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Nazwa + " ("+ _ilosc + ")";
        }


    }
}
