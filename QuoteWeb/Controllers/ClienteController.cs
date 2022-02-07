using Microsoft.AspNetCore.Mvc;
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
    public class ClienteController : Controller
    {
        private readonly QuoteDB db;

        public ClienteController(QuoteDB db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Cliente> ListaClientes = db.clientes;
            return View(ListaClientes);
        }


        // POST
        //  Guarda un nuevo cliente

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            db.clientes.Add(cliente);
            db.SaveChanges();

            TempData["mensaje"] = $"el cliente {cliente.Nombre} se ha creado correctamente";

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
