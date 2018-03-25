using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Rozhranie;
using System.Reflection;

namespace FudbalModul
{
    class SpracovavacModulov
    {
        public static IEnumerable<reklama> NacitajModuly(string cesta)
        {
            var vsetkyKniznice = Directory.GetFiles(cesta, "*.dll");
            var iModulType = typeof(reklama);

            var result = new List<reklama>();
            foreach (var dll in vsetkyKniznice)
            {
                var assembly = Assembly.LoadFrom(dll);
                result.AddRange(assembly.GetTypes()
                    .Where(t => iModulType.IsAssignableFrom(t))
                    .Select(t =>
                    {
                        try
                        {
                            return Activator.CreateInstance(t) as reklama;
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
