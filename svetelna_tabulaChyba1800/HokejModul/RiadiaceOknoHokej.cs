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
        int idTymHostia, iDTymDomaci;
        string hostia, domaci;
        /// <summary>
        /// Konstruktor pre vytvorenie riadiaceho okna 
        /// nastavuje nazvi pre buttony
        /// </summary>
        /// <param name="pHostia"></param>
        /// <param name="pDomaci"></param>
        /// <param name="pOkno"></param>
        public RiadiaceOknoHokej(string pHostia, string pDomaci, UvodneMenuHokej pOkno, Databaza pDat, int pId, int pHos, int pDom)
        {
            this.hostia = pHostia;
            this.domaci = pDomaci;
            this.iDTymDomaci = pDom;
            this.idTymHostia = pHos;
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
        ~RiadiaceOknoHokej()
        {
            tabula.Close();
        }
        /// <summary>
        /// Po kliknuti na button koniec sa ukonci tabula a riadiace okno a zobrazi sa naspät uvoden menu hokeju
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>






        private void bKoniecRiadOknoHokej_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zavri()
        {
            tabula.stopCasovac();
            tabula.stopRealnyCas();
            tabula.Close();
            this.Close();
            okno.Visible = true;
        }



        public void koniecHry()
        {
            bStartHokej.Visible = false;
            predlzenie.Visible = true;
            tBPredlzenie.Visible = true;
        }

        public void nastavTretina(string t)
        {
            lTretinaRiadOknoHokej.Text = t;
        }
        public void nastavCas(string t)
        {
            lCasRiadOknoHokej.Text = t;
        }

        private void bStartHokej_Click(object sender, EventArgs e)
        {
            tabula.startCasovac();
        }

        private void bStopHokej_Click(object sender, EventArgs e)
        {
            tabula.stopCasovac();
        }

        private void bGolHostia_Click(object sender, EventArgs e)
        {
            if (tBHracGol.Text != "")
            {
                tabula.gol(tBHracGol.Text, tBAsistencia.Text, idTymHostia, "h");
                tBHracGol.Text = "";
                tBAsistencia.Text = "";
            }
        }

        private void bGolDomaci_Click(object sender, EventArgs e)
        {
            if (tBHracGol.Text != "")
            {
                tabula.gol(tBHracGol.Text, tBAsistencia.Text, iDTymDomaci, "d");
                tBHracGol.Text = "";
                tBAsistencia.Text = "";
            }
        }

        private void bFaulHostia_Click(object sender, EventArgs e)
        {
            if (tBHracFaul.Text != "")
            {
                tabula.faul(tBHracFaul.Text, idTymHostia, "h");
                tBHracFaul.Text = "";
            }
        }

        private void bFaulDomaci_Click(object sender, EventArgs e)
        {
            if (tBHracFaul.Text != "")
            {
               tabula.faul(tBHracFaul.Text, iDTymDomaci, "d");
                tBHracFaul.Text = "";
            }
        }

        private void bRealCasRiadOknoHokej_Click(object sender, EventArgs e)
        {
            if (tabula.ideCas())
            {
                MessageBox.Show("Pre zobrazenie realneho času treba stopnuť hru");
            }
            else if (bRealCasRiadOknoHokej.Text == "Hrací čas")
            {
                tabula.hraciCas();
                bRealCasRiadOknoHokej.Text = "Realny čas";
            }
            else
            {
                tabula.realnyCas();
                bRealCasRiadOknoHokej.Text = "Hrací čas";
            }

        }

        private void predlzenie_Click(object sender, EventArgs e)
        {
            try
            {
                int pred = Int32.Parse(tBPredlzenie.Text);
                bStartHokej.Visible = true;
                tabula.predlzenie(pred);
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
            foreach (reklama modul in moduly)
            {


                {

                    reklama.Tag = modul;
                    reklama.Text = modul.GetType().Name;
                    //Image = Image.FromFile(@"Cicon.png").GetThumbnailImage(100, 100, null, IntPtr.Zero)

                    reklama.Visible = true;


                }

            }
        }
        private void reklama_Click(object sender, EventArgs e)
        {
            if (!tabula.ideCas())
            {
                var button = (Button)sender;
                var modul = (reklama)button.Tag;
                modul.Prezentuj();
            }
            else
            {
                MessageBox.Show("Pre zobrazenie reklamy treba stopnuť hru");
            }
        }

        private void bStat_Click(object sender, EventArgs e)
        {
            if (!tabula.ideCas())
            {
                OvladacStat s = new OvladacStat(idTymHostia,iDTymDomaci,hostia,domaci,dat);
                s.Show();
            }
            else
            {
                MessageBox.Show("Pre zobrazenie štatistýk treba stopnuť hru");
            }
        }

        private void RiadiaceOknoHokej_FormClosing(object sender, FormClosingEventArgs e)
        {
            zavri();
        }
    }
}
