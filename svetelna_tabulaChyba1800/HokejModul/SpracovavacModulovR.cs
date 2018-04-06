using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using svetelna_tabula;
using System.IO;
using Rozhranie;
using System.Reflection;

namespace HokejModul
{
    class SpracovavacModulov
    {
        public static IEnumerable<Reklama> NacitajModuly(string cesta)
        {
            var vsetkyKniznice = Directory.GetFiles(cesta, "*.dll");
            var iModulType = typeof(Reklama);

            var result = new List<Reklama>();
            foreach (var dll in vsetkyKniznice)
            {
                var assembly = Assembly.LoadFrom(dll);
                result.AddRange(assembly.GetTypes()
                    .Where(t => iModulType.IsAssignableFrom(t))
                    .Select(t =>
                    {
                        try
                        {
                            return Activator.CreateInstance(t) as Reklama;
                        }
                        catch (Exception )
                        {
                            return null;
                        }
                    })
                .Where(m => m != null));
            }

            return result;
        }
    }
}
