using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Quote
{
    public class QuotePart : IDBEntity
    {
        public int QuotePartId { get; set; }
        public int Cantidad { get; set; }
        public bool Stock { get; set; }
        public bool? AltParteStock { get; set; }

        //Relacion con quote
        public int QuoteId { get; set; }
        public Quote Quote { get; set; }

        //relacion con parte
        public int ParteId { get; set; }
        public Parte Parte { get; set; }

        //relacion con parte alterna
        public int? AltParteId { get; set; }
#nullable enable
        public Parte? AltParte { get; set; }


    }
}
