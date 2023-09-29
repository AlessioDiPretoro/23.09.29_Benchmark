using PoliziaDiStato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliziaDiStato.Controllers
{
    public class VerbaliController : Controller
    {
        public List<SelectListItem> anagrafiche
        {
            get
            {
                List<AnagraficaTrasgressore> listAn = new List<AnagraficaTrasgressore>();
                listAn = AnagraficaTrasgressore.GetAllAnagrafiche();
                List<SelectListItem> selectList = new List<SelectListItem>();
                foreach (AnagraficaTrasgressore a in listAn)
                {
                    SelectListItem l = new SelectListItem { Text = $"{a.Cognome}  {a.Nome}", Value = a.IDanagrafica.ToString() };
                    selectList.Add(l);
                }
                return selectList;
            }
        }

        public List<SelectListItem> violazioni
        {
            get
            {
                List<TipoViolazione> listViol = new List<TipoViolazione>();
                listViol = TipoViolazione.GetAllViolazioni();
                List<SelectListItem> selectList = new List<SelectListItem>();
                foreach (TipoViolazione a in listViol)
                {
                    SelectListItem l = new SelectListItem { Text = a.Descrizione, Value = a.IDviolazione.ToString() };
                    selectList.Add(l);
                }
                return selectList;
            }
        }

        // GET: Verbali
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreaVerbale()
        {
            ViewBag.ListaAnagrafiche = anagrafiche;
            ViewBag.ListaViolazioni = violazioni;
            return View();
        }

        [HttpPost]
        public ActionResult CreaVerbale(Verbale v, int violazioni, int anagrafiche)
        {
            if (ModelState.IsValid)
            {
                v.IDviolazione = violazioni;
                v.IDanagrafica = anagrafiche;
                Verbale.CreaVerbale(v);
                return RedirectToAction("CreaVerbale");
                //return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ListaAnagrafiche = anagrafiche;
                ViewBag.ListaViolazioni = violazioni;
                return View();
            }
        }

        [HttpGet]
        public ActionResult MostraVerbali()
        {
            List<Verbale> v = new List<Verbale>();
            v = Verbale.GetAllVerbali();
            return View(v);
        }

        public ActionResult TotPunti()
        {
            List<Verbale> v = new List<Verbale>();
            v = Verbale.TotalePuntiPerTrasgressore();
            return View(v);
        }

        public ActionResult TotVerbalePerAnagrafica()
        {
            List<Verbale> v = new List<Verbale>();
            v = Verbale.TotaleVerbaliPerTrasgressore();
            return View(v);
        }

        public ActionResult VerbalePunti()
        {
            int punti = 10;
            List<Verbale> v = new List<Verbale>();
            v = Verbale.GetVerbaliPunti(punti);
            return View(v);
        }

        public ActionResult VerbaleEuro()
        {
            int euro = 400;
            List<Verbale> v = new List<Verbale>();
            v = Verbale.GetVerbaliEuro(euro);
            return View(v);
        }
    }
}