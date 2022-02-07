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
    public class ParteController : Controller
    {
        private readonly QuoteDB db;

        public ParteController(QuoteDB db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Parte> ListaParte = db.partes;
            
            return View(ListaParte);
        }


        // POST
        //  Guarda un nuevo cliente

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Parte parte)
        {
            db.partes.Add(parte);
            db.SaveChanges();

            TempData["mensaje"] = $"la proforma {parte.ParteId} se ha creado correctamente";

            return RedirectToAction("Index");
        }

        // Presenta el formulario con la identidad seleccionada para actualizar
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Parte parte = db.partes.Find(id);

            return View(parte);
        }

        [HttpPost]
        public IActionResult Edit(Parte parte)
        {
            db.partes.Update(parte);
            db.SaveChanges();

            TempData["mensaje"] = $"La parte  {parte.Nombre} se ha actualizado correctamente";

            return RedirectToAction("Index");
        }


        // Presenta el formulario con la identidad seleccionada para borrar
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Parte parte = db.partes.Find(id);

            return View(parte);
        }

        [HttpPost]
        public IActionResult Delete(Parte parte)
        {
            db.partes.Remove(parte);
            db.SaveChanges();

            TempData["mensaje"] = $"la parte {parte.Nombre} se ha borrado correctamente";

            return RedirectToAction("Index");
        }


    }
}
