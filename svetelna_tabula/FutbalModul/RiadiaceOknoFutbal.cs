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

namespace FutbalModul
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
        
        private void BStartFutbal_Click(object sender, EventArgs e)
        {
            tabula.StartCasovac();
            bRealCasRiadOknoFutbal.Text = "Reálny čas";
        }

        private void BStopFutbal_Click(object sender, EventArgs e)
        {
            tabula.StopCasovac();
        }

        private void BRealCasRiadOknoFutbal_Click(object sender, EventArgs e)
        {
            if (tabula.IdeCas())
            {
                MessageBox.Show("Pre zobrazenie reálneho času treba stopnúť hru");
            }
            else if (bRealCasRiadOknoFutbal.Text == "Hrací čas")
            {
                tabula.HraciCas
                    
                    
                    ();
                bRealCasRiadOknoFutbal.Text = "Reálny čas";
            }
            else
            {
                tabula.RealnyCas();
                bRealCasRiadOknoFutbal.Text = "Hrací čas";
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

        private void BKoniecRiadOknoFutbal_Click(object sender, EventArgs e)
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
            bStartFutbal.Visible = false;
            predlzenie.Visible = true;
            tBPredlzenie.Visible = true;
        }
        public void NastavPolcas(string t)
        {
            lPolcasRiadOknoFutbal.Text =  t;
        }
        public void NastavCas(string t)
        {
            lCasRiadOknoFutbal.Text = t;
        }

        private void Predlzenie_Click(object sender, EventArgs e)
        {
            try
            {
                int pred = Int32.Parse(tBPredlzenie.Text);
                bStartFutbal.Visible = true;
                tabula.Predlzenie(pred);
                tBPredlzenie.Text = "";
            }
            catch
            {
                MessageBox.Show("Nezadal si číslo");
            }
        }

        private void RiadiaceOknoFutbal_Load(object sender, EventArgs e)
        {
            var priecinokPluginov = Path.Combine(new DirectoryInfo(".").FullName, "pluginy");
            var moduly = SpracovavacModulov.NacitajModuly(priecinokPluginov);
            foreach (Reklama modul in moduly)
            {

                reklama.Tag = modul;
                reklama.Text = "Reklama";
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
                MessageBox.Show("Pre zobrazenie reklamy treba stopnúť hru");
            }
        }

        private void BStat_Click(object sender, EventArgs e)
        {
            if (!tabula.IdeCas())
            {
                OvladacStat s = new OvladacStat(idTimHostia,iDTimDomaci, hostia, domaci, dat,"Futbal");
                s.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pre zobrazenie štatistík treba stopnúť hru");
            }
        }

        private void RiadiaceOknoFutbal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Zavri();
        }
    }
}
