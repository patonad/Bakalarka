using Rozhranie;
using svetelna_tabula;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FudbalModul
{
    public partial class RiadiaceOknoFudbal : Form
    {
        private Databaza dat;
        private HlavnaPlochaFudbal tabula;
        private UvodneMenuFudbal okno;
        int idTymHostia, iDTymDomaci;
        string hostia, domaci;
        public RiadiaceOknoFudbal(string pHostia, string pDomaci, UvodneMenuFudbal pOkno, Databaza pDat, int pId, int pHos, int pDom)
        {
            this.dat = pDat;
            this.iDTymDomaci = pDom;
            this.idTymHostia = pHos;
            this.hostia = pHostia;
            this.domaci = pDomaci;
            InitializeComponent();
            this.okno = pOkno;
            this.tabula = new HlavnaPlochaFudbal(pHostia, pDomaci, this, pDat,pId,pHos,pDom);
            tabula.Show();
            bGolDomaci.Text = pDomaci;
            bGolHostia.Text = pHostia;
            

        }
        
        private void bStartFudbal_Click(object sender, EventArgs e)
        {
            tabula.startCasovac();
        }

        private void bStopFudbal_Click(object sender, EventArgs e)
        {
            tabula.stopCasovac();
        }

        private void bRealCasRiadOknoFudbal_Click(object sender, EventArgs e)
        {
            if (tabula.ideCas())
            {
                MessageBox.Show("Pre zobrazenie realneho času treba stopnuť hru");
            }
            else if (bRealCasRiadOknoFudbal.Text == "Hrací čas")
            {
                tabula.hraciCas();
                bRealCasRiadOknoFudbal.Text = "Realny čas";
            }
            else
            {
                tabula.realnyCas();
                bRealCasRiadOknoFudbal.Text = "Hrací čas";
            }
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
                tBAsistencia.Text = "";
                tBHracGol.Text = "";
            }
        }

        private void bKoniecRiadOknoFudbal_Click(object sender, EventArgs e)
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
            bStartFudbal.Visible = false;
            predlzenie.Visible = true;
            tBPredlzenie.Visible = true;
        }
        public void nastavPolcas(string t)
        {
            lPolcasRiadOknoFudbal.Text =  t;
        }
        public void nastavCas(string t)
        {
            lCasRiadOknoFudbal.Text = t;
        }

        private void predlzenie_Click(object sender, EventArgs e)
        {
            try
            {
                int pred = Int32.Parse(tBPredlzenie.Text);
                bStartFudbal.Visible = true;
                tabula.predlzenie(pred);
                tBPredlzenie.Text = "";
            }
            catch
            {
                MessageBox.Show("Nezadal si cislo");
            }
        }

        private void RiadiaceOknoFudbal_Load(object sender, EventArgs e)
        {
            var priecinokPluginov = Path.Combine(new DirectoryInfo(".").FullName, "pluginy");
            var moduly = SpracovavacModulov.NacitajModuly(priecinokPluginov);
            foreach (reklama modul in moduly)
            {

                reklama.Tag = modul;
                reklama.Text = modul.GetType().Name;
                //Image = Image.FromFile(@"Cicon.png").GetThumbnailImage(100, 100, null, IntPtr.Zero)

                reklama.Visible = true;


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
                MessageBox.Show("Pre zobrazenie reklamytreba stopnuť hru");
            }
        }

        private void bStat_Click(object sender, EventArgs e)
        {
            if (!tabula.ideCas())
            {
                OvladacStat s = new OvladacStat(idTymHostia,iDTymDomaci, hostia, domaci, dat,"Fudbal");
                s.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pre zobrazenie štatistýk treba stopnuť hru");
            }
        }

        private void RiadiaceOknoFudbal_FormClosing(object sender, FormClosingEventArgs e)
        {
            zavri();
        }
    }
}
