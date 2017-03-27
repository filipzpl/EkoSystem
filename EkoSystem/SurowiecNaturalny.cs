using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkoSystem
{
    class SurowiecNaturalny
    {
        #region Pola i Propercje
        /// <summary>
        /// Opis Słowny Surowca;
        /// </summary>
        private string _nazwa;

        /// <summary>
        /// Auto propercja
        /// </summary>
///        public string NazwaAutoPropercja { get; set; }

        /// <summary>
        /// Propercja
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
                    Console.WriteLine("Błąd!");
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

        public SurowiecNaturalny(string nazwa, ulong ilosc)
        {
            Nazwa = nazwa;
            _ilosc = ilosc;
        }


        public override string ToString()
        {
            return Nazwa + " (" + _ilosc + ") ";
        }

    }
}
