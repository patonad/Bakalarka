using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rozhranie;
using svetelna_tabula;

namespace HokejModul
{
    public partial class RiadiaceOknoHokej : Form
    {
        private Databaza dat;
        private HlavnaPlochaHokej tabula;
        private UvodneMenuHokej okno;
        int idTimHostia, iDTimDomaci;
        string hostia, domaci;

        public RiadiaceOknoHokej(string pHostia, string pDomaci, UvodneMenuHokej pOkno, Databaza pDat, int pId, int pHos, int pDom)
        {
            this.hostia = pHostia;
            this.domaci = pDomaci;
            this.iDTimDomaci = pDom;
            this.idTimHostia = pHos;
            InitializeComponent();
            dat = pDat;
            this.okno = pOkno;
            this.tabula = new HlavnaPlochaHokej(pHostia, pDomaci, this, dat, pId, pHos, pDom);
            this.tabula.Show();
            bGolDomaci.Text = pDomaci;
            bGolHostia.Text = pHostia;
            bFaulDomaci.Text = pDomaci;
            bFaulHostia.Text = pHostia;

        }

        private void BKoniecRiadOknoHokej_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Zavri()
        {
            tabula.StopCasovac();
            tabula.StopRealnyCas();
            tabula.Close();
            this.Close();
            okno.Visible = true;
        }



        public void KoniecHry()
        {
            bStartHokej.Visible = false;
            predlzenie.Visible = true;
            tBPredlzenie.Visible = true;
        }

        public void NastavTretina(string t)
        {
            lTretinaRiadOknoHokej.Text = t;
        }
        public void NastavCas(string t)
        {
            lCasRiadOknoHokej.Text = t;
        }

        private void BStartHokej_Click(object sender, EventArgs e)
        {
            tabula.StartCasovac();
        }

        private void BStopHokej_Click(object sender, EventArgs e)
        {
            tabula.StopCasovac();
        }

        private void BGolHostia_Click(object sender, EventArgs e)
        {
            if (tBHracGol.Text != "")
            {
                tabula.Gol(tBHracGol.Text, tBAsistencia.Text, idTimHostia, "h");
                tBHracGol.Text = "";
                tBAsistencia.Text = "";
            }
        }

        private void BGolDomaci_Click(object sender, EventArgs e)
        {
            if (tBHracGol.Text != "")
            {
                tabula.Gol(tBHracGol.Text, tBAsistencia.Text, iDTimDomaci, "d");
                tBHracGol.Text = "";
                tBAsistencia.Text = "";
            }
        }

        private void BFaulHostia_Click(object sender, EventArgs e)
        {
            if (tBHracFaul.Text != "")
            {
                tabula.Faul(tBHracFaul.Text, idTimHostia, "h");
                tBHracFaul.Text = "";
            }
        }

        private void BFaulDomaci_Click(object sender, EventArgs e)
        {
            if (tBHracFaul.Text != "")
            {
                tabula.Faul(tBHracFaul.Text, iDTimDomaci, "d");
                tBHracFaul.Text = "";
            }
        }

        private void BRealCasRiadOknoHokej_Click(object sender, EventArgs e)
        {
            if (tabula.IdeCas())
            {
                MessageBox.Show("Pre zobrazenie realneho času treba stopnuť hru");
            }
            else if (bRealCasRiadOknoHokej.Text == "Hrací čas")
            {
                tabula.HraciCas();
                bRealCasRiadOknoHokej.Text = "Realny čas";
            }
            else
            {
                tabula.RealnyCas();
                bRealCasRiadOknoHokej.Text = "Hrací čas";
            }

        }

        private void Predlzenie_Click(object sender, EventArgs e)
        {
            try
            {
                int pred = Int32.Parse(tBPredlzenie.Text);
                bStartHokej.Visible = true;
                tabula.Predlzenie(pred);
                tBPredlzenie.Text = "";
            }
            catch
            {
                MessageBox.Show("Nezadal si cislo");
            }



        }

        private void RiadiaceOknoHokej_Load(object sender, EventArgs e)
        {
            var priecinokPluginov = Path.Combine(new DirectoryInfo(".").FullName, "pluginy");
            var moduly = SpracovavacModulov.NacitajModuly(priecinokPluginov);
            foreach (Reklama modul in moduly)
            {
                {

                    reklama.Tag = modul;
                    reklama.Text = modul.GetType().Name;
                    reklama.Visible = true;
                }

            }
        }
        private void Reklama_Click(object sender, EventArgs e)
        {
            if (!tabula.IdeCas())
            {
                var button = (Button)sender;
                var modul = (Reklama)button.Tag;
                modul.Prezentuj();
            }
            else
            {
                MessageBox.Show("Pre zobrazenie reklamy treba stopnuť hru");
            }
        }

        private void BStat_Click(object sender, EventArgs e)
        {
            if (!tabula.IdeCas())
            {
                OvladacStat s = new OvladacStat(idTimHostia, iDTimDomaci, hostia, domaci, dat, "Hokej");

                s.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pre zobrazenie štatistýk treba stopnuť hru");
            }
        }

        private void RiadiaceOknoHokej_FormClosing(object sender, FormClosingEventArgs e)
        {
            Zavri();
        }
    }
}
