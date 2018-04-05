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

namespace FudbalModul
{
    public partial class HlavnaPlochaFudbal : Form
    {
        private Databaza dat;
        private System.Timers.Timer timer, realCasTimer;
        int idTimHostia, iDTimDomaci, idZapasu, m = 0, s = 0, polcas = 1, scoreHostia = 0, scoreDomaci = 0, casZobrazenia = 0, predlzenieCas = 0;
        bool casIde = false;
        private void HlavnaPlochaFudbal_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            // inerval casovacu
            timer.Interval = 1000;
            timer.Elapsed += tik;
            realCasTimer = new System.Timers.Timer();
            // inerval casovacu
            realCasTimer.Interval = 1000;
            realCasTimer.Elapsed += kontrolujCas;
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

        RiadiaceOknoFudbal riadiaceOkno;
        string hostia, domaci;
       
        public HlavnaPlochaFudbal(string pHostia, string pDomaci, RiadiaceOknoFudbal pOkno, Databaza pDat, int pId, int pHos, int pDom)
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
        
        public void predlzenie(int cas)
        {
            predlzenieCas = cas;
            lPolcasFudbal.Text = "P";
            riadiaceOkno.nastavPolcas("" + polcas);
        }
        private void tik(object sender, ElapsedEventArgs e)
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
                if ((m == 1 && polcas == 1)||( m == 2 && polcas == 2 && predlzenieCas==0) ||( m == predlzenieCas + 90 && polcas == 2))// kolko trva pocas
                {
                    this.stopCasovac();
                    if (polcas == 2)
                    {
                        riadiaceOkno.koniecHry();
                        s = 0;
                        m = 90 + predlzenieCas;

                    }
                    else
                    {
                        polcas++;
                    }
                    lPolcasFudbal.Text = "" + polcas;
                    riadiaceOkno.nastavPolcas(""+polcas);
                }

                String aktCas = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                lCasFudbal.Text = aktCas;
                riadiaceOkno.nastavCas(aktCas);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void startCasovac()
        {
            timer.Start();
            casIde = true;
            realCasTimer.Stop();
        }
        public void stopCasovac()
        {
            timer.Stop();
            casIde = false;
        }
        private void zaznamenajGol(string kto)
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
        public void stopRealnyCas()
        {
            realCasTimer.Stop();
        }
        private string spracujCas()
        {
            string cas;
               return cas = "" +  m  + ":" + string.Format("{0}",  s.ToString().PadLeft(2, '0'));
            
           
        }
        public bool asistencia(string cislo, int id_tim)
        {
            int x = 0;
            if (idZapasu != 0)
            {
                if (cislo != "")
                {
                    

                    if (!Int32.TryParse(cislo, out x))
                    {
                        MessageBox.Show("Hráč neexzistuje");
                        return false;
                    }
                    string hrac = dat.zistiCiJeHrac(id_tim, x);

                    if (hrac != "")
                    {


                        dat.pridajZaznam(idZapasu, id_tim, x, spracujCas(), "asistencia");
                        dat.upravAsistencia(id_tim, x);
                        return true;


                    }
                    else
                    {
                        MessageBox.Show("Hráč neexzistuje");
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
                    MessageBox.Show("Hráč neexzistuje");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public void gol(string cisloGol, string cisloAsis, int id_tim, string kto)
        {
            if (asistencia(cisloAsis, id_tim))
            {
                int x = 0;

                if (!Int32.TryParse(cisloGol, out x))
                {
                    MessageBox.Show("Hráč neexzistuje");
                    return;
                }
                stopCasovac();

                string hrac = dat.zistiCiJeHrac(id_tim, x);

                if (idZapasu == 0)
                {
                    zaznamenajGol(kto);
                }
                else if (hrac != "")
                {

                    lGolHrac.Text = cisloGol + "  " + hrac;
                    casZobrazenia = 5;


                    dat.pridajZaznam(idZapasu, id_tim, x, spracujCas(), "gol");
                    zaznamenajGol(kto);
                    dat.upravSkore(idZapasu, scoreHostia, scoreDomaci);
                    dat.upravGol(id_tim, x);
                }
                else
                {
                    MessageBox.Show("Hráč neexzistuje");
                    return;
                }

            }
        }
        
        public bool ideCas()
        {
            return casIde;
        }
        public void realnyCas()
        {
            realCasTimer.Start();
        }
        private void kontrolujCas(object sender, ElapsedEventArgs e)
        {
            String cas = DateTime.Now.ToShortTimeString();
            //mut.WaitOne();

            Invoke((MethodInvoker)delegate { lCasFudbal.Text = cas; });
            // lCasHokej.Text = cas;
            //  mut.ReleaseMutex();
        }
        public void hraciCas()
        {
            Invoke((MethodInvoker)delegate { lCasFudbal.Text = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0')); ; });
            realCasTimer.Stop();
        }
    }
}
