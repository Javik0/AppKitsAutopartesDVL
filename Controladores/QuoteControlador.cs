using Modelos.Quote;
using Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Controladores
{
    public class QuoteControlador
    {
        private static QuotePartsControlador quotePartsControlador = new QuotePartsControlador();

        public static string ProcesarQuote(int quoteID)
        {
            string respuesta = " ";
            using (var db = new QuoteDB())
            {
                var EstadoAceptado = db.estados.Where(estado => estado.EstadoValor == "Aceptado").Single();
                var EstadoRechazado = db.estados.Where(estado => estado.EstadoValor == "Rechazado").Single();
                var EstadoPendiente = db.estados.Where(estado => estado.EstadoValor == "Pendiente").Single();
                var quote = db.quotes
                    .Include(quote => quote.Cliente)
                    .Include(quote => quote.Estado)
                    .Include(quote => quote.QuoteParts)
                        .ThenInclude(qParts => qParts.Parte)
                    .Where(quote => quote.QuoteId == quoteID)
                    .Single();

                if (quote.Estado == EstadoPendiente)
                {
                    quote.QuoteParts = quotePartsControlador.procesarPartes(quote.QuoteParts);
                    bool validacion = validarQuote(quote.QuoteParts);

                    if (validacion)
                    {
                        quote.Estado = EstadoAceptado;
                        respuesta = "La quote fue aceptada";
                    }
                    else
                    {
                        quote.Estado = EstadoRechazado;
                        respuesta = "La quote fue rechazada";
                    }
                }
                else if (quote.Estado == EstadoAceptado)
                {
                    respuesta = "La Quote ya tiene estado de Aceptado";
                }
                else
                {
                    respuesta = "Esta Quote tiene estado de rechazado";
                }

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    Exception ex = new Exception("Conficto de concurrencia", exception);
                    throw ex;
                }
            }

            return respuesta;

        }

        public static bool validarQuote(List<QuotePart> quoteParts)
        {
            bool valido = true;

            foreach (var parte in quoteParts)
            {
                if (parte.Stock)
                {
                    continue;
                }
                else
                {
                    if (parte.AltParteStock.HasValue && parte.AltParteStock == true)
                    {
                        continue;
                    }
                    else
                    {
                        valido = false;
                        break;
                    }
                }
            }

            return valido;
        }

        public static void procesarQuoteconKit(int quoteID)
        {
            using (var db = new QuoteDB())
            {
                var quote = db.quotes
                    .Include(quote => quote.Cliente)
                    .Include(quote => quote.kit)
                        .ThenInclude(qKit => qKit.KitParts)
                        .ThenInclude(qKitParts => qKitParts.Parte)
                    .Where(quote => quote.QuoteId == quoteID)
                    .Single();

                List<QuotePart> quoteParts = new();

                foreach (var kpart in quote.kit.KitParts)
                {
                    var qPart = quotePartsControlador.crearQuotePart(quote, kpart.Parte, kpart.Cantidad);
                    quoteParts.Add(qPart);
                }
                quote.QuoteParts = quoteParts;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    Exception ex = new Exception("Conficto de concurrencia", exception);
                    throw ex;
                }
                ProcesarQuote(quoteID);
            }
        }
    }
}
