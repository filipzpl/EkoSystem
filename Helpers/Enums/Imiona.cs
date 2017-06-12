using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Helpers.Enums
{
    enum ImionaMeskie
    {
        Jano,
        Maro,
        Czaro,
        [/*System.ComponentModel.*/ Description("Mikołaj")]
        Mikolaj,
    }



    enum ImionaZenskie
    {
        Julka,
        Oliwia,
        Karolina,
    }
}
