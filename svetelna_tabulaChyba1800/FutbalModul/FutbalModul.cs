using Rozhranie;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace FudbalModul
{
    public class FutbalModul : IModul
    {
        

        public void Spusti()
        {
            UvodneMenuFutbal f = new UvodneMenuFutbal();
            f.ShowDialog();
        }

        Image IModul.DajIconu()
        {
            return Image.FromFile((".\\pluginy\\iconaFudbal.png"));
        }
    }
}
