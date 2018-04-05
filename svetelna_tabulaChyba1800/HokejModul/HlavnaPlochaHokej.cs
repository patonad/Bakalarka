using Oracle.ManagedDataAccess.Client;
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


namespace HokejModul
{
    public partial class HlavnaPlochaHokej : Form
    {
        private Databaza dat;
        private System.Timers.Timer timer, realCasTimer;
        int idZapasu, idTimHostia, predlzenieCas = 0, iDTimDomaci, m = 20, s = 0, tretina = 1, scoreHostia = 0, scoreDomaci = 0, casZobrazenia = 0;
        bool casIde = false;


        RiadiaceOknoHokej riadiaceOkno;
        string hostia, domaci;
        List<int> vylucenyHostia;
        List<int> vylucenyDomaci;

        public HlavnaPlochaHokej(string pHostia, string pDomaci, RiadiaceOknoHokej pOkno, Databaza pDat, int pId, int pHos, int pDom)
        {
            this.idZapasu = pId;
            this.iDTimDomaci = pDom;
            this.idTimHostia = pHos;
            dat = pDat;
            riadiaceOkno = pOkno;
            hostia = pHostia;
            domaci = pDomaci;
            InitializeComponent();
            vylucenyHostia = new List<int>();
            vylucenyDomaci = new List<int>();


        }
        private void HlavnaPlochaHokej_Load(object sender, EventArgs e)
        {
            // casovac
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
       
        private void tik(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (!(s == 0 && m == 0))
                {
                    if (vylucenyDomaci.Count != 0)
                    {
                        faulTikDomaci();
                    }
                    else
                    {
                        label9.Visible = false;
                        lbDomPe.Visible = false;
                        label13.Visible = false;

                    }
                    if (vylucenyHostia.Count != 0)
                    {
                        faulTikHostia();
                    }
                    else
                    {
                        label7.Visible = false;
                        lbHostiaPe.Visible = false;
                        label11.Visible = false;
                    }
                }

                s--;
                if (casZobrazenia > 0)
                {
                    casZobrazenia--;
                }
                else
                {
                    lGolHrac.Text = "";
                }
                if (s == -1)
                {
                    m--;
                    s = 59;
                }
                if (m == -1)
                {
                    s = 2; //kolko trva tretina
                    m = 0;
                    this.stopCasovac();
                    if (tretina == 3)
                    {
                        lGolHrac.Text = "";
                        riadiaceOkno.koniecHry();
                        s = 0;
                        m = 0;

                    }
                    else
                    {
                        lGolHrac.Text = "";
                        tretina++;
                        lTretinaHokej.Text = "" + tretina;
                        riadiaceOkno.nastavTretina("" + tretina);
                    }

                }

                String aktCas = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                lCasHokej.Text = aktCas;

                riadiaceOkno.nastavCas(aktCas);

            }));
        }
        public void predlzenie(int cas)
        {
            m = cas;
            predlzenieCas += cas;
            lTretinaHokej.Text = "P";
            riadiaceOkno.nastavTretina("P" + tretina);
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
        private string spracujCas()
        {
            string cas;
            if (s == 0)
            {
                return cas = "" + (tretina * 20 - m + predlzenieCas) + ":00";// + string.Format("{0}", s.ToString().PadLeft(2, '0'));
            }
            else
            {
                return cas = "" + (tretina * 19 - m + tretina - 1 + predlzenieCas) + ":" + string.Format("{0}", (60 - s).ToString().PadLeft(2, '0'));
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
        public void stopRealnyCas()
        {
            realCasTimer.Stop();
        }
        private void kontrolujCas(object sender, ElapsedEventArgs e)
        {
            String cas = DateTime.Now.ToShortTimeString();
            //mut.WaitOne();

            Invoke((MethodInvoker)delegate { lCasHokej.Text = cas; });
            // lCasHokej.Text = cas;
            //  mut.ReleaseMutex();
        }
        public void hraciCas()
        {
            Invoke((MethodInvoker)delegate { lCasHokej.Text = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0')); ; });
            realCasTimer.Stop();
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
        private void pridajFaul(string kto)
        {
            if (kto == "h")
            {
                vylucenyHostia.Insert(0, 5);
            }
            else
            {
                vylucenyDomaci.Insert(0, 5);
            }
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
        public void faul(string cislo, int id_tim, string kto)
        {

            int x = 0;

            if (!Int32.TryParse(cislo, out x))
            {
                MessageBox.Show("Hráč neexzistuje");
                return;
            }
            stopCasovac();

            string hrac = dat.zistiCiJeHrac(id_tim, x);

            if (idZapasu == 0)
            {
                pridajFaul(kto);
            }
            else if (hrac != "")
            {
                dat.pridajZaznam(idZapasu, id_tim, x, spracujCas(), "faul");
                dat.upravFaul(id_tim, x);
                pridajFaul(kto);
            }
            else
            {
                MessageBox.Show("Hráč neexzistuje");
                return;
            }





        }
        private String spracujCasFaul(int Cas)
        {
            return string.Format("{0}:{1}", (Cas / 60).ToString().PadLeft(2, '0'), (Cas % 60).ToString().PadLeft(2, '0'));
        }

        private void faulTikDomaci()
        {
            int a = vylucenyDomaci.Count - 1;
            int kolko;
            bool zmaz = true;
            if (a > 1)
            {
                kolko = a - 1;
            }
            else
            {
                kolko = 0;
            }
            for (int i = a; i >= kolko; i--)
            {
                int cas = vylucenyDomaci[i];
                if (i == a)
                {
                    label9.Visible = true;
                    lbDomPe.Visible = true;
                    label9.Text = spracujCasFaul(cas);
                }
                else
                {
                    label13.Visible = true;
                    label13.Text = spracujCasFaul(cas);
                }

                cas--;
                if (cas == -1)
                {
                    vylucenyDomaci.RemoveAt(i);
                    zmaz = false;
                }
                else
                {
                    vylucenyDomaci[i] = cas;
                }
            }
            if (vylucenyDomaci.Count == 1 && label13.Visible && zmaz)
            {
                label13.Visible = false;
            }
        }

        private void faulTikHostia()
        {
            int a = vylucenyHostia.Count - 1;
            int kolko;
            bool zmaz = true;
            if (a > 1)
            {
                kolko = a - 1;
            }
            else
            {
                kolko = 0;
            }
            for (int i = a; i >= kolko; i--)
            {
                int cas = vylucenyHostia[i];
                if (i == a)
                {
                    label7.Visible = true;
                    lbHostiaPe.Visible = true;
                    label7.Text = spracujCasFaul(cas);
                }
                else
                {
                    label11.Visible = true;
                    lbHostiaPe.Visible = true;
                    label11.Text = spracujCasFaul(cas);
                }

                cas--;
                if (cas == -1)
                {
                    vylucenyHostia.RemoveAt(i);
                    zmaz = false;
                }
                else
                {
                    vylucenyHostia[i] = cas;

                }
                if (vylucenyHostia.Count == 1 && label11.Visible && zmaz)
                {
                    label11.Visible = false;
                }
            }

        }
    }

}
