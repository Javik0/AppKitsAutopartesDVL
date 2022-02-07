using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Quote
{
    public class KitPart :IDBEntity
    {  
        public int Cantidad { get; set; }

        //relacion con kit
        public int KitId { get; set; }
        public Kit Kit { get; set; }

        //relacion con partes
        public int ParteId { get; set; }
        public Parte Parte { get; set; }
    }
}
