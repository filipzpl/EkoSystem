using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EkoSystem.Interface;
using Helpers;
using Helpers.Enums;

namespace EkoSystem.Zwierzeta
{
    internal class Nietoperz : Zwierze, IIstotaZywa
    {
        public Nietoperz(Plec plec) : base(Gatunek.Nietoperz, plec)
        {
            
        }

    }
}
