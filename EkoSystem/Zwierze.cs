namespace EkoSystem
{
    class Zwierze
    {
        protected Gatunek _gatunek;
        protected string _imie;
        protected Plec _plec;

        public Zwierze(Gatunek gatunek, Plec plec)
        {
            _gatunek = gatunek;
            _plec = plec;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imie"></param>
        public void NadajImie(string imie)
        {
            _imie = imie;
        }

        public override string ToString()
        {
            return _gatunek.ToString() + " (" + _imie + ", " + _plec + ")";
        }
    }
}