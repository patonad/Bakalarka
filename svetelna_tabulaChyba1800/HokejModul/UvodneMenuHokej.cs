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
            dat.pripoj();
        }
        /// <summary>
        /// Metoda ktora sa zavola po kliknuti na Start a vytvori riadiace okno pre hokej
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lStartHokej_Click(object sender, EventArgs e)
        {
            bool je = false;
            int idZapasu = 0;
            int hos = dat.zistiCiJaTym(tBHostia.Text, "Hokej");
            if ( hos == 0)
            {
                MessageBox.Show("Tym1 " + tBHostia.Text + " nebol najdený.");
            }
            else {
                je = true;
            }
            int dom = dat.zistiCiJaTym(tBDomaci.Text, "Hokej");
            if (dom == 0)
            {
                MessageBox.Show("Tym1 " + tBDomaci.Text + " nebol najdený.");
            }else if(je){
                idZapasu = dat.pridajZapas(hos, dom);
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
        private void lExitHokej_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
