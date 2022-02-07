using Microsoft.AspNetCore.Mvc;
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
    public class AltParteController : Controller
    {
        private readonly QuoteDB db;

        public AltParteController(QuoteDB db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<AltParte> ListaAltParte = db.altPartes
                 .Include(altparte => altparte.Parte);
            
            return View(ListaAltParte);
        }


        // POST
        //  Guarda un nuevo cliente

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AltParte altparte)
        {
            db.altPartes.Add(altparte);
            db.SaveChanges();

            TempData["mensaje"] = $"la parte aletrna {altparte.ParteAlternaId} se ha creado correctamente";

            return RedirectToAction("Index");
        }

        // Presenta el formulario con la identidad seleccionada para actualizar
        [HttpGet]
        public IActionResult Edit(int id)
        {
            AltParte altparte = db.altPartes.Find(id);

            return View(altparte);
        }

        [HttpPost]
        public IActionResult Edit(AltParte altparte)
        {
            db.altPartes.Update(altparte);
            db.SaveChanges();

            TempData["mensaje"] = $"La parte  {altparte.ParteAlternaId} se ha actualizado correctamente";

            return RedirectToAction("Index");
        }


        // Presenta el formulario con la identidad seleccionada para borrar
        [HttpGet]
        public IActionResult Delete(int id)
        {
            AltParte altparte = db.altPartes.Find(id);

            return View(altparte);
        }

        [HttpPost]
        public IActionResult Delete(AltParte altparte)
        {
            db.altPartes.Remove(altparte);
            db.SaveChanges();

            TempData["mensaje"] = $"la parte {altparte.ParteAlternaId} se ha borrado correctamente";

            return RedirectToAction("Index");
        }


    }
}
