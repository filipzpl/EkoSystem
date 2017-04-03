using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EkoSystem.Interfejsy;

namespace EkoSystem
{
    class Nietoperz : Zwierze, IIstotaZywa
    {
        public Nietoperz(Plec plec) : base(Gatunek.Nietoperz, plec)
        {
        }


    }
}
