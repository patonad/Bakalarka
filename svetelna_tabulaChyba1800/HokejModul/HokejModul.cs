using System;
using System.Drawing;
using System.Net.Mime;
using Rozhranie;

namespace HokejModul
{
    public class HokejModul : IModul
    {
        public Image DajIconu()
        {
            return Image.FromFile((".\\pluginy\\iconaHokej.png"));
           
        }

        public void Spusti()
        {
            UvodneMenuHokej menu = new UvodneMenuHokej();
            menu.ShowDialog();
        }

        
    }
}
