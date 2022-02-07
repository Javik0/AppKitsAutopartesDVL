using Modelos;
using Modelos.Quote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escenarios
{
    public class DatosInicales : Escenario, IEscenario
    {
        public Dictionary<ListaTipo, IEnumerable<IDBEntity>> Carga()
        {
            //Clientes
            Cliente clienteUno = new Cliente()
            {
                Nombre = "Alejandro Magno",
                Ciudad = "Roma",
                Correo = "amagno@imperio.com",
                Telefono = "098716584"
            };
            Cliente clienteDos = new Cliente()
            {
                Nombre = "Julio Cesar",
                Ciudad = "Roma",
                Correo = "jcesar@imperio.com",
                Telefono = "098716584"
            };
            Cliente clienteTres = new Cliente()
            {
                Nombre = "Simon Bolivar",
                Ciudad = "Bogota",
                Correo = "sbolivar@grancolombia.com",
                Telefono = "098716584"
            };
            List<Cliente> listaClientes = new() { clienteUno, clienteDos, clienteTres };
            datos.Add(ListaTipo.Clientes, listaClientes);

            //Estados
            Estado estadoAceptado = new Estado()
            {
                EstadoValor = "Aceptado"
            };
            Estado estadoPendiente = new Estado()
            {
                EstadoValor = "Pendiente"
            };
            Estado estadoRechazado = new Estado()
            {
                EstadoValor = "Rechazado"
            };
            List<Estado> listaEstados = new() { estadoAceptado, estadoPendiente, estadoRechazado };
            datos.Add(ListaTipo.Estados, listaEstados);

            //Partes
            Parte parteFUno = new Parte()
            {
                Nombre = "Frenos Brembo",
                Stock = 25,
            };
            Parte parteFDos = new Parte()
            {
                Nombre = "Frenos Tektro",
                Stock = 10,
            };
            Parte parteFTres = new Parte()
            {
                Nombre = "Frenos BBB",
                Stock = 50,

            };
            Parte parteAUno = new Parte()
            {
                Nombre = "Amortiguadores Monroe",
                Stock = 17,
            };
            Parte parteADos = new Parte()
            {
                Nombre = "Amortiguadores Fox",
                Stock = 13,
            };
            Parte parteATres = new Parte()
            {
                Nombre = "Amortiguadores BBB",
                Stock = 50,
            };
            Parte parteLUno = new Parte()
            {
                Nombre = "Llantas Michellin",
                Stock = 9,
            };
            Parte parteLDos = new Parte()
            {
                Nombre = "Llantas Toyo",
                Stock = 89,
            };
            Parte parteLTres = new Parte()
            {
                Nombre = "Llantas GeneralTires",
                Stock = 49,
            };
            List<Parte> partes = new()
            {
                parteFUno,
                parteFDos,
                parteFTres,
                parteAUno,
                parteADos,
                parteATres,
                parteLUno,
                parteLDos,
                parteLTres
            };
            datos.Add(ListaTipo.Partes, partes);
            //PartesAlt
            AltParte altParteFUno01 = new AltParte()
            {
                Parte = parteFUno,
                ParteAlterna = parteFDos
            };
            AltParte altParteFUno02 = new AltParte()
            {
                Parte = parteFUno,
                ParteAlterna = parteFTres
            };
            List<AltParte> PartesAlternasFUno = new() { altParteFUno01, altParteFUno02 };
            parteFUno.altPartes = PartesAlternasFUno;

            AltParte altParteFDos01 = new AltParte()
            {
                Parte = parteFDos,
                ParteAlterna = parteFUno
            };
            AltParte altParteFDos02 = new AltParte()
            {
                Parte = parteFDos,
                ParteAlterna = parteFTres
            };
            List<AltParte> PartesAlternasFDos = new() { altParteFDos01, altParteFDos02 };
            parteFDos.altPartes = PartesAlternasFDos;

            AltParte altParteFTres01 = new AltParte()
            {
                Parte = parteFTres,
                ParteAlterna = parteFUno
            };
            AltParte altParteFTres02 = new AltParte()
            {
                Parte = parteFTres,
                ParteAlterna = parteFDos
            };
            List<AltParte> PartesAlternasFTres = new() { altParteFTres01, altParteFTres02 };
            parteFTres.altPartes = PartesAlternasFTres;


            AltParte altParteAUno01 = new AltParte()
            {
                Parte = parteAUno,
                ParteAlterna = parteADos
            };
            AltParte altParteAUno02 = new AltParte()
            {
                Parte = parteAUno,
                ParteAlterna = parteATres
            };
            List<AltParte> PartesAlternasAUno = new() { altParteAUno01, altParteAUno02 };
            parteAUno.altPartes = PartesAlternasAUno;

            AltParte altParteADos01 = new AltParte()
            {
                Parte = parteADos,
                ParteAlterna = parteAUno
            };
            AltParte altParteADos02 = new AltParte()
            {
                Parte = parteADos,
                ParteAlterna = parteATres
            };
            List<AltParte> PartesAlternasADos = new() { altParteADos01, altParteADos02 };
            parteADos.altPartes = PartesAlternasADos;

            AltParte altParteATres01 = new AltParte()
            {
                Parte = parteATres,
                ParteAlterna = parteAUno
            };
            AltParte altParteATres02 = new AltParte()
            {
                Parte = parteATres,
                ParteAlterna = parteADos
            };
            List<AltParte> PartesAlternasATres = new() { altParteATres01, altParteATres02 };
            parteATres.altPartes = PartesAlternasATres;


            AltParte altParteLUno01 = new AltParte()
            {
                Parte = parteLUno,
                ParteAlterna = parteLDos
            };
            AltParte altParteLUno02 = new AltParte()
            {
                Parte = parteLUno,
                ParteAlterna = parteLTres
            };
            List<AltParte> PartesAlternasLUno = new() { altParteLUno01, altParteLUno02 };
            parteLUno.altPartes = PartesAlternasLUno;

            AltParte altParteLDos01 = new AltParte()
            {
                Parte = parteLDos,
                ParteAlterna = parteLUno
            };
            AltParte altParteLDos02 = new AltParte()
            {
                Parte = parteLDos,
                ParteAlterna = parteLTres
            };
            List<AltParte> PartesAlternasLDos = new() { altParteLDos01, altParteLDos02 };
            parteLDos.altPartes = PartesAlternasLDos;

            AltParte altParteLTres01 = new AltParte()
            {
                Parte = parteLTres,
                ParteAlterna = parteLUno
            };
            AltParte altParteLTres02 = new AltParte()
            {
                Parte = parteLTres,
                ParteAlterna = parteLDos
            };
            List<AltParte> PartesAlternasLTres = new() { altParteLTres01, altParteLTres02 };
            parteLTres.altPartes = PartesAlternasLTres;

            List<AltParte> altPartes = new()
            {
                altParteFUno01,
                altParteFUno02,
                altParteFDos01,
                altParteFDos02,
                altParteFTres01,
                altParteFTres02,
                altParteAUno01,
                altParteAUno02,
                altParteADos01,
                altParteADos02,
                altParteATres01,
                altParteATres02,
                altParteLUno01,
                altParteLUno02,
                altParteLDos01,
                altParteLDos02,
                altParteLTres01,
                altParteLTres02,
            };
            datos.Add(ListaTipo.AltPartes, altPartes);

            //Kits
            Kit kitUno = new Kit()
            {
                Nombre = "Kit Frenos - Amortiguadores",
            };
            Kit kitDos = new Kit()
            {
                Nombre = "Kit Frenos - Llantas",
            };
            Kit kitTres = new Kit()
            {
                Nombre = "Kit Amortiguadores - Llantas",
            };
            List<Kit> kits = new() { kitUno, kitDos, kitTres };
            datos.Add(ListaTipo.Kits, kits);
            //KitParts
            KitPart kitUnoParte01 = new KitPart()
            {
                Kit = kitUno,
                Parte = parteFUno,
                Cantidad = 10

            };
            KitPart kitUnoParte02 = new KitPart()
            {
                Kit = kitUno,
                Parte = parteADos,
                Cantidad = 10
            };
            List<KitPart> kitUnoPartes = new() { kitUnoParte01, kitUnoParte02 };
            kitUno.KitParts = kitUnoPartes;

            KitPart kitDosParte01 = new KitPart()
            {
                Kit = kitDos,
                Parte = parteFUno,
                Cantidad = 10
            };
            KitPart kitDosParte02 = new KitPart()
            {
                Kit = kitDos,
                Parte = parteLTres,
                Cantidad = 10
            };
            List<KitPart> kitDosPartes = new() { kitDosParte01, kitDosParte02 };
            kitDos.KitParts = kitDosPartes;

            KitPart kitTresParte01 = new KitPart()
            {
                Kit = kitTres,
                Parte = parteATres,
                Cantidad = 10
            };
            KitPart kitTresParte02 = new KitPart()
            {
                Kit = kitTres,
                Parte = parteLUno,
                Cantidad = 10
            };
            List<KitPart> kitTresPartes = new() { kitTresParte01, kitTresParte02 };
            kitTres.KitParts = kitTresPartes;
            List<KitPart> kitParts = new() { kitUnoParte01, kitUnoParte02, kitDosParte01, kitDosParte02, kitTresParte01, kitTresParte02 };
            datos.Add(ListaTipo.Kitparts, kitParts);
            //Quotes

            Quote quoteUno = new Quote()
            {
                Cliente = clienteUno,
                Fecha = new DateTime(2021, 07, 15),
                Estado = estadoPendiente,
                kit = kitUno,
            };
            Quote quoteDos = new Quote()
            {
                Cliente = clienteDos,
                Fecha = new DateTime(2021, 06, 12),
                Estado = estadoPendiente,
                kit = kitDos,
            };
            Quote quoteTres = new Quote()
            {
                Cliente = clienteTres,
                Fecha = new DateTime(2020, 02, 14),
                Estado = estadoPendiente,
                kit = kitTres,
            };
            Quote quoteCuatro = new Quote()
            {
                Cliente = clienteTres,
                Fecha = new DateTime(2020, 02, 14),
                Estado = estadoPendiente,
                kit = kitDos
            };
            Quote quoteCinco = new Quote()
            {
                Cliente = clienteTres,
                Fecha = new DateTime(2020, 02, 14),
                Estado = estadoAceptado,
                kit = kitDos
            };
            Quote quoteSeis = new Quote()
            {
                Cliente = clienteTres,
                Fecha = new DateTime(2020, 02, 14),
                Estado = estadoRechazado,
                kit = kitDos
            };
            Quote quoteSiete = new Quote()
            {
                Cliente = clienteTres,
                Fecha = new DateTime(2020, 02, 14),
                Estado = estadoPendiente,
                kit = kitDos
            };
            List<Quote> quotes = new() { quoteUno, quoteDos, quoteTres, quoteCuatro,quoteCinco,quoteSeis,quoteSiete };
            datos.Add(ListaTipo.Quotes, quotes);
            //QuoteParts
            QuotePart quoteUnoPart01 = new QuotePart()
            {
                Quote = quoteUno,
                Parte = parteFUno,
                Cantidad = 50,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            QuotePart quoteUnoPart02 = new QuotePart()
            {
                Quote = quoteUno,
                Parte = parteAUno,
                Cantidad = 50,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            QuotePart quoteUnoPart03 = new QuotePart()
            {
                Quote = quoteUno,
                Parte = parteLUno,
                Cantidad = 50,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            List<QuotePart> quotePartsUno = new() { quoteUnoPart01, quoteUnoPart02, quoteUnoPart03 };
            quoteUno.QuoteParts = quotePartsUno;

            QuotePart quoteDosPart01 = new QuotePart()
            {
                Quote = quoteDos,
                Parte = parteFDos,
                Cantidad = 50,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            QuotePart quoteDosPart02 = new QuotePart()
            {
                Quote = quoteDos,
                Parte = parteADos,
                Cantidad = 50,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            QuotePart quoteDosPart03 = new QuotePart()
            {
                Quote = quoteDos,
                Parte = parteLDos,
                Cantidad = 50,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            List<QuotePart> quotePartsDos = new() { quoteDosPart01, quoteDosPart02, quoteDosPart03 };
            quoteDos.QuoteParts = quotePartsDos;

            QuotePart quoteTresPart01 = new QuotePart()
            {
                Quote = quoteTres,
                Parte = parteFTres,
                Cantidad = 50,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            QuotePart quoteTresPart02 = new QuotePart()
            {
                Quote = quoteTres,
                Parte = parteATres,
                Cantidad = 50,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            QuotePart quoteTresPart03 = new QuotePart()
            {
                Quote = quoteTres,
                Parte = parteLTres,
                Cantidad = 50,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            List<QuotePart> quotePartsTres = new() { quoteTresPart01, quoteTresPart02, quoteTresPart03 };
            quoteTres.QuoteParts = quotePartsTres;

            QuotePart quoteSietePart01 = new QuotePart()
            {
                Quote = quoteSiete,
                Parte = parteFDos,
                Cantidad = 50,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            QuotePart quoteSietePart02 = new QuotePart()
            {
                Quote = quoteSiete,
                Parte = parteADos,
                Cantidad = 100,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            QuotePart quoteSietePart03 = new QuotePart()
            {
                Quote = quoteSiete,
                Parte = parteLDos,
                Cantidad = 50,
                Stock = false,
                AltParteStock = null,
                AltParte = null,

            };
            List<QuotePart> quotePartsSiete = new() { quoteSietePart01, quoteSietePart02, quoteSietePart03 };
            quoteSiete.QuoteParts = quotePartsSiete;

            List<QuotePart> quoteParts = new()
            {
                quoteUnoPart01,
                quoteUnoPart02,
                quoteUnoPart03,
                quoteDosPart01,
                quoteDosPart02,
                quoteDosPart03,
                quoteTresPart01,
                quoteTresPart02,
                quoteTresPart03,
                quoteSietePart01,
                quoteSietePart02,
                quoteSietePart03
            };
              datos.Add(ListaTipo.QuoteParts, quoteParts);
              return datos; 

       /*     Dictionary<string, object> dicListaDatos = new Dictionary<string, object>()
            {
                { "Lista de clientes", listaClientes},
                  { "Lista de estados", listaEstados},  
            };
            var x = dicListaDatos["lista de clientes"];

            db.*/
        }
    }
}
