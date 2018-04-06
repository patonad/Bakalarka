using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rozhranie;
namespace ReklamnyModul
{
    public class ReklamnyModul : Reklama
    {
        public void Prezentuj()
        {
            Ovladac z = new Ovladac();
            z.ShowDialog();
        }
    }
}
