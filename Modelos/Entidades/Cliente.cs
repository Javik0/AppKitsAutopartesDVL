using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Quote
{
    public class Cliente : IDBEntity
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }

    }
}
