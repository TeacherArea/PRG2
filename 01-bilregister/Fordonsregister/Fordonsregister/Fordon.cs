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
        public Fordon(string regnr, string märke, string modell, Typ fordonstyp)
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
            set { this.regNr = value; }
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

        //Klassens övriga (vaniiga metoder)
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
