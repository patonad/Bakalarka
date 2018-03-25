using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FudbalModul
{
    class Hrac
    {
        private string cislo;
        private string meno;
        private int cas;

        public string Cislo
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

        public Hrac(string pcislo, string pmeno)
        {
            this.Cas = 0;
            this.Cislo = pcislo;
            this.Meno = pmeno;

        }
        public String spracujCas()
        {
            int min = this.Cas / 60;
            int sec = this.Cas % 60;

            return string.Format("{0}:{1}", min.ToString().PadLeft(2, '0'), sec.ToString().PadLeft(2, '0'));
        }
    }
}
