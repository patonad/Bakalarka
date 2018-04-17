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
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Tik;
            realCasTimer = new System.Timers.Timer();
            realCasTimer.Interval = 1000;
            realCasTimer.Elapsed += KontrolujCas;

            var primary = Screen.AllScreens.ElementAtOrDefault(0);
            var extended = Screen.AllScreens.FirstOrDefault(s => s != primary) ?? primary;
            this.Left = extended.WorkingArea.Left;
            this.Top = extended.WorkingArea.Top;
            float nasobok = (float)extended.WorkingArea.Size.Width / (float)this.Width;
            Scale(new SizeF(nasobok, nasobok));
            Label label;
            foreach (object item in Controls)
            {
                label = (Label)item;
                label.Font = new Font(label.Font.Name, (float)Math.Floor(label.Font.Size * nasobok));
            }
            LbHostia.Text = hostia;
            LBdomaci.Text = domaci;

        }
        private void Tik(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (!(s == 0 && m == 0))
                {
                    if (vylucenyDomaci.Count != 0)
                    {
                        FaulTikDomaci();
                    }
                    else
                    {
                        label9.Visible = false;
                        lbDomPe.Visible = false;
                        label13.Visible = false;

                    }
                    if (vylucenyHostia.Count != 0)
                    {
                        FaulTikHostia();
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
                    s = 0; //kolko trva tretina
                    m = 20;
                    this.StopCasovac();
                    if (tretina == 3)
                    {
                        lGolHrac.Text = "";
                        riadiaceOkno.KoniecHry();
                        s = 0;
                        m = 0;

                    }
                    else
                    {
                        lGolHrac.Text = "";
                        tretina++;
                        lTretinaHokej.Text = "" + tretina;
                        riadiaceOkno.NastavTretina("" + tretina);
                    }

                }

                String aktCas = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                lCasHokej.Text = aktCas;

                riadiaceOkno.NastavCas(aktCas);

            }));
        }
        public void Predlzenie(int cas)
        {
            m = cas;
            predlzenieCas += cas;
            lTretinaHokej.Text = "P";
            riadiaceOkno.NastavTretina("P" + tretina);
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
        public bool Asistencia(string cislo, int id_tim)
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
                    string hrac = dat.ZistiCiJeHrac(id_tim, x);

                    if (hrac != "")
                    {


                        dat.PridajZaznam(idZapasu, id_tim, x, SpracujCas(), "asistencia");
                        dat.UpravAsistencia(id_tim, x);
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
        private string SpracujCas()
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
        public bool IdeCas()
        {
            return casIde;
        }
        public void RealnyCas()
        {
            realCasTimer.Start();
        }
        public void StopRealnyCas()
        {
            realCasTimer.Stop();
        }
        private void KontrolujCas(object sender, ElapsedEventArgs e)
        {
            String cas = DateTime.Now.ToShortTimeString();
            Invoke((MethodInvoker)delegate { lCasHokej.Text = cas; });
        }
        public void HraciCas()
        {
            Invoke((MethodInvoker)delegate { lCasHokej.Text = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0')); ; });
            realCasTimer.Stop();
        }
        public void Gol(string cisloGol, string cisloAsis, int id_tim, string kto)
        {
            if (Asistencia(cisloAsis, id_tim))
            {
                int x = 0;

                if (!Int32.TryParse(cisloGol, out x))
                {
                    MessageBox.Show("Hráč neexzistuje");
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
                    MessageBox.Show("Hráč neexzistuje");
                    return;
                }

            }
        }
        private void PridajFaul(string kto)
        {
            if (kto == "h")
            {
                vylucenyHostia.Insert(0, 120);
            }
            else
            {
                vylucenyDomaci.Insert(0, 120);
            }
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
        public void Faul(string cislo, int id_tim, string kto)
        {

            int x = 0;

            if (!Int32.TryParse(cislo, out x))
            {
                MessageBox.Show("Hráč neexzistuje");
                return;
            }
            StopCasovac();

            string hrac = dat.ZistiCiJeHrac(id_tim, x);

            if (idZapasu == 0)
            {
                PridajFaul(kto);
            }
            else if (hrac != "")
            {
                dat.PridajZaznam(idZapasu, id_tim, x, SpracujCas(), "faul");
                dat.UpravFaul(id_tim, x);
                PridajFaul(kto);
            }
            else
            {
                MessageBox.Show("Hráč neexzistuje");
                return;
            }





        }
        private String SpracujCasFaul(int Cas)
        {
            return string.Format("{0}:{1}", (Cas / 60).ToString().PadLeft(2, '0'), (Cas % 60).ToString().PadLeft(2, '0'));
        }
        private void FaulTikDomaci()
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
                    label9.Text = SpracujCasFaul(cas);
                }
                else
                {
                    label13.Visible = true;
                    label13.Text = SpracujCasFaul(cas);
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
        private void FaulTikHostia()
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
                    label7.Text = SpracujCasFaul(cas);
                }
                else
                {
                    label11.Visible = true;
                    lbHostiaPe.Visible = true;
                    label11.Text = SpracujCasFaul(cas);
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
