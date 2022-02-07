using Modelos.Quote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    public class QuoteInfo
    {
        public static void mostrarQuote(Quote quote)
        {
            Console.WriteLine("-------------- Quote --------------");
            string msg = String.Format("ID: {0} -- Fecha: {1} -- Estado: {2}", quote.QuoteId,quote.Fecha,quote.Estado.EstadoValor);
            Console.WriteLine(msg);
            ClienteInfo.mostrarCliente(quote.Cliente);
            mostrarQuoteInfos(quote.QuoteParts);
            Console.WriteLine("\n\n");
        }

        public static void mostrarQuoteInfos(List<QuotePart> quoteParts)
        {
            Console.WriteLine("-------------- Detalles Quote --------------");
            foreach(var quotePart in quoteParts)
            {
                mostrarQuoteInfo(quotePart);
            }
        }

        public static void mostrarQuoteInfo(QuotePart quotePart)
        {
            string msg = String.Format("ID: {0} -- ParteID: {1} -- Cantidad: {2} -- Stock: {3} -- Alt Stock: {4} -- Parte Alterna ID: {5} ",
                    quotePart.QuotePartId,
                    quotePart.ParteId,
                    quotePart.Cantidad,
                    quotePart.Stock,
                    quotePart.AltParteStock.HasValue? quotePart.AltParteStock : "----",
                    quotePart.AltParteStock.HasValue ? quotePart.AltParte.ParteId : "-----"
                );
            Console.WriteLine(msg);

        }

        public static void mostrarQuotes(List<Quote> quotes)
        {
            foreach(var quote in quotes)
            {
                mostrarQuote(quote);
            }
        }


    }
}
