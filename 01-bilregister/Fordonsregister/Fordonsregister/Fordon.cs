using System;

namespace Fordonsregister
{
    class Fordon
    {
        // Medlemsvariabler
        public enum Typ { Bil, MC, Lastbil, Släp, Mopedbil };
        private Typ fordonstyp;
        private string registreringsNummer;
        private string tillverkare;
        private string modell;

        // Konstruktor (en metod med samma namn som klassen, som returnerar ett objekt)
        public Fordon(Typ fordonstyp) // en konstruktor kan, men måste inte, ta parametrar
        {
            this.fordonstyp = fordonstyp;
        }

        // Get-Set för att hålla variablerna privata, och för att validera inkommande värden från UI (user interface, användargränssnittet)
        public string RegistreringsNummer
        {
            get { return registreringsNummer; }

            set
            {
                if (value.Length == 6)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!char.IsLetter(value[i]))
                            throw new ArgumentException("Inkorret registreringsnummer: De första tre tecknen måste vara bokstäver.");
                    }

                    for (int i = 3; i < 6; i++)
                    {
                        if (i < 5)
                        {
                            if (!char.IsDigit(value[i]))
                                throw new ArgumentException("Inkorret registreringsnummer: Det fjärde och femte tecknet måste vara siffror.");
                        }
                        else
                        {
                            if (!char.IsDigit(value[i]) && !char.IsLetter(value[i]))
                                throw new ArgumentException("Inkorret registreringsnummer: Det sjätte tecknet måste vara en siffra eller en bokstav.");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Ett registreringsnummer måste bestå av exakt 6 tecken, med tre bokstäver följt av två siffror och en siffra eller bokstav.");
                }

                registreringsNummer = value.ToUpper();
            }
        }

        // Fordonstyp tas in från dropdown-menyn, och behöver därför inte valideras
        public Typ Fordonstyp
        {
            get { return fordonstyp; }
            set { this.fordonstyp = value; }
        }

        //TODO Tillverkare ska valideras, sparas i objektet och visas i UI
        public string Tillverkare
        {
            get { return tillverkare; }
            set { this.tillverkare = value; }
        }

        //TODO Modell ska valideras, sparas i objektet och visas i UI
        public string Modell
        {
            get { return modell; }
            set { this.modell = value; }
        }

        //TODO Att spara årsmodell ska möjliggöras, ska valideras, sparas i objektet och visas i UI


        // Klassens  eventuella övriga metoder brukar finnas här, här en override av ToString()

        //TODO Modifiera overriden på ToString() så att allt visas som önskat i UIs listBox
        public override string ToString()
        {
            return this.RegistreringsNummer + "\t" + this.Fordonstyp + "\t" + this.Tillverkare + "\t" + this.Modell;
        }
    }
}
