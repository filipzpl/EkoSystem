using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using EkoSystem.Interface;
using Helpers;
using Helpers.Enums;

namespace EkoSystem.Zwierzeta
{
    class Wiewiorka : Zwierze, IIstotaZywa
    {
        public static ulong IloscStworzonychWiewiorek = 0;
        public Wiewiorka(Plec plec) : base(Gatunek.Wiewiorka, plec)
        {
            IloscStworzonychWiewiorek++;

            if (plec == Plec.Kobieta)
            {
                // _pozostalyCzasZycia = 999999;
                Helper.UplynalCzas += PowijPotomstwo;
            }
        }

        protected override void PowijPotomstwo(int ileJednostek)
        {

            if (CzyZyje)
            {
                var losujPorod = Helper.LosujLiczbe(0, 3);
                var losujPlec = Helper.LosujLiczbe(0, 2);
                if (losujPorod == 1)
                {
                    var plec = losujPlec == 0 ? Plec.Kobieta : Plec.Mezczyzna;
                    var nowaWiewiorka = new Wiewiorka(plec);
                    nowaWiewiorka.NadajImie(Helper.WylosujImie(plec));
                    wyslijEventUrodziloSie(nowaWiewiorka);
                }
            }
            else
            {
                Helper.UplynalCzas -= PowijPotomstwo;
            }
        }

        protected override void umieraj()
        {
            IloscStworzonychWiewiorek--;
            base.umieraj();
        }




    }
}
