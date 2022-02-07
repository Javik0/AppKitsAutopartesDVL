using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Quote
{
    public class Kit : IDBEntity
    {
        public int KitId { get; set; }
        public string Nombre { get; set; }
        public List<KitPart> KitParts { get; set; }
    }
}
