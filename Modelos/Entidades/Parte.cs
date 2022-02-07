using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Quote
{
    public class Parte : IDBEntity
    {
        public int ParteId { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }

        //relacion de uno a muchos con partes alternas(AltPartes)
        public List<AltParte> altPartes { get; set; }
    }
}
