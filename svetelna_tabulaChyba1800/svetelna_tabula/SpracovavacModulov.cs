using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rozhranie;
using System.IO;
using System.Reflection;

namespace svetelna_tabula
{
    class SpracovavacModulov
    {
        public static IEnumerable<IModul> NacitajModuly(string cesta)
        {
            var vsetkyKniznice = Directory.GetFiles(cesta, "*.dll");
            var iModulType = typeof(IModul);

            var result = new List<IModul>();
            foreach (var dll in vsetkyKniznice)
            {
                var assembly = Assembly.LoadFrom(dll);
                result.AddRange(assembly.GetTypes()
                    .Where(t => iModulType.IsAssignableFrom(t))
                    .Select(t =>
                    {
                        try
                        {
                            return Activator.CreateInstance(t) as IModul;
                        }
                        catch (Exception)
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