using Modelos.Quote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class ParteInfo
    {

        public static void mostrarParte(Parte parte)
        {
            Console.WriteLine("-------------- Parte --------------");
            string msg = String.Format("ID: {0} Nombre: {1} Stock: {2}", parte.ParteId, parte.Nombre, parte.Stock);
            Console.WriteLine(msg);
        }

        public static void mostarPartesAlternas(List<AltParte> altPartes)
        {
            Console.WriteLine("-----Partes Alternas-----");
            foreach (var parteAlt in altPartes)
            {
                mostrarParte(parteAlt.ParteAlterna);
            }
        }

        public static void mostrarPartes(List<Parte> partes)
        {
            foreach (var parte in partes)
            {
                mostrarParte(parte);
                mostarPartesAlternas(parte.altPartes);
                Console.WriteLine("\n\n");
            }
        }
    }
}
