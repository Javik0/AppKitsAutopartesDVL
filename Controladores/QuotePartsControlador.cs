using Modelos.Quote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class QuotePartsControlador
    {
        public  List<QuotePart> procesarPartes(List<QuotePart> quoteParts)
        {
            List<QuotePart> quotePartesProcesadas = new();

            foreach(var quoteParte in quoteParts)
            {
                //parte principal
                Parte partePrincipal = quoteParte.Parte;
                int cantidadDeseada = quoteParte.Cantidad;
                if (cantidadDeseada <= partePrincipal.Stock)
                {
                    quoteParte.Stock = true;
                    quotePartesProcesadas.Add(quoteParte);
                    continue;
                }
                else
                {
                   //partes alternas
                   Parte altParte =  AltParteControlador.ProcesarAltPartes(quoteParte.Parte.ParteId, quoteParte.Cantidad);
                   if(!(altParte == null))
                    {
                        quoteParte.AltParte = altParte;
                        quoteParte.AltParteId = altParte.ParteId;
                        quoteParte.AltParteStock = true;
                    }
                }
                quotePartesProcesadas.Add(quoteParte);
            }

            return quotePartesProcesadas;
        }

        public  QuotePart crearQuotePart(Quote quote,Parte parte,int cantidad)
        {
            QuotePart qPart = new()
            {
                Quote = quote,
                Parte = parte,
                Stock = false,
                Cantidad = cantidad
            };

            return qPart;
        }
    }
}
