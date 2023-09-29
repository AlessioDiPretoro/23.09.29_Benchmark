using PoliziaDiStato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliziaDiStato.Controllers
{
    public class ViolazioniController : Controller
    {
        // GET: Violazioni
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreaViolazioni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreaViolazioni(TipoViolazione v)
        {
            TipoViolazione.CreaTipoViolazione(v);
            return View();
        }

        [HttpGet]
        public ActionResult MostraListaViolazioni()
        {
            List<TipoViolazione> listaViolazioni = TipoViolazione.GetAllViolazioni();
            return View(listaViolazioni);
        }

        [HttpGet]
        public ActionResult CancellaViolazione(int id)
        {
            TipoViolazione.DeleteTipoViolazione(id);
            return RedirectToAction("MostraListaViolazioni");
        }
    }
}