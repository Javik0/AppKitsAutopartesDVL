using System;
using System.Collections.Generic;
using Modelos;
using System.Text;

namespace Escenarios
{
    public class Escenario
    {
        public enum ListaTipo
        {
            AltPartes,
            Clientes,
            Estados,
            Kits,
            Kitparts,
            Partes,
            Quotes,
            QuoteParts
        }

        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> datos;

        public Escenario()
        {
            datos = new();
        }
        
    }
}
