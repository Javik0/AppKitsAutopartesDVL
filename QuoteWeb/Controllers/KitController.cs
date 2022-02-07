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
    public class KitController : Controller
    {
        private readonly QuoteDB db;

        public KitController(QuoteDB db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Kit> ListaKit = 
                db.kits
                 .Include(ListaKit => ListaKit.KitParts);
            
            return View(ListaKit);
        }


        // POST
        //  Guarda un nuevo cliente

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kit kit)
        {
            db.kits.Add(kit);
            db.SaveChanges();

            TempData["mensaje"] = $"el kit {kit.KitId} se ha creado correctamente";

            return RedirectToAction("Index");
        }

        // Presenta el formulario con la identidad seleccionada para actualizar
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Kit kit = db.kits.Find(id);

            return View(kit);
        }

        [HttpPost]
        public IActionResult Edit(Kit kit)
        {
            db.kits.Update(kit);
            db.SaveChanges();

            TempData["mensaje"] = $"el kit {kit.Nombre} se ha actualizado correctamente";

            return RedirectToAction("Index");
        }


        // Presenta el formulario con la identidad seleccionada para borrar
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Kit kit = db.kits.Find(id);

            return View(kit);
        }

        [HttpPost]
        public IActionResult Delete(Kit kit)
        {
            db.kits.Remove(kit);
            db.SaveChanges();

            TempData["mensaje"] = $"el kit {kit.Nombre} se ha borrado correctamente";

            return RedirectToAction("Index");
        }


    }
}
