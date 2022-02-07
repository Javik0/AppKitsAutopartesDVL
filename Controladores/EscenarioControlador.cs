
using Escenarios;
using Modelos.Quote;
using Persistencia;
using System.Collections.Generic;
using static Escenarios.Escenario;

namespace Controladores
{
    public class EscenarioControlador
    {
        public void Grabar(IEscenario escenario)
        {

            var datos = escenario.Carga();


            using (var db = new QuoteDB())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.clientes.AddRange((List<Cliente>)datos[ListaTipo.Clientes]);
                db.partes.AddRange((List<Parte>)datos[ListaTipo.Partes]);
                db.estados.AddRange((List<Estado>)datos[ListaTipo.Estados]);
                db.altPartes.AddRange((List<AltParte>)datos[ListaTipo.AltPartes]);
                db.kits.AddRange((List<Kit>)datos[ListaTipo.Kits]);
                db.kitParts.AddRange((List<KitPart>)datos[ListaTipo.Kitparts]);
                db.quotes.AddRange((List<Quote>)datos[ListaTipo.Quotes]);
                db.quoteParts.AddRange((List<QuotePart>)datos[ListaTipo.QuoteParts]);
                db.SaveChanges();
            }

        }
    }
}
