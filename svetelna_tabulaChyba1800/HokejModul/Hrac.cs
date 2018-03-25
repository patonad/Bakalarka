using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HokejModul
{
    class Hrac
    {
        private int cislo;
        private string meno;
        private int cas;
        private string priezvisko;

        public int Cislo
        {
            get
            {
                return cislo;
            }

            set
            {
                cislo = value;
            }
        }

        public string Meno
        {
            get
            {
                return meno;
            }

            set
            {
                meno = value;
            }
        }

        public int Cas
        {
            get
            {
                return cas;
            }

            set
            {
                cas = value;
            }
        }

        public string Priezvisko
        {
            get
            {
                return priezvisko;
            }

            set
            {
                priezvisko = value;
            }
        }

        public Hrac(int pcislo, string pmeno, string pPriez)
        {
            this.Cas = 0;
            this.Cislo = pcislo;
            this.Meno = pmeno;
            this.Priezvisko = pPriez;

        }
        public String spracujCas()
        {
            int min = this.Cas / 60;
            int sec = this.Cas % 60;

            return string.Format("{0}:{1}", min.ToString().PadLeft(2, '0'), sec.ToString().PadLeft(2, '0'));
        }
    }
}
