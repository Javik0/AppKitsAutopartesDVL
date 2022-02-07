using Modelos.Quote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class KitInfo
    {
        public static void mostrarKit(Kit kit)
        {
            Console.WriteLine("-------------- Kit --------------");
            string msg =String.Format("ID: {0}  Nombre: {1}",  kit.KitId, kit.Nombre);
            Console.WriteLine(msg);
            mostrarKitParts(kit.KitParts);
            Console.WriteLine("\n\n");
        }

        public static void mostrarKitParts(List<KitPart> kitParts)
        {
            foreach(var kitpart in kitParts)
            {
                Console.WriteLine("-------------- KitPart --------------");
                ParteInfo.mostrarParte(kitpart.Parte);
                Console.WriteLine("Cantidad en kit: " + kitpart.Cantidad);
            }
        }

        public static void mostrarKits(List<Kit> kits)
        {
            foreach(var kit in kits)
            {
                mostrarKit(kit);
            }
        }
    }
}
