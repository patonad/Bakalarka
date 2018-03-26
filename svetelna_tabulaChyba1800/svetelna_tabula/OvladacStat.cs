using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace svetelna_tabula
{
    public partial class OvladacStat : Form
    {
        ZobrazovacStat z;
        ZobrazovacStat z2;
        int id_hostia, id_domaci;
        string hostia, domaci, sport;
        Databaza dat;
        
        public OvladacStat(int id_hostia, int id_domaci, string hostia, string domaci, Databaza dat, string sport)
        {
            
            this.sport = sport;
            this.id_domaci = id_domaci;
            this.id_hostia = id_hostia;
            this.hostia = hostia;
            this.domaci = domaci;
            this.dat = dat;
            InitializeComponent();
            bTop10Hostia.Text = hostia;
            bTop10Domaci.Text = domaci;
        }

        private void OvladacStat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (z != null) { z.Close(); }
            if (z2 != null) { z2.Close(); }
            
        }

        private void vTop10Celkovo_Click(object sender, EventArgs e)
        {
            if (z2 == null)
            {
                z2 = new ZobrazovacStat();
                z2.Show();
            }
            if (z != null)
            {
                z.Close();
            }
            z = new ZobrazovacStat();
            z.vloz(dat.nacitajTop10Celkovo(sport), "Top 10 hráčov celkovo");
            z.Show();
        }

        private void OvladacStat_Load(object sender, EventArgs e)
        {

        }

        private void bOdhohrateZapasy_Click(object sender, EventArgs e)
        {
            if (id_hostia == 0 || id_domaci == 0)
            {
                MessageBox.Show("Tým nebol najdený");
            }
            else {
                if (z2 == null)
                {
                    z2 = new ZobrazovacStat();
                    z2.Show();
                }
                if (z != null)
                {
                    z.Close();
                }
                z = new ZobrazovacStat();
                z.vloz(dat.nacitajOdohrateZapasy(id_hostia,id_domaci), "Tabuľka zápasov");
                z.Show();

            }
        }

        private void bTop10Hostia_Click(object sender, EventArgs e)
        {
            if (id_hostia != 0)
            {
                if (z2 == null)
                {
                    z2 = new ZobrazovacStat();
                    z2.Show();
                }
                if (z != null)
                {
                    z.Close();
                }
                z = new ZobrazovacStat();
                z.vloz(dat.nacitajTop10(id_hostia), "Top 10 hráčov týmu: " + hostia);
                z.Show();


            }
            else
            {
                MessageBox.Show("Tým nebol najdený");
            }
        }

        private void bTop10Domaci_Click(object sender, EventArgs e)
        {

            if (id_domaci != 0)
            {
                if (z2 == null)
                {
                    z2 = new ZobrazovacStat();
                    z2.Show();
                }
                if (z != null)
                {
                    z.Close();
                }
                z = new ZobrazovacStat();
                z.vloz(dat.nacitajTop10(id_domaci), "Top 10 hráčov týmu: " + domaci);
                z.Show();


            }
            else
            {
                MessageBox.Show("Tým nebol najdený");
            }
        }
    }
}
