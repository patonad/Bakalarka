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
    public partial class RiadiaceOknoFutbal : Form
    {
        private Databaza dat;
        private HlavnaPlochaFutbal tabula;
        private UvodneMenuFutbal okno;
        int idTimHostia, iDTimDomaci;
        string hostia, domaci;
        public RiadiaceOknoFutbal(string pHostia, string pDomaci, UvodneMenuFutbal pOkno, Databaza pDat, int pId, int pHos, int pDom)
        {
            this.dat = pDat;
            this.iDTimDomaci = pDom;
            this.idTimHostia = pHos;
            this.hostia = pHostia;
            this.domaci = pDomaci;
            InitializeComponent();
            this.okno = pOkno;
            this.tabula = new HlavnaPlochaFutbal(pHostia, pDomaci, this, pDat,pId,pHos,pDom);
            tabula.Show();
            bGolDomaci.Text = pDomaci;
            bGolHostia.Text = pHostia;
            

        }
        
        private void BStartFudbal_Click(object sender, EventArgs e)
        {
            tabula.StartCasovac();
        }

        private void BStopFudbal_Click(object sender, EventArgs e)
        {
            tabula.StopCasovac();
        }

        private void BRealCasRiadOknoFudbal_Click(object sender, EventArgs e)
        {
            if (tabula.IdeCas())
            {
                MessageBox.Show("Pre zobrazenie realneho času treba stopnuť hru");
            }
            else if (bRealCasRiadOknoFudbal.Text == "Hrací čas")
            {
                tabula.HraciCas
                    
                    
                    ();
                bRealCasRiadOknoFudbal.Text = "Realny čas";
            }
            else
            {
                tabula.RealnyCas();
                bRealCasRiadOknoFudbal.Text = "Hrací čas";
            }
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
                tBAsistencia.Text = "";
                tBHracGol.Text = "";
            }
        }

        private void BKoniecRiadOknoFudbal_Click(object sender, EventArgs e)
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
            bStartFudbal.Visible = false;
            predlzenie.Visible = true;
            tBPredlzenie.Visible = true;
        }
        public void NastavPolcas(string t)
        {
            lPolcasRiadOknoFudbal.Text =  t;
        }
        public void NastavCas(string t)
        {
            lCasRiadOknoFudbal.Text = t;
        }

        private void Predlzenie_Click(object sender, EventArgs e)
        {
            try
            {
                int pred = Int32.Parse(tBPredlzenie.Text);
                bStartFudbal.Visible = true;
                tabula.Predlzenie(pred);
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
            foreach (Reklama modul in moduly)
            {

                reklama.Tag = modul;
                reklama.Text = modul.GetType().Name;
                //Image = Image.FromFile(@"Cicon.png").GetThumbnailImage(100, 100, null, IntPtr.Zero)

                reklama.Visible = true;


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
                MessageBox.Show("Pre zobrazenie reklamytreba stopnuť hru");
            }
        }

        private void BStat_Click(object sender, EventArgs e)
        {
            if (!tabula.IdeCas())
            {
                OvladacStat s = new OvladacStat(idTimHostia,iDTimDomaci, hostia, domaci, dat,"Fudbal");
                s.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pre zobrazenie štatistýk treba stopnuť hru");
            }
        }

        private void RiadiaceOknoFudbal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Zavri();
        }
    }
}
