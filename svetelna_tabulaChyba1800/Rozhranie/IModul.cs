using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozhranie
{
    public interface IModul
    {
        void Spusti();
        Image dajIconu();
    }
}
