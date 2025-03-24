namespace Object
{
    class Auto
    {
        public string Marka { get; set; }
        public string Rendszam { get; set; }

        public override bool Equals(object obj)
        {
            // Ha null vagy nem Auto típus, nem egyenlő
            if (obj == null || !(obj is Auto))
                return false;

            // Átalakítjuk Auto típusra
            Auto masikAuto = (Auto)obj;

            // Két autó akkor egyenlő, ha a rendszámuk megegyezik
            return this.Rendszam == masikAuto.Rendszam;
        }

        public override int GetHashCode()
        {
            // Fontos: ha Equals felül van írva, akkor GetHashCode is legyen!
            return Rendszam == null ? 0 : Rendszam.GetHashCode();
        }
    }

}
