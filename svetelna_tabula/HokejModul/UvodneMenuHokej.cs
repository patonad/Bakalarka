using svetelna_tabula;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HokejModul
{
    public partial class UvodneMenuHokej : Form
    {
        private Databaza dat;
        private RiadiaceOknoHokej okno;
        public UvodneMenuHokej()
        {
            InitializeComponent();
            dat = new Databaza();
            dat.Pripoj();
        }
        /// <summary>
        /// Metoda ktora sa zavola po kliknuti na Start a vytvori riadiace okno pre hokej
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LStartHokej_Click(object sender, EventArgs e)
        {
            bool je = false;
            int idZapasu = 0;
            int hos = dat.ZistiCiJeTim(tBHostia.Text, "Hokej");
            if ( hos == 0)
            {
                MessageBox.Show("Tím " + tBHostia.Text + " nebol nájdený.");
            }
            else {
                je = true;
            }
            int dom = dat.ZistiCiJeTim(tBDomaci.Text, "Hokej");
            if (dom == 0)
            {
                MessageBox.Show("Tím " + tBDomaci.Text + " nebol nájdený.");
            }else if(je){
                idZapasu = dat.PridajZapas(hos, dom);
            }

            string hostia, domaci;
            if (tBHostia.Text.Equals(""))
            {
                hostia = "Hostia";
            }
            else {
                hostia = tBHostia.Text;
            }
            if (tBDomaci.Text.Equals(""))
            {
                domaci = "Domáci";
            }
            else
            {
                domaci = tBDomaci.Text;
            }
            this.Visible = false;
            okno = new RiadiaceOknoHokej(hostia, domaci, this, dat, idZapasu, hos, dom);
            okno.ShowDialog();
            

        }
        /// <summary>
        /// Metoda ktora ukonci hokej
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LExitHokej_Click(object sender, EventArgs e)
        {
           
            this.Close();

        }

        private void UvodneMenuHokej_FormClosing(object sender, FormClosingEventArgs e)
        {
            dat.Odpoj();
        }
    }
}
