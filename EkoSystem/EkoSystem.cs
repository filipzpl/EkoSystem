using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkoSystem
{
    class EkoSystem
    {
        /// <summary>
        ///Lista Surowców Naturalnych Dostępnych w Ekosystemie;
        /// </summary>
        private List<SurowiecNaturalny> _surowceNaturalne;

        /// <summary>
        /// Lista Zwierząt;
        /// </summary>
        private List<Zwierze> _zwierzeta;
        
        /// <summary>
        /// Konstruktor Domyślny;
        /// </summary>
        public EkoSystem()
        {
            _surowceNaturalne = new List<SurowiecNaturalny>();
            _zwierzeta = new List<Zwierze>();
        }

        #region DodajZwierze
        /// <summary>
        /// Dodaje Zwierzę do Ekosystemu
        /// </summary>
        /// <param name="zwierze">Zwierze do dodania</param>
        public void DodajZwierze(Zwierze zwierze)
        {
            _zwierzeta.Add(zwierze);
        }
        #endregion

        public void DodajSurowiec(SurowiecNaturalny surowiec)
        {
            _surowceNaturalne.Add(surowiec);
        }






        public override string ToString()
        {
            var opisEkosystemu = "";
            opisEkosystemu += "Lista Zwierząt w Ekosystemie" + Environment.NewLine;
            foreach (var zwierz in _zwierzeta)
            {
                opisEkosystemu += zwierz.ToString() + Environment.NewLine;
            }

            opisEkosystemu += Environment.NewLine;
            opisEkosystemu += Environment.NewLine;

            opisEkosystemu += "Lista Surowców Naturalnych w Ekosystemie" + Environment.NewLine;
            foreach (var surowiec in _surowceNaturalne)
            {
                opisEkosystemu += surowiec.ToString() + Environment.NewLine;
            }

            return opisEkosystemu;
        }
    }
}
