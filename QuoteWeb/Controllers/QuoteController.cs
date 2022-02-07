using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Modelos.Quote;
using Persistencia;
using QuoteWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteWeb.Controllers
{
    public class QuoteController : Controller
    {
        private readonly QuoteDB db;

        public QuoteController(QuoteDB db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Quote> ListaQuote =
             db.quotes
            .Include(quote => quote.Cliente)
            .Include(quote => quote.Estado)
            .Include(quote => quote.kit);
          /*  .Include(quote => quote.Cliente)
            .Include(quote => quote.kit)
            .ThenInclude(qKit => qKit.KitParts)
            .ThenInclude(qKitParts => qKitParts.Parte);
        */
            return View(ListaQuote);
        }


        // POST
        //  Guarda un nuevo cliente

        [HttpGet]
        public IActionResult Create()
        {
            //lista de clientes
            var listaClientes = db.clientes
                .Select(cliente => new
                {
                    ClienteId = cliente.ClienteId,
                    Nombre = cliente.Nombre
                }).ToList();

            //lista de kits
            var kits = db.kits
                .Select(kit => new
                {
                    KitId = kit.KitId,
                    Nombre = kit.Nombre
                }).ToList();

            //lista de estados
            var listaEstados = db.estados
                .Select(estado => new
                {
                    EstadoId = estado.EstadoId,
                    EstadoValor = estado.EstadoValor
                }).ToList();

            //preparas las listas
            var selectListasClientes = new SelectList(listaClientes, "ClienteId", "Nombre");
            var selectListasKit = new SelectList(kits, "KitId", "Nombre");
            var selectListasEstados = new SelectList(listaEstados, "EstadoId", "EstadoValor");

            ViewBag.selectListasClientes = selectListasClientes;
            ViewBag.selectListasKit = selectListasKit;
            ViewBag.selectListasEstados = selectListasEstados;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Quote quote)
        {
            db.quotes.Add(quote);
            db.SaveChanges();

            TempData["mensaje"] = $"la proforma {quote.QuoteId} se ha creado correctamente";

            return RedirectToAction("Index");
        }

        // Presenta el formulario con la identidad seleccionada para actualizar
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Cliente cliente = db.clientes.Find(id);

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            db.clientes.Update(cliente);
            db.SaveChanges();

            TempData["mensaje"] = $"La materia {cliente.Nombre} se ha actualizado correctamente";

            return RedirectToAction("Index");
        }


        // Presenta el formulario con la identidad seleccionada para borrar
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Cliente cliente = db.clientes.Find(id);

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Delete(Cliente cliente)
        {
            db.clientes.Remove(cliente);
            db.SaveChanges();

            TempData["mensaje"] = $"El cliente {cliente.Nombre} se ha borrado correctamente";

            return RedirectToAction("Index");
        }


    }
}
