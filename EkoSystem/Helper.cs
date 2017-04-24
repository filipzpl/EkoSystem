using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EkoSystem
{
    public static class Helper
    {
        private static Random _randomGenerator = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

         public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();

        }
        /// <summary>
        /// Losuje Plec w proporcji 2 kobiety do 3 mezczyzn
        /// </summary>
        /// <returns></returns>True = Mezczyzna ; False = Kobieta
        public static bool WylosujPlec()
        {
            var liczba = _randomGenerator.Next(5);

            if(liczba < 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static string WylosujImie(Plec plec)
        {
            switch (plec)
            {
                case Plec.Mezczyzna:
                    var listaNazwM = Enum.GetNames(typeof(ImionaMeskie));
                    var losujM = _randomGenerator.Next(listaNazwM.Length);
                    var wylosowaneImieM = listaNazwM[losujM];
                    ImionaMeskie enumImieM;
                    var czySieUdaloM = ImionaMeskie.TryParse(wylosowaneImieM, out enumImieM);
                    if (czySieUdaloM)
                    {
                        return GetEnumDescription(enumImieM);
                    }
                    return wylosowaneImieM;

                case Plec.Kobieta:
                    var listaNazwK = Enum.GetNames(typeof(ImionaZenskie));
                    var losujK = _randomGenerator.Next(listaNazwK.Length);
                    var wylosowaneImieK = listaNazwK[losujK];
                    ImionaZenskie enumImieK;
                    var czySieUdaloK = ImionaZenskie.TryParse(wylosowaneImieK, out enumImieK);
                    if (czySieUdaloK)
                    {
                        return GetEnumDescription(enumImieK);
                    }
                    return wylosowaneImieK;
                default:
                    return "imie" + _randomGenerator.Next().ToString("D10");

            }


        }
    }
}
