using Rozhranie;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace FudbalModul
{
    public class FudbalModul : IModul
    {
        

        public void Spusti()
        {
            UvodneMenuFudbal f = new UvodneMenuFudbal();
            f.ShowDialog();
        }

        Image IModul.dajIconu()
        {
            return Image.FromFile((".\\pluginy\\iconaFudbal.png"));
        }
    }
}
