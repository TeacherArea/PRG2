using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fordonsregister
{
    class Fordon
    {
        //Medlemsvariabler
        public enum Typ { Bil, MC, Lastbil, Släp, Mopedbil }
        private string regNr;
        private string märke;
        private string modell;
        private Typ fordonstyp;


        //Konstruktor (ett slag av klassmetod, enbart gjord för klasser)
        public Fordon(string regnr, string märke, string modell, Typ fordonstyp) // en konstruktor som tar argument
        {
            this.regNr = regnr;
            this.märke = märke;
            this.modell = modell;
            this.fordonstyp = fordonstyp;
        }

        //Get/Set (hämta/sätta medemsvariablerna,  ett annat slag av klassmetod enbart gjord för klasser))
        public string RegNr
        {
            get { return regNr; }

            // set { this.regNr = value; } //Används istället GodkännRegNr() kan det räcka med ett enbart returnerande värde.
            // Testa, men glöm inte kommentera bort den andra set

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

                regNr = value.ToUpper();
            }
        }

        public string Märke
        {
            get { return märke; }
            set { this.märke = value; }
        }

        public string Modell
        {
            get { return modell; }
            set { this.modell = value; }
        }

        public Typ Fordonstyp
        {
            get { return fordonstyp; }
            set { this.fordonstyp = value; }
        }

        //Klassens övriga metoder, här bestående av en annan lösning för att testa RegNr, och en override av ToString()
        public static string GodkännRegNr(string regNr)
        {
            if (regNr.Length == 6)
            {
                for (int i = 0; i < 3; i++)
                    if (!char.IsLetter(regNr[i]))
                        return null;
                for (int i = 3; i < 6; i++)
                    if (!char.IsDigit(regNr[i]))
                        return null;
                return regNr.ToUpper();
            }
            return null;
        }
        public override string ToString()
        {
            return this.regNr + ": " + this.Märke + "\t" + this.Modell + "\t" + this.Fordonstyp;
        }
    }
}
