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
namespace FudbalModul
{
    
    public partial class UvodneMenuFudbal : Form
    {
        private Databaza dat;
        private RiadiaceOknoFudbal okno;
        public UvodneMenuFudbal()
        {
            InitializeComponent();
            dat = new Databaza();
            dat.pripoj();
        }

        private void lStartFudbal_Click(object sender, EventArgs e)
        {
            bool je = false;
            int idZapasu = 0;
            int hos = dat.zistiCiJaTym(tBHostia.Text, "Fudbal");
            if (hos == 0)
            {
                MessageBox.Show("Tym " + tBHostia.Text + " nebol najdený.");
            }
            else
            {
                je = true;
            }
            int dom = dat.zistiCiJaTym(tBDomaci.Text, "Fudbal");
            if (dom == 0)
            {
                MessageBox.Show("Tym " + tBDomaci.Text + " nebol najdený.");
            }
            else if (je)
            {
                idZapasu = dat.pridajZapas(hos, dom);
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
            okno = new RiadiaceOknoFudbal(hostia, domaci, this, dat, idZapasu, hos, dom);
            okno.ShowDialog();


        }

        private void lExitFudbal_Click(object sender, EventArgs e)
        {
            dat.odpoj();
            this.Close();
        }

       }
}
