using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Quote
{
    public class Estado : IDBEntity
    {
        public int EstadoId { get; set; }
        public string EstadoValor { get; set; }
    }
}
