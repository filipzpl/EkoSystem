using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkoSystem
{
    enum ImionaMeskie
    {
        Janek,
        Marek,
        Zbyszek,
        [Description("Mikołaj")]
        Mikolaj,
    }


    enum ImionaZenskie
    {
        Ala,
        Maria,
        Zosia,
        [Description("Łucja")]
        Lucja,
    }
}
