using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace svetelna_tabula
{
    public partial class ZobrazovacStat : Form
    {
        float nasobok;
        public ZobrazovacStat()
        {
            InitializeComponent();           
        }
        public void vloz(List<List<string>> zaznam, string kto)
        {
            InitializeComponent();
            int kolkoy = zaznam.Count;
            int kolkox;
            Label label;
            for (int y = 0; y < kolkoy; y++)
            {
                kolkox = zaznam[y].Count;
                for (int x = 0; x < kolkox; x++)
                {
                    label = new Label();
                    label.BackColor = Color.Transparent;
                    label.Location = new System.Drawing.Point(40 + (((this.Width - 80) / kolkox) * x), 100 + (((this.Height - 100) / kolkoy) * y));
                    label.Size = new System.Drawing.Size(((this.Width - 80) / kolkox) - 5, ((this.Height - 100) / kolkoy) - 5);
                    label.Text = zaznam[y][x];
                    label.ForeColor = Color.SandyBrown;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.AutoSize = false;
                    label.Visible = true;
                    if (y == 0)
                    {
                        label.Font = new Font("Arial", 9, FontStyle.Bold);
                    }
                    Controls.Add(label);


                }

            }
            lKto.Text = kto;
            lKto.Refresh();
            lKto.BringToFront();           
        }

        private void ZobrazovacStat_Load(object sender, EventArgs e)
            
        {
            lKto.Text = lKto.Text;
            var primary = Screen.AllScreens.ElementAtOrDefault(0);
            // ako externy sa nastavi pridavny monitor a ak niejej tak sa nastvi primarny
            var extended = Screen.AllScreens.FirstOrDefault(s => s != primary) ?? primary;
            // umiestnenie okna
            this.Left = extended.WorkingArea.Left;
            this.Top = extended.WorkingArea.Top;
            // nasobok v akom pomere treba zvecit original
            nasobok = (float)extended.WorkingArea.Size.Width / (float)this.Width;
            Scale(new SizeF(nasobok, nasobok));
            Label label;
            foreach (object item in Controls)
            {
                label = (Label)item;
                label.Font = new Font(label.Font.Name, (float)Math.Floor(label.Font.Size * nasobok));

            }
        } 
        

        
    }
}
