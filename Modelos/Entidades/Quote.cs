using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Quote
{
   // public enum EstadoQuote { Aceptado, Pendiente, Rechazado}
    public class Quote :  IDBEntity
    {
        public int QuoteId { get; set; }
        public DateTime Fecha { get; set; }


        //relacion con cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        //relacion con partes de proforma
        public List<QuotePart> QuoteParts { get; set; }

        //relacion con estado
        public int EstadoId { get; set; }
        public Estado Estado { get; set; } //Aceptado, Pendiente, Rechazado

        //relacion con kit
        public int? KitId { get; set; }
//#nullable enable
        public Kit kit { get; set; }
    }
}
