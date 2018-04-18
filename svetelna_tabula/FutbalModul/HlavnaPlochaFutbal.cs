using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO;
using svetelna_tabula;

namespace FutbalModul
{
    public partial class HlavnaPlochaFutbal : Form
    {
        private Databaza dat;
        private System.Timers.Timer timer, realCasTimer;
        int idTimHostia, iDTimDomaci, idZapasu, m = 0, s = 0, polcas = 1, scoreHostia = 0, scoreDomaci = 0, casZobrazenia = 0, predlzenieCas = 0;
        bool casIde = false;
        private void HlavnaPlochaFutbal_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            // inerval casovacu
            timer.Interval = 1000;
            timer.Elapsed += Tik;
            realCasTimer = new System.Timers.Timer();
            // inerval casovacu
            realCasTimer.Interval = 1000;
            realCasTimer.Elapsed += KontrolujCas;
            //ako primarny sa nastavy monitor 0
            var primary = Screen.AllScreens.ElementAtOrDefault(0);
            // ako externy sa nastavi pridavny monitor a ak niejej tak sa nastvi primarny
            var extended = Screen.AllScreens.FirstOrDefault(s => s != primary) ?? primary;
            // umiestnenie okna
            this.Left = extended.WorkingArea.Left;
            this.Top = extended.WorkingArea.Top;
            // nasobok v akom pomere treba zvecit original
            float nasobok = (float)extended.WorkingArea.Size.Width / (float)this.Width;
            //zvecenie
            Scale(new SizeF(nasobok, nasobok));
            //prejde vsetky labely a zväcsi ich v pomere
            Label label;
            foreach (object item in Controls)
            {
                label = (Label)item;
                label.Font = new Font(label.Font.Name, (float)Math.Floor(label.Font.Size * nasobok));
            }


            LbHostia.Text = hostia;
            LBdomaci.Text = domaci;
        }

        RiadiaceOknoFutbal riadiaceOkno;
        string hostia, domaci;
       
        public HlavnaPlochaFutbal(string pHostia, string pDomaci, RiadiaceOknoFutbal pOkno, Databaza pDat, int pId, int pHos, int pDom)
        {

            this.idZapasu = pId;
            this.iDTimDomaci = pDom;
            this.idTimHostia = pHos;
            dat = pDat;
            riadiaceOkno = pOkno;
            hostia = pHostia;
            domaci = pDomaci;
            
            InitializeComponent();
        }
        
        public void Predlzenie(int cas)
        {
            predlzenieCas += cas;
            lPolcasFutbal.Text = "P";
            riadiaceOkno.NastavPolcas("" + polcas);
        }
        private void Tik(object sender, ElapsedEventArgs e)
        {
            s++;
            Invoke(new Action(() =>
            {
                
                if (s == 60)
                {
                    m++;
                    s = 0;
                }
                // kolko  trva polcas
                if ((m == 45 && polcas == 1)||( m == 90 && polcas == 2 && predlzenieCas==0) ||( m == predlzenieCas + 90 && polcas == 2))// kolko trva pocas
                {
                    this.StopCasovac();
                    if (polcas == 2)
                    {
                        riadiaceOkno.KoniecHry();
                        s = 0;
                        m = 90 + predlzenieCas;

                    }
                    else
                    {
                        polcas++;
                    }
                    if (lPolcasFutbal.Text != "P")
                    {
                        lPolcasFutbal.Text = "" + polcas;
                        riadiaceOkno.NastavPolcas("" + polcas);
                    }
                }

                String aktCas = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                lCasFutbal.Text = aktCas;
                riadiaceOkno.NastavCas(aktCas);
                if (casZobrazenia > 0)
                {
                    casZobrazenia--;
                }
                else
                {
                    lGolHrac.Text = "";
                }
                

            }));
        }


        public void StartCasovac()
        {
            timer.Start();
            casIde = true;
            realCasTimer.Stop();
        }
        public void StopCasovac()
        {
            timer.Stop();
            casIde = false;
        }
        private void ZaznamenajGol(string kto)
        {
            if (kto == "h")
            {
                scoreHostia++;
                lScoreHOSTIA.Text = string.Format("{0}", scoreHostia.ToString().PadLeft(2, '0'));
            }
            else
            {
                scoreDomaci++;
                lScoreDomaci.Text = string.Format("{0}", scoreDomaci.ToString().PadLeft(2, '0'));
            }

        }
        public void StopRealnyCas()
        {
            realCasTimer.Stop();
        }
        private string SpracujCas()
        {
            string cas;
               return cas = "" +  m  + ":" + string.Format("{0}",  s.ToString().PadLeft(2, '0'));
            
           
        }
        public bool Asistencia(string cislo, int id_tim)
        {
            int x = 0;
            if (idZapasu != 0)
            {
                if (cislo != "")
                {
                    

                    if (!Int32.TryParse(cislo, out x))
                    {
                        MessageBox.Show("Hráč neexistuje");
                        return false;
                    }
                    string hrac = dat.ZistiCiJeHrac(id_tim, x);

                    if (hrac != "")
                    {


                        dat.PridajZaznam(idZapasu, id_tim, x, SpracujCas(), "asistencia");
                        dat.UpravAsistencia(id_tim, x);
                        return true;


                    }
                    else
                    {
                        MessageBox.Show("Hráč neexistuje");
                        return false;
                    }

                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (cislo == "") { return true; }
                if (!Int32.TryParse(cislo, out x))
                {
                    MessageBox.Show("Hráč neexistuje");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public void Gol(string cisloGol, string cisloAsis, int id_tim, string kto)
        {
            if (Asistencia(cisloAsis, id_tim))
            {
                int x = 0;

                if (!Int32.TryParse(cisloGol, out x))
                {
                    MessageBox.Show("Hráč neexistuje");
                    return;
                }
                StopCasovac();

                string hrac = dat.ZistiCiJeHrac(id_tim, x);

                if (idZapasu == 0)
                {
                    ZaznamenajGol(kto);
                }
                else if (hrac != "")
                {

                    lGolHrac.Text = cisloGol + "  " + hrac;
                    casZobrazenia = 30;


                    dat.PridajZaznam(idZapasu, id_tim, x, SpracujCas(), "gol");
                    ZaznamenajGol(kto);
                    dat.UpravSkore(idZapasu, scoreHostia, scoreDomaci);
                    dat.UpravGol(id_tim, x);
                }
                else
                {
                    MessageBox.Show("Hráč neexistuje");
                    return;
                }

            }
        }
        
        public bool IdeCas()
        {
            return casIde;
        }
        public void RealnyCas()
        {
            realCasTimer.Start();
        }
        private void KontrolujCas(object sender, ElapsedEventArgs e)
        {
            String cas = DateTime.Now.ToShortTimeString();
            //mut.WaitOne();

            Invoke((MethodInvoker)delegate { lCasFutbal.Text = cas; });
            // lCasHokej.Text = cas;
            //  mut.ReleaseMutex();
        }
        public void HraciCas()
        {
            Invoke((MethodInvoker)delegate { lCasFutbal.Text = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0')); ; });
            realCasTimer.Stop();
        }
    }
}
