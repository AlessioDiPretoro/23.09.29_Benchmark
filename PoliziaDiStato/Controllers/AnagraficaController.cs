using PoliziaDiStato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliziaDiStato.Controllers
{
    public class AnagraficaController : Controller
    {
        // GET: Anagrafica
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreaAnagrafica()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreaAnagrafica(AnagraficaTrasgressore anagrafica)
        {
            AnagraficaTrasgressore.CreaAnagrafica(anagrafica);
            return View();
        }

        [HttpGet]
        public ActionResult MostraListaAnagrafiche()
        {
            List<AnagraficaTrasgressore> listaAnagrafiche = AnagraficaTrasgressore.GetAllAnagrafiche();
            return View(listaAnagrafiche);
        }

        [HttpGet]
        public ActionResult Elimina(int id)
        {
            AnagraficaTrasgressore.DeleteAnagrafica(id);
            return RedirectToAction("MostraListaAnagrafiche");
        }
    }
}