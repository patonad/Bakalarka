using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReklamnyModul
{
    public partial class Zobrazovac : Form
    {
        public Zobrazovac()
        {

            InitializeComponent();

        }

        private void Zobrazovac_Load(object sender, EventArgs e)
        {
            var primary = Screen.AllScreens.ElementAtOrDefault(0);
            // ako externy sa nastavi pridavny monitor a ak niejej tak sa nastvi primarny
            var extended = Screen.AllScreens.FirstOrDefault(s => s != primary) ?? primary;
            // umiestnenie okna
            this.Left = extended.WorkingArea.Left;
            this.Top = extended.WorkingArea.Top;
            // nasobok v akom pomere treba zvecit original
            float nasobok = (float)extended.WorkingArea.Size.Width / (float)this.Width;
            //zvecenie
            //  Scale(new SizeF(nasobok, nasobok));

            axWindowsMediaPlayer1.Width = (int)(axWindowsMediaPlayer1.Width * nasobok);
            axWindowsMediaPlayer1.Height = (int)(axWindowsMediaPlayer1.Height * nasobok);


        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
        public AxWMPLib.AxWindowsMediaPlayer wMP()
        {
            return axWindowsMediaPlayer1;
        }
    }
}
