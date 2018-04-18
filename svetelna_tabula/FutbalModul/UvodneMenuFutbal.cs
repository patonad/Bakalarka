using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using svetelna_tabula;
namespace FutbalModul
{
    
    public partial class UvodneMenuFutbal : Form
    {
        private Databaza dat;
        private RiadiaceOknoFutbal okno;
        public UvodneMenuFutbal()
        {
            InitializeComponent();
            dat = new Databaza();
            dat.Pripoj();
        }

        private void LStartFutbal_Click(object sender, EventArgs e)
        {
            bool je = false;
            int idZapasu = 0;
            int hos = dat.ZistiCiJeTim(tBHostia.Text, "Futbal");
            if (hos == 0)
            {
                MessageBox.Show("Tím " + tBHostia.Text + " nebol nájdený.");
            }
            else
            {
                je = true;
            }
            int dom = dat.ZistiCiJeTim(tBDomaci.Text, "Futbal");
            if (dom == 0)
            {
                MessageBox.Show("Tím " + tBDomaci.Text + " nebol nájdený.");
            }
            else if (je)
            {
                idZapasu = dat.PridajZapas(hos, dom);
            }

            string hostia, domaci;
            if (tBHostia.Text.Equals(""))
            {
                hostia = "Hostia";
            }
            else
            {
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
            okno = new RiadiaceOknoFutbal(hostia, domaci, this, dat, idZapasu, hos, dom);
            okno.ShowDialog();


        }

        private void LExitFutbal_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void UvodneMenuFutbal_FormClosing(object sender, FormClosingEventArgs e)
        {
            dat.Odpoj();
        }
    }
}
