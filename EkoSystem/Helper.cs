using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EkoSystem
{
    public static class Helper
    {
        private static Random _randomGenerator = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);


        public static int LosujLiczbe(int min, int max)
        {
            return _randomGenerator.Next(min, max);
        }

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
        /// Losuje plec w proporcji 2K : 3M
        /// </summary>
        /// <returns>True dla mezczyzny i false dla kobiety</returns>
        public static bool WylosujPlec()
        {
            var liczba = _randomGenerator.Next(5);

            return liczba >= 2;
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

        public static void PetlaNieskonczona()
        {
            byte liczba = 0;

            while (true)
            {
                checked
                {
                    liczba++;
                }
                Console.WriteLine("{0}", liczba);
            }
        }

        public static void PetlaNaWatku()
        {
            try
            {
                Helper.PetlaNieskonczona();
            }
            catch (OverflowException e)
            {
                Console.WriteLine("OvFl Ex");
            }
            catch (Exception e)
            {
                Console.WriteLine("Inny Ex");
            }

        }

        public static void PetlaLiczb()
        {
            ulong liczba = 0;

            while (true)
            {
                liczba++;
                Console.WriteLine("{0}", liczba);
                Thread.Sleep(_randomGenerator.Next(100, 500));
            }
        }

        public static void PetlaImion()
        {
            while (true)
            {
                Console.WriteLine("{0}", WylosujImie(Plec.Kobieta));
                Console.WriteLine("{0}", WylosujImie(Plec.Mezczyzna));
                Thread.Sleep(_randomGenerator.Next(100, 500));
            }
        }


        public static void Zegar()
        {
            var jednostkaCzasu = 1000; //ms

            while (true)
            {
                if (UplynalCzas != null)
                {
                    UplynalCzas(1);
                }
                Thread.Sleep(jednostkaCzasu);
            }
        }

        public delegate void UplynalCzasEvent(int ileJednostek);

        public static event UplynalCzasEvent UplynalCzas;

    }
}
