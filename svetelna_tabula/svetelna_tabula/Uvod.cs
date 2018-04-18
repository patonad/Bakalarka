using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Rozhranie;

namespace svetelna_tabula
{
    public partial class Uvod : Form
    {
        public Uvod()
        {
            InitializeComponent ();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var priecinokPluginov = Path.Combine(new DirectoryInfo(".").FullName, "pluginy");
            var moduly = SpracovavacModulov.NacitajModuly(priecinokPluginov);
            foreach (IModul modul in moduly)
            {
                var button = new Button
                {
                    Tag = modul,
                    Image = modul.DajIconu(),
                    Width = 60,
                    Height = 60
                };
                button.Click += ButtonOnClick;

                fLPUvodneMenu.Controls.Add(button);
            }
        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            var modul = (IModul)button.Tag;
            modul.Spusti();
        }

       
    }
}
