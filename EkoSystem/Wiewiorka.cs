using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using EkoSystem.Interface;

namespace EkoSystem
{
    class Wiewiorka : Zwierze, IIstotaZywa
    {
        public static ulong IloscStworzonychWiewiorek = 0;
        public Wiewiorka(Plec plec) : base(Gatunek.Wiewiorka, plec)
        {
            IloscStworzonychWiewiorek++;
        }
    }
}
